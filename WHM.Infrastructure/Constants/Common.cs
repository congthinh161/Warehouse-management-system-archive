﻿/*
 Common Constant for system
 */
namespace Whm.Infrastructure.Constants
{
    public static class Common
    {
        /// <summary>
        /// Get author name
        /// </summary>
        public const string Author = "fearofgods";
        public const string Version = "1.0 - alpha";
        public const string Description = "Description";
        public const int NumberHotMovieDisplayHomePage = 20;  
        public const int NumberMovieDisplayHomePage = 12;  
        public const int PageSize = 15;
        public const bool IsNotDelete = false;
        public const bool IsDelete = true;
    }

    public static class Regex
    {
        public const string NotAllowSpecialChar = @"";
        /// <summary>
        /// Minimum 8 char, at least 1 letter and 1 number
        /// </summary>
        public const string PasswordRegexMin = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
        /// <summary>
        /// Minimum 8 char, at least 1 letter, 1 number and 1 special char
        /// </summary>
        public const string PasswordRegexMed = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
        /// <summary>
        /// Minimum 8 char, at least 1 letter upper case, 1 letter lower case, 1 number and 1 special char
        /// </summary>
        public const string PasswordRegexMax = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        public const string EmailRules = @"";
    }

    public static class FilePath
    {
        public const string S3MainPath = "efilm/";
    }
}
