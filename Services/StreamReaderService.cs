using Predicate_PersonalExercise.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Predicate_PersonalExercise.Services
{
    internal class StreamReaderService
    {
        public static List<Product> ReadLog(string path)
        {
            List<Product> products = new List<Product>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        double price = double.Parse(line[1]);

                        products.Add(new Product(name, price));
                    }
                }
            }
            catch (IOException e)
            {
                Console.Write("An error occurred: ");
                Console.WriteLine(e);
            }

            return products;
        }
    }
}
