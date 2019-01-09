using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MailRoom.Model
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Checks if date with dateFormat is parse-able to System.DateTime format returns boolean value if true else false
        /// </summary>
        /// <param name="data">String date</param>
        /// <param name="dateFormat">date format example dd/MM/yyyy HH:mm:ss</param>
        /// <returns>boolean True False if is valid System.DateTime</returns>
        public static bool IsDateTime(this string data, string dateFormat)
        {
            // ReSharper disable once RedundantAssignment
            try
            {
                DateTime dateVal = default(DateTime);
                return DateTime.TryParseExact(data, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out dateVal);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int ToInt32(this string value)
        {
            int number;
            Int32.TryParse(value, out number);
            return number;
        }

        public static Decimal ToDecimal(this string value)
        {
            Decimal number;
            Decimal.TryParse(value, out number);
            return number;
        }

        /// <summary>
        ///     Checks if a string is null and returns String if not Empty else returns null/Nothing
        /// </summary>
        /// <param name="myValue">String value</param>
        /// <returns>null/nothing if String IsEmpty</returns>
        /// <remarks></remarks>
        public static string GetNullIfEmptyString(this string myValue)
        {
            if (myValue == null || myValue.Length <= 0)
            {
                return null;
            }
            myValue = myValue.Trim();
            if (myValue.Length > 0)
            {
                return myValue;
            }
            return null;
        }
        public static bool IsNullString(this string val)
        {
            if (val == null || val.Length <= 0)
            {
                return true;
            }
            val = val.Trim();
            if (val.Length > 0)
            {
                return false;
            }
            return true;
        }

        public static bool IsAWord(this string val)
        {
            return val != null && !val.Trim().Any(Char.IsWhiteSpace);
        }

        // <summary>
        ///     Checks if string length is consists of specified allowable maximum char length. does not ignore leading and
        ///     trailing white-space.
        ///     null strings will always evaluate to false.
        /// </summary>
        /// <param name="val">string to evaluate maximum length</param>
        /// <param name="maxCharLength">maximum allowable string length</param>
        /// <returns>true if string has specified maximum char length</returns>
        public static bool IsMaxLength(this string val, int maxCharLength)
        {
            return val != null && val.Length <= maxCharLength;
        }

        // TODO: special chars What list?
        public static bool HasAnySpecialChars(this string val)
        {
            // 
            string specialChar = @"\|!#$%&/()=?»«@£§€{}"; //.-;'<>_,
            foreach (var item in specialChar)
            {
                if (val.Contains(item)) return true;
            }

            return false;

        }
        /// <summary>
        ///     Checks if string length satisfies minimum and maximum allowable char length. does not ignore leading and
        ///     trailing white-space
        /// </summary>
        /// <param name="val">string to evaluate</param>
        /// <param name="minCharLength">minimum char length</param>
        /// <param name="maxCharLength">maximum char length</param>
        /// <returns>true if string satisfies minimum and maximum allowable length</returns>
        public static bool IsLength(this string val, int minCharLength, int maxCharLength)
        {
            return val != null && val.Length >= minCharLength && val.Length <= minCharLength;
        }
    }
}
