using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, List<string>>();
            var departments = new Dictionary<string, List<List<string>>>();

            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] info = command.Split();
                var departament = info[0];
                var firstName = info[1];
                var secondName = info[2];
                var pacient = info[3];
                var fullName = firstName + secondName;

                if (!doctors.ContainsKey(fullName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    AddNewDepartment(departments, departament);
                }

                bool departmentIsFull = departments[departament].SelectMany(x => x).Count() >= 60;
                if (!departmentIsFull)
                {
                    doctors[fullName].Add(pacient);

                    AddPatientToDepartment(departments, departament, pacient);
                }
            }

            
            while ((command = Console.ReadLine()) != "End")
            {
                string[] outputQuery = command.Split();

                PrintOutput(doctors, departments, outputQuery);
            }
        }

        private static void PrintOutput(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string[] outputQuery)
        {
            if (outputQuery.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[outputQuery[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (outputQuery.Length == 2 && int.TryParse(outputQuery[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departments[outputQuery[0]][room - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[outputQuery[0] + outputQuery[1]].OrderBy(x => x)));
            }
        }

        private static void AddNewDepartment(Dictionary<string, List<List<string>>> departments, string departament)
        {
            departments[departament] = new List<List<string>>();
            for (int rooms = 0; rooms < 20; rooms++)
            {
                departments[departament].Add(new List<string>());
            }
        }

        private static void AddPatientToDepartment(Dictionary<string, List<List<string>>> departments, string departament, string pacient)
        {
            int room = 0;
            for (int i = 0; i < departments[departament].Count; i++)
            {
                if (departments[departament][i].Count < 3)
                {
                    room = i;
                    break;
                }
            }
            departments[departament][room].Add(pacient);
        }
    }
}
