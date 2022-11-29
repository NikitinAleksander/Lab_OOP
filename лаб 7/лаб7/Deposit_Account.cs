using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    class Deposit_Account:Account
    {
        public Deposit_Account(Date tmp_date, Date limit_date)
        {
            this.Type = Accounts.Deposit;
            this.Set_date(tmp_date);
            this.Set_limit_date(limit_date);
            this.Set_first_day(tmp_date.Get_day());
        }


        public override void Add_persent(Date tmp_date)
        {
            int n = 0;

            if ((this.Get_date().Get_day() < this.Get_first_day()) && (tmp_date.Get_day() > this.Get_first_day()))
            {
                n++;
            }

            Console.WriteLine(tmp_date.How_much_days_between(tmp_date, this.Get_date()));
            if (tmp_date.How_much_days_between(tmp_date, this.Get_date()) >= 30)
            {
                int month = tmp_date.Get_month() - this.Get_date().Get_month();
                n += month;
            }

            for (int i = 0; i < n; i++)
            {
                this.Set_count(this.Get_count() + this.Get_count() * this.Get_persent());
            }

            this.Set_date(new Date(this.Get_first_day(), this.Get_date().Get_month() + n, this.Get_date().Get_year()));
            this.Set_date(tmp_date);    
        }

        public override void Withdraw_sum(double sum)
        {
            if((this.Get_date().Get_month()>this.Get_limit_date().Get_month())||((this.Get_date().Get_month() == this.Get_limit_date().Get_month()) && (this.Get_date().Get_day() > this.Get_limit_date().Get_day())))
            {
                this.Set_count(this.Get_count() - sum);
            }
            else
            {
                Console.WriteLine("You can't withdraw money\n");
            }
        }

    }
}
