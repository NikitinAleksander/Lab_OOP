using System;
using System.Collections.Generic;

namespace lab_5
{
    class Shop
    {
        private int key;

        private string Name;

        public List<Item> Catalog;

        public Shop(int tmp_key,string tmp_Name)
        {
            key = tmp_key;
            Name = tmp_Name;
            Catalog = new List<Item>();
        }

        public int Get_key()
        {
            return key;
        }

        public string Get_name()
        {
            return Name;
        }

        public void show()
        {
            Console.WriteLine($"{key} {Name} catalog:");
            for(int i = 0; i < Catalog.Count; i++)
            {
                Catalog[i].show();
            }
        }

        public void Create_item(string item_name)
        {
            Info tmp_info = new Info(0, 0);
            Item tmp = new Item(item_name,tmp_info);
            Catalog.Add(tmp);
        }
    }
}
