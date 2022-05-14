using Bakery.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bakery.IO
{
    public class TextWriter : IWriter
    {
        public void Write(string message)
        {
           
        }

        public void WriteLine(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\BGLYSOK\source\repos\ExamPreparationC#OOP12December2020\Bakery\text.txt"))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}
