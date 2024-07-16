using EmployeeClock.DAL;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Runtime.InteropServices;

namespace EmployeeClock
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            SeedService.EnsureDataBaseSetup();
            FormHandler formHandler = new FormHandler();
            formHandler.Run();
            Application.Run();
        }

       
    }
}