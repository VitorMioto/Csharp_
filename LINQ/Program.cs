using System;
using System.IO;
using LINQ.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] linha = File.ReadAllLines(@"C:\Users\vitor\Documents\GitHub\LINQ\Dados.txt");
                List<Employee> list = new List<Employee>();
                foreach (string x in linha)
                {
                    var split = x.Split(",");
                    list.Add(new Employee(split[0], split[1], Double.Parse(split[2],CultureInfo.InvariantCulture)));
                }
            }
            catch
            {
                Console.WriteLine("Erro no arquivo");
            }

        }
    }
}
