using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpBukkitLive.Interface.TypeConverters
{
    public class RelativeDateTimeConverter : DateTimeConverter
    {
        static Regex rimplicit = new Regex(@"^(now|today|yesterday|tomorrow|(last|next) (second|minute|hour|week|month|year)|(\d{0,6}) (seconds?|minutes?|hours?|days?|weeks?|months?|years?) (ago|from now))$", RegexOptions.Compiled);
        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            return base.IsValid(context, value) || rimplicit.IsMatch((string)value);
        }

        static Regex lastnext = new Regex(@"^(last|next) (second|minute|hour|week|month|year)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        static Regex agofromnow = new Regex(@"^(\d{0,6}) (seconds?|minutes?|hours?|days?|weeks?|months?|years?) (ago|from now)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string str = (string)value;

            DateTime now = DateTime.Now;

            /* Implicit */
            if (str == "now")
                return now;
            if (str == "today")
                return new DateTime(now.Year, now.Month, now.Day);
            if (str == "yesterday")
                return new DateTime(now.Year, now.Month, now.Day).AddDays(-1);
            if (str == "tomorrow")
                return new DateTime(now.Year, now.Month, now.Day).AddDays(1);

            Match match = null;
            if ((match = lastnext.Match(str)).Success)
            {
                int val = match.Groups[1].Value == "next" ? 1 : -1;

                return AddUnit(now, match.Groups[2].Value, val);
            }

            if ((match = agofromnow.Match(str)).Success)
            {
                int val = int.Parse(match.Groups[1].Value);

                string unit = match.Groups[2].Value;
                if (unit.EndsWith('s'))
                    unit = unit.Substring(0, unit.Length - 1);

                if (match.Groups[3].Value == "ago")
                    val = -val;

                return AddUnit(now, unit, val);
            }

            return base.ConvertFrom(context, culture, value);
        }

        static DateTime AddUnit(DateTime now, string unit, int val)
        {
            if (unit == "second")
                return now.AddSeconds(val);
            if (unit == "minute")
                return now.AddMinutes(val);
            if (unit == "hour")
                return now.AddHours(val);
            if (unit == "day")
                return now.AddDays(val);
            if (unit == "week")
                return now.AddDays(7 * val);
            if (unit == "month")
                return now.AddMonths(val);
            if (unit == "year")
                return now.AddYears(val);

            return now;
        }
    }
}
