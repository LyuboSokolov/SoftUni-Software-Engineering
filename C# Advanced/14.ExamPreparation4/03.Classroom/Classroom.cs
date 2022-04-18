using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
      
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; set; }          
        
        public int Count { get => students.Count; }
   


        public string RegisterStudent(Student student)
        {
            if (Capacity == students.Count)
            {
               return $"No seats in the classroom";
            }
            else
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (students.FirstOrDefault(p=> p.FirstName == firstName && p.LastName == lastName) == null)
            {
                return "Student not found";
            }
            else
            {
                Student student = students.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            if (students.Any(p=> p.Subject == subject))
            {
                string result = $"Subject: {subject}" + Environment.NewLine;
                result += "Student:" + Environment.NewLine;
                foreach (var studen in students)
                {
                    result += $"{studen.FirstName} {studen.LastName}" + Environment.NewLine;
                }
                return result.TrimEnd();
            }

            return "No students enrolled for the subject";

        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
        }
    }
}
