using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeClock
{
    public static class Utils
    {
        public static bool IsEmptyResponse(DataTable dataTable)
        {
            return dataTable.Rows.Count == 0;
        }

        public static bool isValidNatId(string idStr)
        {
            // Check if the input string is exactly 9 digits long
            if (idStr.Length != 9 || !Regex.IsMatch(idStr, @"^\d{9}$"))
            {
                return false;
            }

            // Convert the ID to an array of integers for easier manipulation
            int[] digits = idStr.Select(c => int.Parse(c.ToString())).ToArray();


            // Validate the rest of the digits using the Israeli ID checksum algorithm
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                int digit = digits[i];
                int multiplier = (i % 2 == 0) ? 1 : 2;
                int product = digit * multiplier;
                sum += (product > 9) ? product - 9 : product;
            }

            int checksum = (10 - (sum % 10)) % 10;
            if (digits[8] != checksum)
            {
                return false;
            }

            // If all checks pass, the ID is valid
            return true;
        }

        public static void printDT(DataTable? dt)
        {

            [DllImport("kernel32.dll")]
            static extern bool AllocConsole();

            [DllImport("kernel32.dll")]
            static extern bool FreeConsole();

            // Call AllocConsole() to create a console window
            AllocConsole();

            if (dt == null)
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

        public static bool AreYouSureMsg(string msg = "Are you sure?")
        {
            DialogResult res = MessageBox.Show(msg, "are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res.Equals(DialogResult.Yes);
        }

    }
}
