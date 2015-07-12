using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

/*
 * konwerter wartości dla gui z wartości ushort na string w formacie 0xff i spowrotem
 */

namespace symulator8051.Converter
{
	[ValueConversion(typeof(string), typeof(ushort))]
	public class HexStringUshort : IValueConverter
	{
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string hex = value as string;
			ushort us = 0;
			if (null != hex)
			{
				string[] s = hex.Split('x');
				us = ushort.Parse(s[1], System.Globalization.NumberStyles.HexNumber);
			}
			return us;
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return "0x" + ((ushort)value).ToString("X4");
		}
	}
}
