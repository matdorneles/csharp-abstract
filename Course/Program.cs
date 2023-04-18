using System.Globalization;
using Course.Entities;

namespace Aulas
{
    class Aulas
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char select = char.Parse(Console.ReadLine());

                if (select == 'i')
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                }
            }

            double sum = 0;
            foreach (TaxPayer taxPayer in list)
            {
                Console.WriteLine($"{taxPayer.Name} {taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture)}");
                sum += taxPayer.Tax();
            }
            Console.WriteLine($"TOTAL TAXES: {sum.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
