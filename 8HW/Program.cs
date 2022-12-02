using _8HW;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turk9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // task 9.1
            Bank_Account acc1 = new Bank_Account(123, 3000, Bank_Account.Acc_Type.Сберегательный);
            Bank_Account acc2 = new Bank_Account(acc1.new_ID(), 1000, Bank_Account.Acc_Type.Накопительный);
            acc2.Transition(acc1, 1000);
            acc2.Dispose();
            acc1.Print();
            acc2.Print();
            // task 9.1
            Song newSong = new Song("n1", "a1");
            Song newSong1 = new Song("n2", "a2", newSong);

            Console.ReadKey();
        }

    }
}
