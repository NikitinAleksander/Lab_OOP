using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    class Client
    {
        private string name,surname,address,number_pasport;
        private Date date;
        private Account account;
        
        public Client(string tmp_name,string tmp_surname,string tmp_address,string tmp_number,int type,Date tmp_date,Date limit_date=null)
        {
            name = tmp_name;
            surname = tmp_surname;
            address = tmp_address;
            number_pasport = tmp_number;
            date = tmp_date;
            switch (type)
            {
                case 0:
                    account = new Debit_Account(tmp_date);
                    break;
                case 1:
                    account = new Credit_Account(tmp_date);
                    break;
                case 2:
                    account = new Deposit_Account(tmp_date,limit_date);
                    break;
                default:
                    break;
            }
        }

        public void Set_id(int tmp_count)
        {
            account.Set_id(tmp_count);
        }

        public void Show()
        {
            Console.WriteLine($"Client name: {name}\n" +
                $"Client surname: {surname}\n" +
                $"Pasport: {number_pasport}\n" +
                $"Address: {address}\n" +
                $"Date {date.Show_string()}\n");
        }

        public void Show_all()
        {
            this.Show();
            account.Show();
        }

        public void Create_account_info(double count,double tmp_persent)
        {
            account.Set_count(count);
            account.Set_persent(tmp_persent);
        }

        public void Update(Date tmp)
        {
            account.Add_persent(tmp);
        }

        public void Add_sum(double count)
        {
            account.Add_sum(count);
        }

        public string Get_name()
        {
            return name;
        }

        public void Withdraw_sum(double sum)
        {
            account.Withdraw_sum(sum);
        }

        public Account Get_account()
        {
            return account;
        }
    }
}
