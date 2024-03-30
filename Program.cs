using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CSWebscraperApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var web = new HtmlWeb();
            var doc = web.Load("https://www.formula1.com/en/drivers.html");

            var driverContainer = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'container')]");

            Console.WriteLine("Current Driver Line-up in 2024:");
            Console.WriteLine("------------------");

            if (driverContainer != null)
            {
                var drivers = driverContainer.SelectNodes("//div[contains(@class, 'listing-item--name')]");
                var teams = driverContainer.SelectNodes("//p[contains(@class, 'listing-item--team')]");
                
                for (int i = 0; i < drivers.Count; i++)
                {
                    Console.WriteLine("DRIVER: ");
                    Console.WriteLine(drivers[i].InnerText.Trim().Replace(" ", ""));
                    Console.WriteLine();
                    Console.WriteLine("TEAM: ");
                    Console.WriteLine(teams[i].InnerText);
                    Console.WriteLine("------------------");
                }
            }
            else
            {
                Console.WriteLine("Element Not Found.");
            }

            Console.ReadLine();

        }
    }
}
