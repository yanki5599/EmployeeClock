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
        static async Task Main()
        {


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            await Task.Run( SeedService.EnsureDataBaseSetup);
            FormHandler formHandler = new FormHandler();
            formHandler.Run();
            Application.Run();
        }

       
    }
}