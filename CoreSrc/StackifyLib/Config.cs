﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;

namespace StackifyLib
{
	/// <summary>
	/// Encapsulate settings retrieval mechanism. Currently supports config file and environment variables.
	/// Could be expanded to include other type of configuration servers later.
	/// </summary>
	public class Config
	{
	    public static void LoadSettings()
	    {
	        try
	        {
                CaptureErrorPostdata = Get("Stackify.CaptureErrorPostdata", "")
                    .Equals("true", StringComparison.CurrentCultureIgnoreCase);

                CaptureServerVariables = Get("Stackify.CaptureServerVariables", "")
                    .Equals("true", StringComparison.CurrentCultureIgnoreCase);
                CaptureSessionVariables = Get("Stackify.CaptureSessionVariables", "")
                    .Equals("true", StringComparison.CurrentCultureIgnoreCase);

                CaptureErrorHeaders = Get("Stackify.CaptureErrorHeaders", "")
                    .Equals("true", StringComparison.CurrentCultureIgnoreCase);

                CaptureErrorCookies = Get("Stackify.CaptureErrorCookies", "")
                    .Equals("true", StringComparison.CurrentCultureIgnoreCase);

                CaptureErrorHeadersWhitelist = Get("Stackify.CaptureErrorHeadersWhitelist", "");

	            if (!string.IsNullOrEmpty(CaptureErrorHeadersWhitelist))
	            {
	                ErrorHeaderGoodKeys = CaptureErrorHeadersWhitelist.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
	            }

                CaptureErrorHeadersBlacklist = Get("Stackify.CaptureErrorHeadersBlacklist", "");
                if (!string.IsNullOrEmpty(CaptureErrorHeadersBlacklist))
                {
                    ErrorHeaderBadKeys = CaptureErrorHeadersBlacklist.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                }

                CaptureErrorCookiesWhitelist = Get("Stackify.CaptureErrorCookiesWhitelist", "");
                if (!string.IsNullOrEmpty(CaptureErrorCookiesWhitelist))
                {
                    ErrorCookiesGoodKeys = CaptureErrorCookiesWhitelist.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                }

                CaptureErrorCookiesBlacklist = Get("Stackify.CaptureErrorCookiesBlacklist", "");
                if (!string.IsNullOrEmpty(CaptureErrorCookiesBlacklist))
                {
                    ErrorCookiesBadKeys = CaptureErrorCookiesBlacklist.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                }

                CaptureErrorSessionWhitelist = Get("Stackify.CaptureErrorSessionWhitelist", "");
                if (!string.IsNullOrEmpty(CaptureErrorSessionWhitelist))
                {
                    ErrorSessionGoodKeys = CaptureErrorSessionWhitelist.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                }
	            
            }
            catch (Exception ex)
	        {
	            Debug.WriteLine(ex.ToString());
	        }
        }

        public static List<string> ErrorHeaderGoodKeys = new List<string>();
        public static List<string> ErrorHeaderBadKeys = new List<string>();
        public static List<string> ErrorCookiesGoodKeys = new List<string>();
        public static List<string> ErrorCookiesBadKeys = new List<string>();
        public static List<string> ErrorSessionGoodKeys = new List<string>();

        public static bool CaptureSessionVariables { get; set; } = false;
        public static bool CaptureServerVariables { get; set; } = false;
        public static bool CaptureErrorPostdata { get; set; } = false;
        public static bool CaptureErrorHeaders { get; set; } = true;
        public static bool CaptureErrorCookies { get; set; } = false;

        public static string CaptureErrorSessionWhitelist { get; set; } = null;

        public static string CaptureErrorHeadersWhitelist { get; set; } = null;

        public static string CaptureErrorHeadersBlacklist { get; set; } = "cookie,authorization";

        public static string CaptureErrorCookiesWhitelist { get; set; } = null;

        public static string CaptureErrorCookiesBlacklist { get; set; } = ".ASPXAUTH";


        /// <summary>
        /// Attempts to fetch a setting value given the key.
        /// .NET configuration file will be used first, if the key is not found, environment variable will be used next.
        /// </summary>
        /// <param name="key">configuration key in config file or environment variable name.</param>
        /// <param name="defaultValue">If nothing is found, return optional defaultValue provided.</param>
        /// <returns>string value for the requested setting key.</returns>
        internal static string Get(string key, string defaultValue = null)
        {
            return defaultValue;
            //string v = null;
            //try
            //{
            //	if (key != null)
            //	{
            //		v = ConfigurationManager.AppSettings[key];
            //		if (string.IsNullOrEmpty(v))
            //			v = Environment.GetEnvironmentVariable(key);
            //	}
            //}
            //finally
            //{
            //	if (v == null)
            //		v = defaultValue;
            //}
            //return v;
        }
	}
}
