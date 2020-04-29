using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace NettrimCh.Api.Application.Helpers
{
    public static class DateTimeExtensions
    {
        public static TimeSpan GetHourMinutesTimeSpan (this string value)
        {
            var segments = value.Split(":");
            return new TimeSpan(Int32.Parse( segments[0]), Int32.Parse(segments[1]) , 0);
        }
    }
}
