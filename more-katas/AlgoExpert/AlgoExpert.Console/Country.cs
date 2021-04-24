using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlgoExpert.Console
{
    public class Country
    {
        public string Name { get; }
        public string Code { get; }
        public string Region { get; }
        public int Population { get; }


        public Country(string name, string code, string region, int population)
        {
            this.Name = name;
            this.Code = code;
            this.Region = region;
            this.Population = population;
        }

    }

    public class CSVReader
    {
        private string _csvFilePath;

        public CSVReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public Country[] ReadCountriesInfo(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                sr.ReadLine();
                for (int i = 0; i < nCountries; i++)
                {
                    string csvData = sr.ReadLine();
                    countries[i] = ReadCountryFromPopulationCSV(csvData);
                }
            }

            return countries;
        }

        public static void Print()
        {
            string filePath = @"C:\Population.csv";
            //string filePathh = @"C:\Users\ElixirHand\Documents\Projects\Code-Katas\code-kata\more-katas\AlgoExpert\AlgoExpert.Console\Population.csv";
            CSVReader reader = new CSVReader(filePath);

            Country[] countries = reader.ReadCountriesInfo(10);

            foreach (Country country in countries)
            {
                System.Console.WriteLine($"{country.Name}: {country.Code}: {country.Region}: {country.Population}");
            }
        }


        public Country ReadCountryFromPopulationCSV(string csvData)
        {
            string[] parts = csvData.Split(new char[] { ',' });

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }

    }
}
