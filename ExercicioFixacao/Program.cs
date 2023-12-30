using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExercicioFixacao.Entities;
using System.Globalization;

namespace ExercicioFixacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double money = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Funcionario> list = new List<Funcionario>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    list.Add(new Funcionario(name, email, salary));
                }
            }
            var emails = list.Where(p => p.Salary > money).OrderBy(p => p.Email).Select(p => p.Email);
            var sums = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);

            Console.WriteLine("Email of people whose salary is more than 2000.00:");
            foreach(var email in emails)
            {
                Console.WriteLine(email);
            }
            Console.WriteLine();
            Console.Write("Sum of salary of people whose name starts with 'M': " + sums.ToString("F2",CultureInfo.InvariantCulture));
            Console.WriteLine();


     


        }
    }
}