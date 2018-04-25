using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Solution;

namespace Task3.Console
{
    class Runner
    {
        static void Main(string[] args)
        {
            var stockI = new Solution.StockInfo(100, 100);
            var stock = new Task3.Solution.Stock(stockI);
            var bank = new Task3.Solution.Bank("adc", stock);
            var broker = new Task3.Solution.Broker("bcd", stock);

            stock.Market();
        }
    }
}
