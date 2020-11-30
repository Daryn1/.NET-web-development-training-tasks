namespace ADO.NET_Introduction
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using CommandLine;

    /// <summary>
    /// Разработать консольное приложение, позволяющее отмечать посещение студентов на паре и оценку.
    /// Название: sc.exe
    /// Функциональность:
    /// sc -init: инициализировать базу данных
    /// создать таблицу
    /// студентов(Students { Name})
    /// лекций(Lecture { Date, Topic})
    /// посещаемости(Attendance { LectureDate, StudentName, Mark})
    /// создать хранимую процедуру, отмечающую определенного студента на лекции
    /// MarkAttendance @StudentName, @LectureDate, @Mark
    ///
    /// sc -lecture<DATE> <TOPIC>: добавить лекцию в таблицу лекций(по дате)
    ///
    /// например: sc -lecture 18.12.2017 ADONET
    ///
    /// sc -student<NAME>: добавить студента в таблицу студентов
    /// например: sc -student Ivan
    ///
    /// sc -attend<STUDENT_NAME> <DATE> <MARK>: добавить запись о посещении студента в таблице посещаемости
    ///
    /// например: sc -attend Ivan 18.12.2017 5
    ///	
    /// sc -report: вывести отчет о посещаемости
    /// * выводить Topic лекции
    /// * если студент не посетил ни одной лекции, все равно выводить его имя
    /// * если лекцию никто не посеил, все равно выводить дату и тему
    /// </summary>
    public class Task
    {
        private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated security=SSPI;database=master";
        
        private static int InitializeDatabase(InitOptions options)
        {
            var sqlConnection = new SqlConnection(ConnectionString);

            try
            {
                sqlConnection.Open();

                var sqlCommand = new SqlCommand(string.Empty, sqlConnection);

                if (!File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}StudentAttendance.mdf"))
                {
                    Console.WriteLine("Initializing database...");
                    sqlCommand.CommandText = "CREATE DATABASE StudentAttendance ON PRIMARY " +
                                             "(NAME = StudentAttendance_Data, " + 
                                             $"FILENAME = '{AppDomain.CurrentDomain.BaseDirectory}StudentAttendance.mdf', " +
                                             "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
                                             "LOG ON (NAME = StudentAttendanceLog_Log, " +
                                             $"FILENAME = '{AppDomain.CurrentDomain.BaseDirectory}StudentAttendanceLog.ldf', " +
                                             "SIZE = 1MB, " +
                                             "MAXSIZE = 5MB, " +
                                             "FILEGROWTH = 10%)";

                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Database is created successfully.");
                }
                else
                {
                    Console.WriteLine("Database is already created.");
                }

                Console.WriteLine("Creating tables...");
                sqlCommand.CommandText = @"CREATE TABLE StudentAttendance.dbo.Students (
                                           StudentID int IDENTITY (1,1) NOT NULL PRIMARY KEY,
                                           Name varchar(255));
                                           
                                           CREATE TABLE StudentAttendance.dbo.Lectures (
                                           LectureID int IDENTITY (1,1) NOT NULL PRIMARY KEY,
                                           Date datetime,
                                           Topic varchar(255));";

                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = @"CREATE TABLE StudentAttendance.dbo.Attendance (
                                           AttendanceID int IDENTITY (1,1) NOT NULL PRIMARY KEY,
                                           Mark int,
                                           StudentID int NOT NULL,
                                           LectureID int NOT NULL,
                                           CONSTRAINT FK_Attendance_Lectures FOREIGN KEY (LectureID)
                                               REFERENCES StudentAttendance.dbo.Lectures (LectureID),

                                           CONSTRAINT FK_Attendance_Students FOREIGN KEY (StudentID)
                                               REFERENCES StudentAttendance.dbo.Students (StudentID));";

                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Tables is created successfully.");

                Console.WriteLine("Creating procedure...");
                sqlCommand.CommandText = @"USE StudentAttendance;";
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = @"CREATE PROCEDURE dbo.MarkAttendance 
                                      @LectureDate datetime,
                                      @StudentName varchar(255), 
                                      @Mark int
                                  AS
                                      INSERT INTO StudentAttendance.dbo.Attendance (
                                          StudentID, 
                                          LectureID,
                                          Mark)
                                      VALUES ((select StudentID from StudentAttendance.dbo.Students where Name=@StudentName), 
                                              (select LectureID from StudentAttendance.dbo.Lectures where Date=@LectureDate), 
                                              @Mark);";

                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Procedure is created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return 1;
        }

        private static int AddLecture(AddLectureOptions options)
        {
            Console.WriteLine("Adding lecture to database...");

            if (!File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}StudentAttendance.mdf"))
            {
                Console.WriteLine("Database is not created. Type 'sc -init'.");
                return 1;
            }

            var sqlConnection = new SqlConnection(ConnectionString);

            try
            {
                sqlConnection.Open();
                var command = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "INSERT INTO StudentAttendance.dbo.Lectures VALUES (@Date, @Topic)"
                };

                var date = command.CreateParameter();
                date.ParameterName = "@Date";
                date.SqlDbType = SqlDbType.DateTime;
                date.Direction = ParameterDirection.Input;
                date.Value = options.Date;
                command.Parameters.Add(date);

                var topic = command.CreateParameter();
                topic.ParameterName = "@Topic";
                topic.SqlDbType = SqlDbType.VarChar;
                topic.Direction = ParameterDirection.Input;
                topic.Value = options.Topic;
                command.Parameters.Add(topic);

                var affected = command.ExecuteNonQuery();
                Console.WriteLine(affected > 0 ? "Lecture added successfully." : "Lecture is not added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return 1;
        }

        private static int AddStudent(AddStudentOptions options)
        {
            Console.WriteLine("Adding student to database...");

            if (!File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}StudentAttendance.mdf"))
            {
                Console.WriteLine("Database is not created. Type 'sc -init'.");
                return 1;
            }

            var sqlConnection = new SqlConnection(ConnectionString);

            try
            {
                sqlConnection.Open();
                var command = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "INSERT INTO StudentAttendance.dbo.Students VALUES (@StudentName)"
                };

                var studentName = command.CreateParameter();
                studentName.ParameterName = "@StudentName";
                studentName.SqlDbType = SqlDbType.VarChar;
                studentName.Direction = ParameterDirection.Input;
                studentName.Value = options.StudentName;
                command.Parameters.Add(studentName);

                var affected = command.ExecuteNonQuery();
                Console.WriteLine(affected > 0 ? "Student added successfully." : "Student is not added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return 1;
        }

        private static int AddAttendanceRecord(AddAttendanceRecordOptions options)
        {
            Console.WriteLine("Adding attendance record to database...");

            if (!File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}StudentAttendance.mdf"))
            {
                Console.WriteLine("Database is not created. Type 'sc -init'.");
                return 1;
            }

            var sqlConnection = new SqlConnection(ConnectionString);

            try
            {
                sqlConnection.Open();
                var command = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "StudentAttendance.dbo.MarkAttendance"
                };

                var studentName = command.CreateParameter();
                studentName.ParameterName = "@StudentName";
                studentName.SqlDbType = SqlDbType.VarChar;
                studentName.Direction = ParameterDirection.Input;
                studentName.Value = options.StudentName;
                command.Parameters.Add(studentName);
                
                var lectureData = command.CreateParameter();
                lectureData.ParameterName = "@LectureDate";
                lectureData.SqlDbType = SqlDbType.DateTime;
                lectureData.Direction = ParameterDirection.Input;
                lectureData.Value = options.LectureDate;
                command.Parameters.Add(lectureData);
                
                var mark = command.CreateParameter();
                mark.ParameterName = "@Mark";
                mark.SqlDbType = SqlDbType.Int;
                mark.Direction = ParameterDirection.Input;
                mark.Value = options.Mark;
                command.Parameters.Add(mark);

                var affected = command.ExecuteNonQuery();
                Console.WriteLine(affected > 0 ? "Attendance added successfully." : "Attendance is not added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return 1;
        }

        private static int ReportAttendance(ReportAttendanceOptions options)
        {
            if (!File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}StudentAttendance.mdf"))
            {
                Console.WriteLine("Database is not created. Type 'sc -init'.");
                return 1;
            }

            Console.WriteLine("Отчет о посещаемости лекций:");
            Console.WriteLine();

            var sqlConnection = new SqlConnection(ConnectionString);

            try
            {
                sqlConnection.Open();
                var command = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = @"SELECT StudentAttendance.dbo.Lectures.Date, StudentAttendance.dbo.Lectures.Topic, StudentAttendance.dbo.Students.Name
                                        From StudentAttendance.dbo.Lectures
                                        left JOIN StudentAttendance.dbo.Attendance ON StudentAttendance.dbo.Attendance.LectureID = StudentAttendance.dbo.Lectures.LectureID
                                        left JOIN StudentAttendance.dbo.Students ON StudentAttendance.dbo.Attendance.StudentID = StudentAttendance.dbo.Students.StudentID
                                        Order by StudentAttendance.dbo.Lectures.Date"
                };

                var reader = command.ExecuteReader();
                Console.WriteLine($"Дата лекции:          | Тема:            | Имена посетивших студентов: ");

                var number = 1;
                var lastTopic = string.Empty;

                while (reader.Read())
                {
                    if (lastTopic == reader[1].ToString())
                    {
                        Console.Write($", {reader[2]}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write($"{number}. {reader[0]} | {reader[1].ToString()?.PadRight(10, ' ')}       | {reader[2]}");
                        lastTopic = reader[1].ToString();
                        number++;
                    }
                }

                reader.Close();

                command.CommandText = @"SELECT StudentAttendance.dbo.Students.Name, StudentAttendance.dbo.Lectures.Topic
                                        From StudentAttendance.dbo.Students
                                        left JOIN StudentAttendance.dbo.Attendance ON StudentAttendance.dbo.Attendance.StudentID = StudentAttendance.dbo.Students.StudentID
                                        left JOIN StudentAttendance.dbo.Lectures ON StudentAttendance.dbo.Attendance.LectureID = StudentAttendance.dbo.Lectures.LectureID
                                        Order by StudentAttendance.dbo.Students.Name";

                reader = command.ExecuteReader();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Отчет о посещаемости студентов:");
                Console.WriteLine();
                Console.WriteLine("Студент:  | Посещённые лекции:");

                number = 1;
                var lastName = string.Empty;

                while (reader.Read())
                {
                    if (lastName == reader[0].ToString())
                    {
                        Console.Write($", {reader[1]}");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write($"{number}. {reader[0].ToString()?.PadRight(6, ' ')} | {reader[1]}");
                        lastName = reader[0].ToString();
                        number++;
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return 1;
        }

        private static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<InitOptions, AddLectureOptions, AddStudentOptions, AddAttendanceRecordOptions, ReportAttendanceOptions>(args)
                .MapResult(
                    (InitOptions options) => InitializeDatabase(options),
                    (AddLectureOptions options) => AddLecture(options),
                    (AddStudentOptions options) => AddStudent(options),
                    (AddAttendanceRecordOptions options) => AddAttendanceRecord(options),
                    (ReportAttendanceOptions options) => ReportAttendance(options),
                    errors => 1);
        }

        [Verb("-init", HelpText = "Initialize database.")]
        public class InitOptions
        {
        }

        [Verb("-lecture", HelpText = "Record changes to the repository.")]
        public class AddLectureOptions
        {
            [Value(0)]
            public DateTime Date { get; set; }

            [Value(1)]
            public string Topic { get; set; }
        }

        [Verb("-student", HelpText = "Clone a repository into a new directory.")]
        public class AddStudentOptions
        {
            [Value(0)]
            public string StudentName { get; set; }
        }

        [Verb("-attend", HelpText = "Clone a repository into a new directory.")]
        public class AddAttendanceRecordOptions
        {
            [Value(0)]
            public string StudentName { get; set; }

            [Value(1)]
            public DateTime LectureDate { get; set; }

            [Value(2)]
            public int Mark { get; set; }
        }

        [Verb("-report", HelpText = "Clone a repository into a new directory.")]
        public class ReportAttendanceOptions
        {
        }
    }
}
