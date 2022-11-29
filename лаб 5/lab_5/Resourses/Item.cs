using System;

namespace lab_5
{
    class Item
    {
        private string Name;

        private Info info;

        public Item(string tmp_name,Info tmp_info)
        {
            Name = tmp_name;
            info = tmp_info;
        }

        public string Get_name()
        {
            return Name;
        }

        public void show()
        {
            if (info.Get_count() != 0)
            {
                Console.WriteLine($"- {Name} count: {info.Get_count()}  price: {info.Get_price()}");
            }
        }
        
        public void Change_info(int count,double price)
        {
            info.Change_info(count,price);
        }

        public void Change_info(int count)
        {
            info.Change_info(count);
        }

        public double Get_price()
        {
            return info.Get_price();
        }

        public int Get_count()
        {
            return info.Get_count();
        }
    }
}
