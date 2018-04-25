using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Converter
{
    public class HTMLConverter : IConverter
    {
        public string ConvertBoldText(BoldText boldText) => "<b>" + boldText.Text + "</b>";

        public string ConvertHyperlink(HyperLink hyperLink) => "<a href=\"" + hyperLink.Url + "\">" + hyperLink.Text + "</a>";

        public string ConvertPlainText(PlainText plainText) => plainText.Text;

    }
}
