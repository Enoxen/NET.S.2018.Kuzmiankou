using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class Document
    {
        List<DocumentPart> parts;

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts is null)
            {
                throw new ArgumentNullException(nameof(parts));
            }

            this.parts = new List<DocumentPart>(parts);
        }

        public string[] Convert(IConverter converter)
        {
            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            var strings = new List<string>();
            foreach(var part in parts)
            {
                strings.Add(part.Convert(converter));
            }
            return strings.ToArray();
        }
        
    }
}
