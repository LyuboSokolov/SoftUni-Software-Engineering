using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class Validator
    {
        public static void IsValidStat(int stat,string messages)
        {
            if (stat < 0 || stat > 100)
            {
                throw new ArgumentException($"{messages} should be between 0 and 100.");
            }
            
        }

        public static void ThrowIsNameIsNullOrWhiteSpace(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("A name should not be empty.");
            }
        }
    }
}
