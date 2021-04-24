using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlgoExpert.Console
{
    public class Employee
    {
        public int EMPID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listEmployee = new List<Employee>
            {

                new Employee{EMPID=100,Name="Fayaz",Position="UI Developer",Salary=50000},
                new Employee{EMPID=101,Name="Firoz",Position="JavaScript Developer",Salary=40000},
                new Employee{EMPID=102,Name="Rahul",Position="Anroid Developer",Salary=45000},
                new Employee{EMPID=103,Name="Priya",Position="Windows Developer",Salary=60000},
                new Employee{EMPID=104,Name="Monica",Position="ASP.Net Developer",Salary=80000},
                new Employee{EMPID=105,Name="Umesh",Position="Salas Excutive",Salary=3000},
                new Employee{EMPID=106,Name="Danish",Position="Digital Marketing",Salary=25000},
                new Employee{EMPID=107,Name="Mohit",Position="Marketing",Salary=18000},
                new Employee{EMPID=108,Name="Pankaj",Position="Salas Excutive",Salary=35000},
                new Employee{EMPID=109,Name="Sangeeta",Position="UI Developer",Salary=28000},
                new Employee{EMPID=110,Name="Karma",Position="Salas Excutive",Salary=32000},
                new Employee{EMPID=111,Name="Suresh",Position="Testing",Salary=48000},
                new Employee{EMPID=112,Name="Jakesh",Position="HR",Salary=42000},
                new Employee{EMPID=113,Name="Dilawar",Position="Angular Developer",Salary=58000 },
                new Employee{EMPID=114,Name="Bahobali",Position="Desginer",Salary=25000}

            };

            return listEmployee;
        }

        public static void PrintEmployee()
        {
            do
            {
                IEnumerable<Employee> betsEmployees = GetAllEmployees();
                System.Console.Write("Please Enter Page number 1,2 or 3 \n");
                int pageNumber = 0;

                if (int.TryParse(System.Console.ReadLine(), out pageNumber))
                {
                    if (pageNumber >= 1 && pageNumber <= 3)
                    {
                        int pageSize = 5;
                        IEnumerable<Employee> result = betsEmployees.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                        System.Console.WriteLine();
                        System.Console.WriteLine("Displaying page " + pageSize);
                        foreach (Employee emp in result)
                        {
                            System.Console.WriteLine(emp.EMPID + "\t" + emp.Name + "\t" + emp.Position + "\t" + emp.Salary);
                        }
                        System.Console.WriteLine();
                    }
                    else
                    {
                        System.Console.WriteLine("Page number must be integer between 1 and 3");
                    }
                }
                else
                {
                    System.Console.WriteLine("Page number must be integer between 1 and 3");
                }
            } while (1 == 1);
        }
    }

    public class Details
    {
        private static void ShowLargeFilesWithLinq(string path)
        {
            path = @"C:\Windows";
                  var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;

            foreach (var file in query.Take(5))
            {
                System.Console.WriteLine($"{file.Name,-20} : {file.Length,10}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            //Get All csv Files  
            FileInfo[] getAllCSVFiles = di.GetFiles();
            Array.Sort(getAllCSVFiles, new FileInfoComparer());
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = getAllCSVFiles[i];
                System.Console.WriteLine($"{file.Name,-20} : {file.Length,10}");
            }
        }

        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo x, FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
    }
}

