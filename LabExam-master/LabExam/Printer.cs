using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    public abstract class Printer // лучше выделить абстрактный класс с базовым функционалом любого принтера
        //другие принтеры наследуют его функционал
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public void Print(FileStream fs) // общий метод для всех принтеров, которые его просто наследуют
        {
            if (fs is null)
            {
                throw new ArgumentNullException($"{nameof(fs)} is null");
            }
            
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }
    }
}
