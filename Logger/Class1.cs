﻿namespace Logger
{
    using System.Net.Http;
    using System;

    public class Log
    {
        private static bool initialized = false;

        public static void Initialize()
        {
            var options = Basics.XOptions.GetProperty("OptInLogging");
            //if (options == "0")
            //{
            //    DialogResult result = MessageBox.Show("AntlrVSIX would like to send a stack trace of an exception. Can we do that? (You can change this in the AntlrVSIX options at any time.)",
            //        "Warning",
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (result == DialogResult.Yes)
            //    {
            //        //code for Yes
            //        Basics.XOptions.SetProperty("OptInLogging", "1");
            //    }
            //    else if (result == DialogResult.No)
            //    {
            //        //code for No
            //        Basics.XOptions.SetProperty("OptInLogging", "2");
            //    }
            //}
            //else if (options == "1")
            //{
            //    // Set up database.
            //}

            initialized = true;
        }

        public static void Notify(string message)
        {
            if (!initialized) Initialize();
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = httpClient.GetAsync("http://domemtech.com/home/db?" + message).Result;
            }
            catch (Exception)
            {
            }
        }
    }
}
