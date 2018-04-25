using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Converter
{
    public class PlainTextConverter : IConverter
    {
        public string ConvertBoldText(BoldText boldText)
        => "**" + boldText.Text + "**";

        public string ConvertHyperlink(HyperLink hyperlink)
        => hyperlink.Text + " [" + hyperlink.Url + "]";

        public string ConvertPlainText(PlainText plainText)
        => plainText.Text;
    }
}
