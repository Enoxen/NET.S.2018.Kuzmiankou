using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            int amountOfBytes = 0;

            using(FileStream fs = File.OpenRead(sourcePath))
            {
                using (FileStream fs1 = File.Open(destinationPath, FileMode.OpenOrCreate))
                {
                    int b = 0;
                    var temp = new UTF8Encoding(true);

                    while ((b = fs.ReadByte()) > 0)
                    {
                        fs1.WriteByte(Convert.ToByte(b));
                        amountOfBytes += 1;
                    }
                }
            }
            return amountOfBytes;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            
            string fileData;
            using (var reader = new StreamReader(sourcePath))
            {
                fileData = reader.ReadToEnd();

            }

            byte[] dataBytes = Encoding.UTF8.GetBytes(fileData);
            byte[] newBytes = new byte[dataBytes.Length];
            
            using (var memStream = new MemoryStream(newBytes))
            {
                memStream.Write(dataBytes, 0, newBytes.Length);
            }

            char[] chars = Encoding.UTF8.GetChars(newBytes);

            using (var writer = new StreamWriter(destinationPath))
            {
                foreach(char value in chars){
                    writer.Write(value);
                }
            }
            
            return newBytes.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            int buffSize;
            using (FileStream stream = File.OpenRead(sourcePath))
            {
                byte[] buffer = new byte[stream.Length];
                buffSize = buffer.Length;
                stream.Read(buffer, 0, buffer.Length);

                using (FileStream streamWrite = File.OpenWrite(destinationPath))
                {
                    streamWrite.Write(buffer, 0, buffer.Length);
                }
            }
            return buffSize;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            // TODO: Use InMemoryByByteCopy method's approach
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {

        }

        #endregion

        #endregion

    }
}
