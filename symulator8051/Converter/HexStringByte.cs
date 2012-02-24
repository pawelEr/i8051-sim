using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

/*
 * konwerter wartości dla gui z wartości byte na string w formacie 0xffm i spowrotem
 */

namespace symulator8051.Converter
{
    [ValueConversion(typeof(string), typeof(byte))]
    class HexStringByte : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string hex = value as string;
            byte b=0;
            if (null!=hex)
            {
                string[] s=hex.Split('x');
                b = System.Convert.ToByte(s[1]); 
            }
            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return "0x"+value.ToString();
        }
    }
}
