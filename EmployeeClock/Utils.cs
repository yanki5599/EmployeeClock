using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        internal static bool isValidNatId(string idStr)
        {
            // Check if the input string is exactly 9 digits long
            if (idStr.Length != 9 || !Regex.IsMatch(idStr, @"^\d{9}$"))
            {
                return false;
            }

            // Convert the ID to an array of integers for easier manipulation
            int[] digits = idStr.Select(c => int.Parse(c.ToString())).ToArray();

            // Check the first digit (gender identifier)
            int genderDigit = digits[0];
            if (genderDigit != 1 && genderDigit != 2) // 1 for males, 2 for females
            {
                return false;
            }

            // Validate the year of birth (next two digits)
            int yearDigits = digits[1] * 10 + digits[2];
            int currentYearLastDigits = int.Parse(DateTime.Now.ToString("yy"));
            if (yearDigits > currentYearLastDigits || yearDigits < 0)
            {
                return false;
            }

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

    }
}
