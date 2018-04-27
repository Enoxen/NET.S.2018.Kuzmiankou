using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    public abstract class Printer // лучше выделить абстрактный класс с базовым функционалом любого принтера
    {
        public string Name { get; set; }

        public string Model { get; set; }

        #region Object methods 
        public override bool Equals(object obj) // есть требование, чтобы принтеры были уникальными
        {                                       // можно использовать Set, которой нужны эти методы
            var printer = obj as Printer;
            return printer != null &&
                   Name == printer.Name &&
                   Model == printer.Model;
        }

        public override int GetHashCode()
        {
            var hashCode = -1566092560;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }
        #endregion

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
