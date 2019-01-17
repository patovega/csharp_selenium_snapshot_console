using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_Selenium_Snapshot_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = new RequestUrl();

            request.Name = "website_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + + DateTime.Now.Year ;
            request.Address = "http://pages.revox.io/dashboard/4.1.0/angular/casual/dashboard";

            Utils.TakeScreenShot(request);
            Console.WriteLine("Press any key to close program");
            Console.ReadKey();
        }

        
    }
}
