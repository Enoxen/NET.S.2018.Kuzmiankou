using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam.Interface.Manager
{
    public interface IPrinterManager // если нам понадобится разные менеджеры
    {
        void Add(Printer printer);
        void Print(Printer print);
    }
}
