using System; // like import in Java
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Tutorial1Proj
{
    public class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //int age = 20;
            //bool b = true;

            //// Integer - used in order a variable can be nullable (be = null)
            ////Integer in C# = int?
            //int? c = null;
            //string d = "hi";

            ////cw, TAB, TAB - short for Console.Write
            //Console.WriteLine($"Im {age} y/o"); // like string concatination $ is to treat what's inside of {} as a string interpullation
            //Console.WriteLine("Hello World!");



            //program that prints every email written on a webpage
            var url = @"https://www.pja.edu.pl"; // later change program to work with String[] args so we can use it on page specified in there



            //var response = await httpClient.GetAsync(url); // asynchronous method - doesn't wait for response

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url)) // using(){} - automatically manages resources - like finally in Java
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var matches = regex.Matches(content); //Matches finds multiple occurances, Match - just one

                    foreach (var match in matches) // foreach + TAB + TAB - shortcut
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
           
            
            
            //task 4 and 5 at home

        }
    }
}
