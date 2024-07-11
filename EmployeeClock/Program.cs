using EmployeeClock.DAL;
using System.Data;
using System.Runtime.InteropServices;

namespace EmployeeClock
{
    internal static class Program
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

            
            string query = "insert into employees(EmployeeNat,FirstName,LastName) values(456789123,'j','g');";
            DataTable? dt = DBContext.MakeQuery(query);
            printDT(dt);


            /*FormHandler formHandler = new FormHandler();
            formHandler.Run();*/
            Application.Run();
        }

        public static void printDT(DataTable? dt)
        {

            [DllImport("kernel32.dll")]
            static extern bool AllocConsole();

            [DllImport("kernel32.dll")]
            static extern bool FreeConsole();

            // Call AllocConsole() to create a console window
            AllocConsole();

            if(dt == null)
            {
                Console.WriteLine("sdfsdfsdfsdfsdnull");
                Console.ReadLine();
                FreeConsole();
                return;
            }
            

            // Now Console.WriteLine() will output to this console window
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write($"{column.ColumnName,-20}"); // Adjust the width as needed
            }
            Console.WriteLine();

            // Print data rows
            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item,-15}"); // Adjust the width as needed
                }
                Console.WriteLine();
            }

            Console.ReadLine();
            // Don't forget to free the console when done
            FreeConsole();

        }
    }
}