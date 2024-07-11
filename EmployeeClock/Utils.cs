using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public static string Hash256Password(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2")); // Convert byte to hexadecimal string
                }
                return builder.ToString();
            }
        }
    }
}
