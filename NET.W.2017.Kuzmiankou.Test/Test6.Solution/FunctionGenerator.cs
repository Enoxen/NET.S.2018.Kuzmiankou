using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Solution
{
    public class FunctionGenerator<T>
    {
        private T x1;
        private T x2;

        public FunctionGenerator(T x1, T x2)
        {
            this.x1 = x1;
            this.x2 = x2;
        }

        public  IEnumerable<T> GenerateByFirstRule(int amount)
        {
            dynamic x1 = this.x1;
            dynamic x2 = this.x2;
            dynamic c = default(T);

            yield return x1;
            yield return x2;

            for (int i = 2; i < amount; i++)
            {
                c = x1 + x2;
                x1 = x2;
                x2 = c;
                yield return c;  
            }
        }

        public IEnumerable<T> GenerateBySecondRule(int amount)
        {
            dynamic x1 = this.x1;
            dynamic x2 = this.x2;
            dynamic c = default(T);

            yield return x1;
            yield return x2;

            for(int i = 2; i < amount; i++)
            {
                c = 6 * x2 - 8 * x1;
                x1 = x2;
                x2 = c;
                yield return c;
            }
        }

        public IEnumerable<T> GenerateByThirdRule(int amount)
        {
            dynamic x1 = this.x1;
            dynamic x2 = this.x2;
            dynamic c = default(T);

            yield return x1;
            yield return x2;

            for (int i = 2; i < amount; i++)
            {
                c = x2 + (x1 / x2);
                x1 = x2;
                x2 = c;
                yield return c;
            }
        }
    }
}
