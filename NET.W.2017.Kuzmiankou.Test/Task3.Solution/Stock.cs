using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class Stock
    {
        private StockInfo stocksInfo;
        public  StockInfo StockInfo => stocksInfo;

        public event EventHandler<StockInfo> Event = delegate { };

        public Stock()
        {
            stocksInfo = new StockInfo(0,0);
        }
        
        public Stock(StockInfo info)
        {
            if (info is null)
            {
                throw new ArgumentNullException(nameof(info));
            }
        }

        public void Notify()
        {
            Event?.Invoke(this,stocksInfo);
        }

        public void Market()
        {
            Random rnd = new Random();
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);
            Notify();
        }
    }
}
