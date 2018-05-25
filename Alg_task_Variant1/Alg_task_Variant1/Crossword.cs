using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_task_Variant1
{
    public class Crossword
    {
        private char[,] field;
        private bool horVertFlag = false;
        private List<string> words;
        int fieldShape = 20;
        
        public Crossword(IEnumerable<string> wordsCollection)
        {
            if (wordsCollection == null)
            {
                throw new ArgumentNullException($"{nameof(wordsCollection)} is null");
            }
  
            words = wordsCollection.ToList();
            InitField();
        }

        private void InitField()
        {
            if (words != null)
            {
                field = new char[fieldShape, fieldShape];
                for (int i = 0; i < fieldShape; i++)
                {
                    for (int j = 0; j < fieldShape; j++)
                    {
                        field[i,j] = '*';
                    }
                }
                return;
            }

            throw new InvalidOperationException();
        }

        public void FillCrossword()
        {
            int startPos = 2;
            PlaceFirstWord(startPos);
            for (int i = 0; i < words.Count - 1; i++)
            {
                for (int j = i + 1; j < words.Count; j++)
                {
                    var interCheck = CheckOnIntersection(words[i], words[i + 1]);

                    if (interCheck.Item1)
                    {
                        if (horVertFlag == true)
                        {
                            PlaceOnVertical(words[i + 1].ToCharArray(), i, interCheck.Item2 + startPos);
                            words[i + 1] = words[i + 1].Remove(words[i + 1].IndexOf(words[i][interCheck.Item2]), 1);
                            if (i == 0)
                            {
                                words.Remove(words[i]);
                            }
                        }
                        else
                        {
                            PlaceOnHorizontal(words[i + 1].ToCharArray(), i + interCheck.Item2 + 1, interCheck.Item2);
                            words[i + 1] = words[i + 1].Remove(words[i + 1].IndexOf(words[i][interCheck.Item2]), 1);
                            if(i == 0)
                            {
                                words.Remove(words[i]);
                                
                            }
                        }                      
                    }
                    else { break; }
                }
                words.Remove(words[i]);
            }
        }

        private Tuple<bool, int> CheckOnIntersection(string firstWord, string secondWord)
        {
            foreach (var ch in secondWord.ToCharArray())
            {
                int index = firstWord.IndexOf(ch);

                if (index != -1)
                {
                    return Tuple.Create(true, index);
                }
                
            }
            return Tuple.Create(false, -1);
        }

        private void PlaceFirstWord(int startPos)
        {
            PlaceOnHorizontal(words[0].ToCharArray(), 0, startPos);
        }

        private void PlaceOnHorizontal(char[] chars, int startI, int startJ)
        {
            for (int j = startJ; j < chars.Length + startJ; j++)
            {
                field[startI, j] = chars[j - startJ];
            }

            horVertFlag = true;
        }

        private void PlaceOnVertical(char[] chars, int startI, int startJ)
        {

            for (int i = startI; i < chars.Length + startI; i++)
            {
                field[i, startJ] = chars[i - startI];
            }

            horVertFlag = false;
        }

        public char[,] GetField() => field;

        public int GetFieldShape() => fieldShape;

    }
}
