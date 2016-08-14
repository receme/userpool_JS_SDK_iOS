using System;
using System.Text.RegularExpressions;

namespace Core
{
	public class UtilMethods
	{
		public static bool IsEmailValid (string email)
		{
			return Regex.IsMatch (email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
		}

	}
}

