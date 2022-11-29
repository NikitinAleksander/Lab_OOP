using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    class Bank
    {
        private string name;
        private double debit_persent, credit_persent, deposit_persent;
        public List<Client> Clients;

        public Bank(string tmp_name,double tmp_debit,double tmp_credit,double tmp_deposit)
        {
            name = tmp_name;
            debit_persent = tmp_debit;
            credit_persent = tmp_credit;
            deposit_persent = tmp_deposit;
            Clients = new List<Client>();
        }

        public void Add_client(string tmp_name, string tmp_surname, string tmp_address, string tmp_number, int type, Date tmp_date,double start_count, Date limit_date = null)
        {
            Client tmp=null;
            if (type == 2)
            {
                tmp = new Client(tmp_name, tmp_surname, tmp_address, tmp_number, type, tmp_date,limit_date);
                tmp.Create_account_info(start_count, deposit_persent);
            }
            if (type == 1)
            {
                tmp = new Client(tmp_name, tmp_surname, tmp_address, tmp_number, type, tmp_date);
                tmp.Create_account_info(start_count, credit_persent);
            }
            if (type == 0)
            {
                tmp = new Client(tmp_name, tmp_surname, tmp_address, tmp_number, type, tmp_date);
                tmp.Create_account_info(start_count, debit_persent);
            }
            tmp.Set_id(Clients.Count + 1);
            Clients.Add(tmp);
        }

        public void Update(Date tmp)
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                Clients[i].Update(tmp);
            }
        }

        public void Add_sum_to_client(string name,double count)
        {
            bool check = false;
            int index = 0;
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Get_name() == name)
                {
                    index = i;
                    check = true;
                    break;
                }
            }
            if (check)
            {
                Clients[index].Add_sum(count);
            }
        }

        public void Withdraw_sum_to_client(string name, double count)
        {
            bool check = false;
            int index = 0;
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Get_name() == name)
                {
                    index = i;
                    check = true;
                    break;
                }
            }
            if (check)
            {
                Clients[index].Withdraw_sum(count);
            }
        }

        public string Get_name()
        {
            return name;
        }

        public void Show()
        {
            Console.WriteLine($"Bank: {name}\n" +
                $"");
            for(int i = 0; i < Clients.Count; i++)
            {
                Clients[i].Show_all();
            }
        }
    }
}
