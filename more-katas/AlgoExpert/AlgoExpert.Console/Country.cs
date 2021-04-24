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

        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                // read header line
                sr.ReadLine();

                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    countries.Add(ReadCountryFromCsvLine(csvLine));
                }
            }

            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            string name;
            string code;
            string region;
            string popText;
            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;
                case 5:
                    name = parts[0] + ", " + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLine: {csvLine}");
            }

            // TryParse leaves population=0 if can't parse
            int.TryParse(popText, out int population);
            return new Country(name, code, region, population);
        }

        public static void PrintLists()
        {
            string filePath = @"C:\Population.csv";
            CSVReader reader = new CSVReader(filePath);

            List<Country> countries = reader.ReadAllCountries();

            // This is the code that inserts and then subsequently removes Lilliput.
            // Comment out the RemoveAt to see the list with Lilliput in it.
            Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            countries.Insert(lilliputIndex, lilliput);
            countries.RemoveAt(lilliputIndex);

            foreach (Country country in countries)
            {
                System.Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            System.Console.WriteLine($"{countries.Count} countries");
        }

        

    }
}