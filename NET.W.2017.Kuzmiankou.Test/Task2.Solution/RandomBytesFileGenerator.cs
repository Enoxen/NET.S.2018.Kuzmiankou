using System;
using System.IO;

namespace Task2.Solution
{
    public class RandomBytesFileGenerator:FileGenerator
    {
        public RandomBytesFileGenerator(string directory, string fileExtension)
            :base(directory, fileExtension) { }

        public override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}
    