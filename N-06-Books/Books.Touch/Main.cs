using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UIKit;

namespace Books.Touch
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }
    }
}