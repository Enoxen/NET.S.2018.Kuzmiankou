using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam.Interface.Logger
{
    public interface ILogger // если нужны разные логгеры
    {
        void Log(string content);     
    }
}
