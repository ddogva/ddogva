//an attempt at a web scraper in C# and .NET to extract score information from bundesliga.com  (in this case the score of Bundesliga club VFL Wolfsburg)



using HtmlAgilityPack;  //web scraping class 
using System;
using System.Net;  // I/O and Network classificaton classes

namespace WolfsburgScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://www.bundesliga.com/en/teams/vfl-wolfsburg/teamnews";
            var web = new HtmlWeb(); // class is used to load the HTML content of the page
            var doc = web.Load(url); // used to load the content into the HtmlDocument object.

            var scoreNodes = doc.DocumentNode.SelectNodes("//div[@class='result']");
            if (scoreNodes == null)
            {
                Console.WriteLine("No scores found");
                return;

                // These lines use the SelectNodes method to select the HTML nodes containing the scores. 
                // The argument to the method is an XPath expression that matches the div elements with a class attribute of result. 
                // If no nodes are found, the program writes "No scores found" to the console and returns.
            }

            foreach (var node in scoreNodes)
            {
                Console.WriteLine(node.InnerHtml); 
                //  these lines iterate through the selected nodes and print their inner HTML to the console. 
                // The inner HTML of each node represents the content of the node, and in this case, it contains the score for a Vfl Wolfsburg game.
            }
        }
    }
}
