using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8HW
{
    public class Bank_Account
    {
        
        private Queue<BankTransaction> queue = new Queue<BankTransaction>();
        private uint ID { get; set; }
        private decimal Balance { get; set; }
        private static HashSet<uint> Last_Random = new HashSet<uint> { };
        public enum Acc_Type : byte
        {
            Сберегательный,
            Накопительный
        }
        private Acc_Type Type { get; set; }
        

        public Bank_Account() { }
        public Bank_Account(uint iD, decimal balance, Acc_Type type)
        {

            ID = iD;
            while (!Last_Random.Add(ID))//закидываем в HashSet и проверяем был или нет
            {
                ID += 1;
            }
            Balance = balance;
            Type = type;

        }
        public void Print() => Console.WriteLine($"Id: {ID}\nBalace: {Balance}\nType: {Type}");
        public void generateID()
        {
            Random r = new Random();
            ID = (byte)r.Next(0, 255);
        }
        public uint new_ID()
        {
            Random r = new Random();
            uint iD = (uint)r.Next(0, 999);
            
            return iD;
        }
        public void Add(decimal cash)
        {
            Balance += cash;
            Console.WriteLine($"Done! Balance: {Balance}");
            queue.Enqueue(new BankTransaction(cash));


        }
        public void Lower(decimal cash)
        {
            if (Balance > 0)
            {
                if (Balance - cash > 0)
                {
                    Balance -= cash;
                    Console.WriteLine($"Done! Balance: {Balance}");
                }
                else
                {
                    Console.WriteLine($"Not enougth money! Balance: {Balance}");
                }
            }
            else
            {
                Console.WriteLine("Something is wrong!");
            }
            queue.Enqueue(new BankTransaction(cash));
        }
        public void Transition(Bank_Account acc1, decimal perevod)
        {
            if (acc1.Balance > perevod)
            {
                acc1.Balance -= perevod;
                Balance += perevod;
            }
            else
            {
                Console.WriteLine("Not enought money");
            }
            
            queue.Enqueue(new BankTransaction(perevod));
        }
        public void Dispose()
        {
            foreach (var i in queue)
            {
                StreamWriter t = new StreamWriter("../../TextFile1");
                t.WriteLine(i.ToString());
            }
            GC.SuppressFinalize(this);
        }
    }
}


