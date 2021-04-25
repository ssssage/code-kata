using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgoExpert.Console
{
    public class CSVListReader
    {
        private string _csvFilePath;

        public CSVListReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
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

        public static void Print()
        {
            string filePath = @"C:\Population.csv";
            //string filePathh = @"C:\Users\ElixirHand\Documents\Projects\Code-Katas\code-kata\more-katas\AlgoExpert\AlgoExpert.Console\Population.csv";
            CSVListReader reader = new CSVListReader(filePath);
            List<Country> countries = reader.ReadAllCountries();
            //Country[] countries = reader.ReadCountriesInfo(10);

            var sortedCountries = from country in countries
                                  orderby country.Name
                                  where country.Population > 1000000000
                                  select country;
            
            foreach (Country country in sortedCountries)
            {
                System.Console.WriteLine($"{country.Name}: {country.Code}: {country.Region}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}");
               
            }
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
                    //name = parts[0];
                    //name = parts[0] + parts[1];
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

        //public static void PrintLists()
        //{
        //    string filePath = @"C:\Population.csv";
        //    CSVListReader reader = new CSVListReader(filePath);

        //    List<Country> countries = reader.ReadAllCountries();

        //    // This is the code that inserts and then subsequently removes Lilliput.
        //    // Comment out the RemoveAt to see the list with Lilliput in it.
        //    Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
        //    int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
        //    countries.Insert(lilliputIndex, lilliput);
        //    countries.RemoveAt(lilliputIndex);

        //    foreach (Country country in countries)
        //    {
        //        System.Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
        //    }
        //    System.Console.WriteLine($"{countries.Count} countries");
        //}

    }
}
