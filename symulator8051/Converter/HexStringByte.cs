﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

/*
 * konwerter wartości dla gui z wartości byte na string w formacie 0xff i spowrotem
 */

namespace symulator8051.Converter
{
	[ValueConversion(typeof(string), typeof(byte))]
	public class HexStringByte : IValueConverter
	{
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string hex = value as string;
			byte b = 0;
			if (null != hex)
			{
				string[] s = hex.Split('x');
				b = byte.Parse(s[1], System.Globalization.NumberStyles.HexNumber);
			}
			return b;
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return "0x" + ((byte)value).ToString("X2");
		}
	}
}
