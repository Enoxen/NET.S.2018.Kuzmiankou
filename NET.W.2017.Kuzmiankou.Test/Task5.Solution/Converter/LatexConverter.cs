using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Converter
{
    public class LatexConverter : IConverter
    {
        public string ConvertBoldText(BoldText boldText) => "\\textbf{" + boldText.Text + "}";

        public string ConvertHyperlink(HyperLink hyperlink) => "\\href{" + hyperlink.Url + "}{" + hyperlink.Text + "}";

        public string ConvertPlainText(PlainText plainText) => plainText.Text;
    }
}
