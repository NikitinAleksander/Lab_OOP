using System;
using System.Collections.Generic;

namespace lab_5
{
    class Service_layer
    {
        private Layer_DAO Data;

        public void show()
        {
            Data.show();
        }

        public Service_layer()
        {
            Data = new Layer_DAO();
        }

        public void Create_shop(string tmp_name)
        {
            int tmp_key = Data.Get_count_shop()+1;
            Shop tmp = new Shop(tmp_key, tmp_name);
            Data.Add_shop(tmp);
        }

        public void New_shipment(string shop_name,string item_name,int count,double price)
        {
            List<Shop> shops = Data.Get_shops();

            int index_of_shop = -1;
            for(int i = 0; i < shops.Count; i++)
            {
                if (shop_name == shops[i].Get_name())
                {
                    index_of_shop = i;
                }
            }
            if (index_of_shop == -1)
            {
                Console.WriteLine("Incorrect shop name");
                return;
            }

            int index_of_item = -1;
            for (int i = 0; i < shops[index_of_shop].Catalog.Count; i++)
            {
                if (item_name == shops[index_of_shop].Catalog[i].Get_name())
                {
                    index_of_item = i;
                }
            }
            if (index_of_item == -1)
            {
                Console.WriteLine("Incorrect item name");
                return;
            }

            if (count < 0 || price <= 0)
            {
                Console.WriteLine("Incorrect request");
                return;
            }

            shops[index_of_shop].Catalog[index_of_item].Change_info(count, price);
        }
        
        public double Buy_item(string shop_name, string item_name, int count)
        {
            List<Shop> shops = Data.Get_shops();

            int index_of_shop = -1;
            for (int i = 0; i < shops.Count; i++)
            {
                if (shop_name == shops[i].Get_name())
                {
                    index_of_shop = i;
                }
            }
            if (index_of_shop == -1)
            {
                Console.WriteLine("Incorrect shop name");
                return 0;
            }

            int index_of_item = -1;
            for (int i = 0; i < shops[index_of_shop].Catalog.Count; i++)
            {
                if (item_name == shops[index_of_shop].Catalog[i].Get_name())
                {
                    index_of_item = i;
                }
            }
            if (index_of_item == -1)
            {
                Console.WriteLine("Incorrect item name");
                return 0;
            }

            if (count > shops[index_of_shop].Catalog[index_of_item].Get_count())
            {
                Console.WriteLine("There is so much");
                return 0;
            }
            shops[index_of_shop].Catalog[index_of_item].Change_info(-count);
            return count * shops[index_of_shop].Catalog[index_of_item].Get_price();
        }
        
        public void Find_more_cheaply_price_for_item(string item_name)
        {
            List<Shop> shops = Data.Get_shops();

            double min_price = -1;
            string name_shop = "";
            for (int i = 0; i < shops.Count; i++)
            {
                for (int j = 0; j < shops[i].Catalog.Count; j++)
                {
                    if (item_name == shops[i].Catalog[j].Get_name())
                    {
                        if (min_price == -1 || min_price > shops[i].Catalog[j].Get_price())
                        {
                            name_shop = shops[i].Get_name();
                            min_price = shops[i].Catalog[j].Get_price();
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"Minimum price: {min_price}      shop: {name_shop}");
        }

        public void How_much_item_i_can_buy(double budget)
        {
            List<Shop> shops = Data.Get_shops();

            for(int i = 0; i < shops.Count; i++)
            {
                for(int j = 0; j < shops[i].Catalog.Count; j++)
                {
                    if (shops[i].Catalog[j].Get_price() < budget)
                    {
                        double tmp_price = shops[i].Catalog[j].Get_price();
                        double tmp_budget = budget;
                        int count = 0;
                        do
                        {
                            tmp_budget -= tmp_price;
                            count++;
                        } while (tmp_budget > tmp_price);
                        Console.WriteLine($"You can buy {count} {shops[i].Catalog[j].Get_name()} in {shops[i].Get_name()}");
                    }
                }
            }
        }

        public void Find_more_cheaply_price_for_items(List<string> item,List<int> count)
        {
            List<Shop> shops = Data.Get_shops();
            double min_sum = 0;
            string name_shop_with_min_sum = "";
            for (int i = 0; i < shops.Count; i++)
            {
                int count_of_found = 0;
                double sum = 0;
                for (int j = 0; j < shops[i].Catalog.Count; j++)
                {
                    bool check_count_item = true;
                    if (!check_count_item)
                    {
                        break;
                    }
                    for(int k = 0; k < item.Count; k++)
                    {
                        if (item[k] == shops[i].Catalog[j].Get_name())
                        {
                            count_of_found++;
                            if (shops[i].Catalog[j].Get_count() < count[k])
                            {
                                sum = 0;
                                check_count_item = false;
                            }
                            else
                            {
                                sum += (shops[i].Catalog[j].Get_price() * count[k]);
                            }
                        }
                    }
                }
                if (count_of_found==item.Count)
                {
                    if (min_sum == 0 || min_sum > sum)
                    {
                        min_sum = sum;
                        name_shop_with_min_sum = shops[i].Get_name();
                    }
                }
            }
            if (min_sum > 0)
            {
                Console.WriteLine($"Minimum price: {min_sum}      shop: {name_shop_with_min_sum}");
            }
            else
            {
                Console.WriteLine("You can't buy this items");
            }


        }

        public void Create_item(string shop_name,string item_name)
        {
            List<Shop> shops = Data.Get_shops();

            int index_of_shop = -1;
            for (int i = 0; i < shops.Count; i++)
            {
                if (shop_name == shops[i].Get_name())
                {
                    index_of_shop = i;
                }
            }
            if (index_of_shop == -1)
            {
                Console.WriteLine("Incorrect shop name");
                return;
            }

            int index_of_item = -1;
            for (int i = 0; i < shops[index_of_shop].Catalog.Count; i++)
            {
                if (item_name == shops[index_of_shop].Catalog[i].Get_name())
                {
                    index_of_item = i;
                }
            }
            if (index_of_item!=-1){
                Console.WriteLine("It's not new item");
            }
            else
            {
                shops[index_of_shop].Create_item(item_name);
            }
        }
    }
}
