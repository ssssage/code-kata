using System;
using System.Collections.Generic;
using System.IO;

namespace AlgoExpert.Console
{
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

        public Country ReadCountryFromPopulationCSV(string csvLine)
        {
            string[] parts = csvLine.Split(new char[] { ',' });

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }      

    }
}