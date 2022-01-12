using System;

namespace GraduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grades = 1;
            double sum = 0;
            int count = 0;

            while (grades <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade >= 4)
                {
                    sum += grade;
                    ++grades;
                }
                else
                {
                    ++count;
                    if (count > 1)
                    {
                        break;
                    }
                }
            }
            if (grades == 13)
            {
                double average = sum / 12;
                Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {grades} grade");
            }
        }
    }
}
