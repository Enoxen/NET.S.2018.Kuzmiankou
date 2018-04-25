using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class HyperLink: DocumentPart
    {
        public string Url { get; set; }

        public override string Convert(IConverter converter)
        {
            return converter.ConvertHyperlink(this);
        }
    }
}
