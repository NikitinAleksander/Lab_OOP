using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    enum Accounts
    {
        Debit,
        Credit,
        Deposit
    }

    class Account
    {
        public Account()
        {
            count = 0;
            persent = 0;
            limit = 0;
        }

        private double count,persent,limit;

        private int first_day;

        private Int64 id;

        public Accounts Type;

        private Date date,limit_date,last_update;

        public virtual void Add_sum(double sum)
        {
            count += sum;
        }

        public virtual void Withdraw_sum(double sum)
        {
            count -= sum;
        }

        public virtual void Add_persent(Date tmp_date) { }

        public void Set_persent(double tmp_persent)
        {
            persent = tmp_persent;
        }

        public void Set_date(Date tmp_date)
        {
            date = tmp_date;
        }

        public void Set_limit_date(Date lim)
        {
            limit_date = lim;
        }

        public void Set_count(double tmp_count)
        {
            count = tmp_count;
        }

        public  double Get_limit()
        {
            return limit;
        }

        public double Get_count()
        {
            return count;
        }

        public double Get_persent()
        {
            return persent;
        }

        public Date Get_limit_date()
        {
            return limit_date;
        }

        public void Show()
        {
            Console.WriteLine($"Count: {count}\n" +
                $"Persent: {persent}\n");
        }

        public void Set_first_day(int tmp)
        {
            first_day = tmp;
        }

        public int Get_first_day()
        {
            return first_day;
        }

        public Date Get_date()
        {
            return date;
        }

        public Date Get_date_last_update()
        {
            return last_update;
        }

        public void Set_date_last_update(Date tmp_date)
        {
            last_update = tmp_date;
        }

        public Int64 Get_id()
        {
            return id;
        }

        public void Set_id(Int64 tmp_id)
        {
            id = tmp_id;
        }
    }
}
