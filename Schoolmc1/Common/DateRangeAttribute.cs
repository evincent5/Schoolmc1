using System;
using System.ComponentModel.DataAnnotations;

namespace Schoolmc1.Common
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute( string minimumValue) : base(typeof(DateTime), 
            minimumValue, DateTime.Now.ToShortTimeString())
        {

        }
    }
}