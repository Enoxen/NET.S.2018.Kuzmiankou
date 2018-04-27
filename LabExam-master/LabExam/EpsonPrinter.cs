using System;
using System.IO;

namespace LabExam
{
    public class EpsonPrinter : Printer
    {

        public EpsonPrinter(string model, string name)  
        {
            if (model == null || model == string.Empty)
            {
                throw new ArgumentException($"{nameof(model)} is null or empty");
            }

            if (name == null || name == string.Empty)
            {
                throw new ArgumentException($"{nameof(name)} is null or empty");
            }

            Name = name;
            Model = model;
        }
    }
}