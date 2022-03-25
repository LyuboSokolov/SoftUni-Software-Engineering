using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputStudent = Console.ReadLine().Split();
                string student = inputStudent[0];
                decimal grade = decimal.Parse(inputStudent[1]);

                if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<decimal>());
                }
                students[student].Add(grade);
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
                
               
            }
        }
    }
}
