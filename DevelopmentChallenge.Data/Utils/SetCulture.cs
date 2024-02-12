using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Utils
{
    public class SetCulture
    {
        public static void InitializeCulture(string idioma)
        {
            CultureInfo customCulture = new System.Globalization.CultureInfo(idioma);
            NumberFormatInfo numberFormat = (NumberFormatInfo)customCulture.NumberFormat.Clone();
            numberFormat.NumberDecimalSeparator = ",";
            numberFormat.NumberGroupSeparator = ".,";
            customCulture.NumberFormat = numberFormat;


            Thread.CurrentThread.CurrentCulture = customCulture;
            Thread.CurrentThread.CurrentUICulture = customCulture;
        }


    }
}
