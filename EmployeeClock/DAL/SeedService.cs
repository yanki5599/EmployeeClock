using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

// not used
namespace EmployeeClock.DAL
{
    internal static class SeedService
    {
        public static void EnsureDataBaseSetup()
        {
            try
            {
                EnsureDataBase();
                EnsureTables();
                SeedData();
            }
            catch(Exception ex)  
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }

        }


        private static void EnsureDataBase()
        {
            string quary = @$" 
                use master;
                IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = '{DBConfig.databaceName}')
                                BEGIN
                                    CREATE DATABASE [{DBConfig.databaceName}]
                                END";
            DBContext.ExecuteNonQuery(quary, GetInitConnString());

        }

        private static string GetInitConnString()
        {
            var config = new ConfigurationBuilder()
                        .AddUserSecrets<Program>()
                        .Build();
            string? connectionString = config["connectionStringInit"];
            if (connectionString == null)
                throw new Exception("Cannot read conn striong from secrets");
            return connectionString;
        }
        private static void EnsureTables()
        {
            try
            {
                // Create Employees table if not exists
                string createEmployeesTableQuery = $@"
                use empAttendence;
                IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Employees')
                BEGIN
                    use {DBConfig.databaceName};
                    CREATE TABLE Employees (
                        ID INT PRIMARY KEY IDENTITY,
                        EmployeeNat VARCHAR(10) UNIQUE,
                        FirstName VARCHAR(15),
                        LastName VARCHAR(15)
                    );
                END";

                DBContext.ExecuteNonQuery(createEmployeesTableQuery);

                // Create EmployeeAttendance table if not exists
                string createEmployeeAttendanceTableQuery = @"
                use empAttendence;
                IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'EmployeeAttendance')
                BEGIN
                    CREATE TABLE EmployeeAttendance (
                        ID INT PRIMARY KEY IDENTITY,
                        EmployeeCode INT,
                        EntryTime DATETIME not null,
                        ExitTime DATETIME,
                        FOREIGN KEY (EmployeeCode) REFERENCES Employees(ID)
                    );
                END";

                DBContext.ExecuteNonQuery(createEmployeeAttendanceTableQuery);

                // Create Passwords table if not exists
                string createPasswordsTableQuery = @"
                use empAttendence;
                IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Passwords')
                BEGIN
                    CREATE TABLE Passwords (
                        ID INT PRIMARY KEY IDENTITY,
                        EmployeeID INT,
                        EmployeePassword VARBINARY(256),
                        ExpiryDate DATE not null,
                        IsActive BIT not null,
                        FOREIGN KEY (EmployeeID) REFERENCES Employees(ID)
                    );
                END";

                DBContext.ExecuteNonQuery(createPasswordsTableQuery);

                Console.WriteLine("Tables created or already exist.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating tables: {ex.Message}");
            }
        }



        private static void SeedData()
        {
            const string idNat = "315175455";
            const string fname = "Jacob";
            const string lname = "Gottlib";
            const string password = "1234";
            var now = DateTime.Now;
            DateTime tomorrow = new DateTime(now.Year, now.Month, now.Day + 1);

            try
            {
                string createEmpAndPass = $@"
                    use empAttendence;
                    IF NOT EXISTS (SELECT 1 FROM Employees)
                    begin
                        insert into Employees(EmployeeNat,FirstName,LastName)
                        values(@id,@fname,@lname);

                        DECLARE @GenId int = (select e.ID from Employees e where e.EmployeeNat = @id);
                        
                        insert into Passwords(EmployeeID,EmployeePassword,ExpiryDate,IsActive)
                        values(@GenId,HASHBYTES('SHA2_256',@pass),@exDate,1)
            end";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", SqlDbType.VarChar) { Value = idNat },
                    new SqlParameter("@fname", SqlDbType.VarChar) { Value = fname },
                    new SqlParameter("@lname", SqlDbType.VarChar) { Value = lname },
                    new SqlParameter("@pass", SqlDbType.VarChar) { Value = password },
                    new SqlParameter("@exDate", SqlDbType.DateTime) { Value = tomorrow },
                };

                

                DBContext.ExecuteNonQuery(createEmpAndPass,parameters.ToArray());
                   
                Console.WriteLine("user and pass created or already exist.");
            }
            catch (Exception ex) 
            {
                Console.WriteLine("error inserting emp and pass:" + ex.Message);
                throw;
            }
            

        }

        
    }
}
