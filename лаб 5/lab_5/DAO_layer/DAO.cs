using System;
using System.Collections.Generic;
using System.IO;

namespace lab_5
{
    class Layer_DAO
    {
        private List<Shop> shops;

        public Layer_DAO()
        {
            shops = new List<Shop>();

            try
            {
                StreamReader sr = new StreamReader("C:/ /учеба/3 семестр/ооп/lab_5/lab_5/DAO_layer/shop.csv");
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    Shop tmp = new Shop(int.Parse(words[0]), words[1]);
                    shops.Add(tmp);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("File shops error");
            }
            try
            {
                StreamReader sr2 = new StreamReader("C:/ /учеба/3 семестр/ооп/lab_5/lab_5/DAO_layer/item.csv");
                string line;

                while ((line = sr2.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = words[0];
                    int key_shop = int.Parse(words[1]);
                    key_shop--;
                    int count = int.Parse(words[2]);
                    double price = double.Parse(words[3], System.Globalization.CultureInfo.InvariantCulture);
                    Info tmp_info = new Info(count, price);
                    Item tmp = new Item(name, tmp_info);

                    shops[key_shop].Catalog.Add(tmp);

                    if (words.Length > 4)
                    {
                        int i = 4;
                        while (i<words.Length)
                        {
                            key_shop = int.Parse(words[i]);
                            key_shop--;
                            count = int.Parse(words[i + 1]);
                            price = double.Parse(words[i + 2], System.Globalization.CultureInfo.InvariantCulture);
                            tmp_info = new Info(count, price);
                            tmp = new Item(name, tmp_info);

                            shops[key_shop].Catalog.Add(tmp);
                            i += 3;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("File item error");
            }
        }

        public void show()
        {
            for(int i = 0; i < shops.Count; i++)
            {
                shops[i].show();
                Console.WriteLine();
            }
        }

        public List<Shop> Get_shops()
        {
            return shops;
        }

        public void Add_shop(Shop tmp)
        {
            shops.Add(tmp);
        }

        public int Get_count_shop()
        {
            return shops.Count;
        }
    }
}
