using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AppStudent.ViewModels
{

    public class ValidatePasswordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            if (PasswordStrength(value.ToString().Trim()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool PasswordStrength(string Passwork)
        {
            var input = Passwork;
            //string Error = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+"); //check validate at the least one numeric value
            var hasUpperChar = new Regex(@"[A-Z]+"); //At the least one Upper char
            var hasMinChars = new Regex(@".{8}"); // Min length string
            var hasLowerChar = new Regex(@"[a-z]+"); //At the least one Lower char
            var hasSymbols = new Regex(@"[!@#$%^&*]"); // At the least one Symbol char

            //if (!hasLowerChar.IsMatch(input))
            //{
            //    //Error = "Password should contain At least one lower case letter";
            //    return false;
            //}
            //else if (!hasUpperChar.IsMatch(input))
            //{
            //    //Error = "Password should contain At least one upper case letter";
            //    return false;
            //}
            //else 
            if (!hasMinChars.IsMatch(input))
            {
                //Error = "Password should not be less than or greater than 12 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                //Error = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                //Error = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CanLoginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var hackyBindedKeyLabel = parameter as Label;
            if ((int)value >= 8)        // length > 8 ?
                return true;            // some data has been entered
            else
                return false;            // input is empty
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
