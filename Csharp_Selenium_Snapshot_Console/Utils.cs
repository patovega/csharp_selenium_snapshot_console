using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_Selenium_Snapshot_Console
{
    class Utils
    {
        public static void SaveImage(Image image, string name)
        {
            try
            {
                if (System.IO.File.Exists(GetRoute(name)))
                {
                    System.IO.File.Delete(GetRoute(name));
                }

                image.Save(GetRoute(name), System.Drawing.Imaging.ImageFormat.Png);
                image.Dispose();

                Console.WriteLine("Save image");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public static string GetRoute(string file)
        {
            string name = string.Empty;
            try
            {
               name = @"C:\Users\rvargas\Desktop\snapshot\" + file + ".png";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
           
            }

            return name;

        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {

            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            ms.Write(byteArrayIn, 0, byteArrayIn.Length);
            return Image.FromStream(ms);

        }

        public static void TakeScreenShot(RequestUrl url)
        {
            var driver = new ChromeDriver();
            Console.WriteLine("Go to " + url.Address);
            driver.Navigate().GoToUrl(url.Address);

            Thread.Sleep(5000);
            Console.WriteLine("Creating snapshot..... ");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            byte[] screenshotAsByteArray = ss.AsByteArray;

            var a = Utils.byteArrayToImage(screenshotAsByteArray);
            Console.WriteLine("saving image ");
            Utils.SaveImage(a, "image");
          
            driver.Close();
            driver.Quit();
            Console.WriteLine("Ready");
        }
    }
}
