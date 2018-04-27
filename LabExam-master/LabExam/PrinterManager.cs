using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LabExam.Interface.Manager;
using LabExam.Interface.Logger;

namespace LabExam
{

    public class PrinterManager: IPrinterManager // сервис по работе с логикой не должен быть статическим классом
                                // должен быть создан в точке входа приложения
    {

        private List<Printer> printers;

        private ILogger logger;   // любой логгер, какой мы пожелаем

        public Action<Printer> OnEndPrinting { get; } // старт печати
        public Func<Printer, bool> OnStartPrinting { get; } // конец печати

        public  ILogger Logger
        {
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                logger = value;
            }
        }

        public PrinterManager()
        {
            printers = new List<Printer>();
            OnStartPrinting += MakePrinterNotAccessible;
            OnEndPrinting += MakePrinterAccessible;
        }

        private bool MakePrinterNotAccessible(Printer printer) // заберает принтер из коллекции дабы не дать другим доступ к нему
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            return printers.Remove(printer);
        }

        private void MakePrinterAccessible(Printer printer) //возвращает принтер назад, чтобы можно было дргуим на нем печатать
        {
            if (printer is null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            printers.Add(printer);
        }

        public PrinterManager(ILogger logger): this()
        {
            if (logger is null)
            {
                throw new ArgumentNullException($"{nameof(logger)} is null");
            }
            
            this.logger = logger;
        }

        public void Add(Printer printer)
        {
            if (printer is null)
            {
                throw new ArgumentNullException($"{nameof(printer)} is null");
            }

            if (printers.Contains(printer))
            {
                Console.WriteLine("Printers must be unique");
                return;
            }

            printers.Add(printer);
        }

        public void Print(Printer printer)
        {
            logger?.Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            printer.Print(f);
            logger?.Log("Print finished");
        }
    }
}