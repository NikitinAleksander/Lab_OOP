using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Bank bank = new Bank("sberbank", 0.2,0.2,0.2);
              bank.Add_client("leha", "lolov", "kek", "2344", 1, new Date(12, 1, 2000),4000);
              bank.Show();
              bank.Withdraw_sum_to_client("leha", 6000);
              bank.Update(new Date(13, 5, 2000));
              bank.Withdraw_sum_to_client("leha", 1000);
              bank.Show();*/
            Menu menu = new Menu();
            menu.Start();
        }
    }
}
