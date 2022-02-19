using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (input[0] != "end")
            {
                string courseName = input[0];
                string studentName = input[1];

                if (courses.ContainsKey(courseName) == false)
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(studentName);

                }
                else
                {
                    courses[courseName].Add(studentName);
                }


                input = Console.ReadLine()
                 .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var course in courses.OrderByDescending(n => n.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var item in course.Value.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
