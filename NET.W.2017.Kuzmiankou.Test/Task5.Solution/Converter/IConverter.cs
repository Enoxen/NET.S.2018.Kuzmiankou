﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public interface IConverter
    {
        string ConvertBoldText(BoldText boldText);

        string ConvertHyperlink(HyperLink hyperlink);

        string ConvertPlainText(PlainText plainText);
    }
}
