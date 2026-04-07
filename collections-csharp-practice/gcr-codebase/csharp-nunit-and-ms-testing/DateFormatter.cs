using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DateFormatter
    {
        public string FormatDate(string inputDate)
        {
            if (string.IsNullOrWhiteSpace(inputDate))
                throw new FormatException("Date is empty or null");

            DateTime date;

            bool isValid = DateTime.TryParseExact(
                inputDate,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date
            );

            if (!isValid)
                throw new FormatException("Invalid date format");

            return date.ToString("dd-MM-yyyy");
        }
    }
}
