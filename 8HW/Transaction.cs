using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8HW
{
    public class BankTransaction
    {
        readonly DateTime data = DateTime.Now;
        readonly decimal summa;
        public BankTransaction(decimal summa)
        {
            this.summa = summa;
        }
        public void PrintInfo()
        {
            Console.WriteLine($" Date:{data} Sum:{summa}");
        }
    }
}