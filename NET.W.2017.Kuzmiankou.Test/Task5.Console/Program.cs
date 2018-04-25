namespace Task5.Console
{
    using System.Collections.Generic;
    using System;
    using Task5.Solution;
    using Task5.Solution.Converter;

    class Program
    {
        static void Main(string[] args)
        {
            List<DocumentPart> parts = new List<DocumentPart>
                {
                    new PlainText {Text = "Some plain text"},
                    new HyperLink {Text = "google.com", Url = "https://www.google.by/"},
                    new BoldText {Text = "Some bold text"}
                };

            Document document = new Document(parts);

            foreach(var str in document.Convert(new HTMLConverter()))
            {
                Console.WriteLine(str);
            }
        }
    }
}
