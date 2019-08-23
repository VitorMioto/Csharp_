using System;
using System.IO;
using LINQ.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
                    list.Add(new Employee(split[0], split[1].Replace(" ",""), Double.Parse(split[2],CultureInfo.InvariantCulture)));
                }
                Console.WriteLine("Entre com um salario: ");
                double salario = Double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                //Ordem alfabetica por e-mail onde o salario é maior que o digitado pelo usuario
                //Somar o salario de todos os empregados que o nome começa com M
                var result = list.Where(x => x.Salario > salario).OrderBy(x => x.Email);
                Console.WriteLine($"Empregados em ordem alfabética com salário acima de {salario}");
                foreach(Employee x in result)
                {
                    Console.WriteLine(x.ToString());
                }
                var result2 = list.Where(x => x.Nome[0] == 'M').Sum(x => x.Salario);
                Console.WriteLine("Soma dos salários dos empregados que começam com a letra M");
                Console.WriteLine("R$ " + result2);

            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
