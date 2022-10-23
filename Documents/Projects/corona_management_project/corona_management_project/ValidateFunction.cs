using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace corona_management_project
{
    public class ValidateFunction
    {

        private const string phone_val1 = @"^\d\d\d\d\d\d\d\d\d\d";//10d
        private const string phone_val2 = @"^\d\d\d\d\d\d\d\d\d";//9d
        private const string id_val = @"^\d\d\d\d\d\d\d\d\d";
        private const string full_name = @"^([a-zA-Z-\s]*)$";
        private const string alph_bet = @"^([a-zA-Z-\s]*)$";
        private const string alph_betNum = @"^([a-zA-Z0-9-\s]*)$";
        private const string date1 = @"^\d\d\d\d-\d\d-\d\d";
        private const string date2 = @"^\d\d/\d\d/\d\d\d\d \d\d:\d\d:\d\d";

        public static bool IsPhoneNbr(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                return true;
            number = number.Replace(" ", String.Empty);
            if (Regex.IsMatch(number, phone_val1) || Regex.IsMatch(number, phone_val2))
                return true;
            return false;         
        }
       
        public static bool IsID(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                return true;
            number = number.Replace(" ", String.Empty);
            return Regex.IsMatch(number, id_val);
          
        }

        public static bool Isfull_name(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                return true;
           return Regex.IsMatch(number, full_name);
           
        }

        public static bool IsAlphbet(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                return true;
            return Regex.IsMatch(number, alph_bet);
           
        }

        public static bool IsAlphbetAndNum(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                return true;
            return Regex.IsMatch(number, alph_betNum);
            
        }

        public static bool IsDateTime(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                return true;
           
            if (Regex.IsMatch(number, date1) || Regex.IsMatch(number, date2))
                 return true;
            return false;
                              
        }




    }
}