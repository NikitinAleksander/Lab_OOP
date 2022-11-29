using System;

namespace лаб7
{
    class Debit_Account:Account
    {
       public Debit_Account(Date tmp_date)
       {
            this.Type = Accounts.Debit;
            this.Set_date(tmp_date);
            this.Set_first_day(tmp_date.Get_day());
       }

        public override void Add_persent(Date tmp_date)
        {
            int n=0;

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

            for(int i = 0; i < n; i++)
            {
                this.Set_count(this.Get_count() + this.Get_count() * this.Get_persent());
            }

            this.Set_date(new Date(this.Get_first_day(),this.Get_date().Get_month()+n,this.Get_date().Get_year()));
            this.Set_date(tmp_date);
        }

        

    }
}
