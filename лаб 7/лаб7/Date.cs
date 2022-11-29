using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    class Date
    {
        private int day, month, year;

        public Date(int tmp_day,int tmp_month,int tmp_year)
        {
            day = tmp_day;
            month = tmp_month;
            year = tmp_year;
        }

        public void Set_new_day(int tmp_day, int tmp_month, int tmp_year)
        {
            day = tmp_day;
            month = tmp_month;
            year = tmp_year;
        }

        public void Show()
        {
            Console.WriteLine($"{day}.{month}.{year}");
        }

        public string Show_string()
        {
            return $"{day}.{month}.{year}";
        }

        public int Get_day()
        {
            return day;
        }

        public int Get_month()
        {
            return month;
        }

        public int Get_year()
        {
            return year;
        }

        public int How_much_days_between(Date one,Date two)
        {
            int tmp_year, tmp_month, tmp_day;
            tmp_year = one.Get_year() - two.Get_year();
            tmp_month = one.Get_month() - two.Get_month();
            tmp_day = one.Get_day() - two.Get_day();
            tmp_day += tmp_month * 30 + tmp_year * 365;
            return tmp_day;
        }
    }
}
