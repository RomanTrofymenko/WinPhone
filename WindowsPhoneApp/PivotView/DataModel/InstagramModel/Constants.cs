using System;

namespace PivotView.DataModel.InstagramModel
{
    internal static class Constants
    {
        public static DateTime GetDateTimeFromSeconds(string seconds)
        {
            return FixedDateStart + TimeSpan.FromSeconds(int.Parse(seconds));
        }

        private static readonly DateTime FixedDateStart = new DateTime(1970,1,1);
    }
}