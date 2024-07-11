﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeClock.DAL
{
    internal static class SeedService
    {
        public static void EnsureDataBaseSetup()
        {
            EnsureDataBase();
            EnsureTables();
            SeedData();
        }


        private static void EnsureDataBase()
        {
            string quary = @$" IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = '{DBConfig.databaceName}')
                                BEGIN
                                    CREATE DATABASE [{DBConfig.databaceName}]
                                END";
            DBContext.ExecuteNonQuery(quary);

        }
        public static void EnsureTables()
        {
            try
            {
                // Create Employees table if not exists
                string createEmployeesTableQuery = @"
                IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Employees')
                BEGIN
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
                IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'EmployeeAttendance')
                BEGIN
                    CREATE TABLE EmployeeAttendance (
                        ID INT PRIMARY KEY IDENTITY,
                        EmployeeCode INT,
                        EntryTime DATETIME,
                        ExitTime DATETIME,
                        FOREIGN KEY (EmployeeCode) REFERENCES Employees(ID)
                    );
                END";

                DBContext.ExecuteNonQuery(createEmployeeAttendanceTableQuery);

                // Create Passwords table if not exists
                string createPasswordsTableQuery = @"
                IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Passwords')
                BEGIN
                    CREATE TABLE Passwords (
                        ID INT PRIMARY KEY IDENTITY,
                        EmployeeID INT,
                        EmployeePassword VARBINARY(256),
                        ExpiryDate DATE,
                        IsActive BIT,
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
            
        }

    }
}