using System;
using System.Net.Http;
using System.Numerics;
using System.Text.RegularExpressions;

namespace cw1
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var httpClient = new HttpClient();
                try
                {
                
                    var response = await httpClient.GetAsync(args[0]);

                    if (response.IsSuccessStatusCode)
                    {
                        var html = await response.Content.ReadAsStringAsync();
                        var regex = new Regex("[a-z0-9]+@[a-z.]+");

                        var matches = regex.Matches(html);
                        var sum = 0;
                        foreach (var i in matches)
                        {
                            Console.WriteLine(i);
                            sum++;
                        }
                        if (sum == 0)
                        {
                            Console.WriteLine("Nie znaleziono adresów email");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Błąd w czasie pobierania strony");
                    }

                } catch (ArgumentNullException) {


                }

            httpClient.Dispose();

            }    
                   
    }
}
