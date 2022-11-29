using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    class Credit_Account:Account
    {
        public Credit_Account(Date tmp_date)
        {
            this.Type = Accounts.Credit;
            this.Set_date(tmp_date);
            this.Set_date_last_update(tmp_date);
            this.Set_first_day(tmp_date.Get_day());
        }

        public override void Add_persent(Date tmp_date)
        {
            if (this.Get_count() < 0)
            {
                this.Add_sum(-1 * tmp_date.How_much_days_between(this.Get_date_last_update(),tmp_date) *this.Get_count() * this.Get_persent());
            }
            this.Set_date_last_update(tmp_date);
        }

    }
}
