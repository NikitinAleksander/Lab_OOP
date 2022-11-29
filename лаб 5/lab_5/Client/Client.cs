using System;
using System.Collections.Generic;

namespace lab_5
{
    class Client
    {
        private Service_layer service;

        public Client()
        {
            service = new Service_layer();
        }

        public void Info()
        {
            Console.WriteLine("What can I do?\n" +
                " 1.Deliver a new order:                                            nst\n" +//new snipsment
                " 2.Find a store in which a particular product is the cheapest:     fpt\n" +//find product
                " 3.What products can I buy for a certain amount:                   wbp\n" +//what buy product
                " 4.Buy a lot of products:                                          blp\n" +//buy lot product
                " 5.Find where the shipment is the cheapest:                        fst\n" +//find snipsment
                " 6.Information about command:                                      inf\n" +
                " 7.Show info about shops:                                          shw\n" +
                " 8.Create new shop:                                                cns\n" +
                " 9.Create new item:                                                cni\n" +
                " 10.Exit:                                                          ext");
        }

        public void New_shipment()
        {
            Console.WriteLine("Write shop name");
            string shop_name = Console.ReadLine();
            Console.WriteLine("Write item name");
            string item_name = Console.ReadLine();
            Console.WriteLine("Write count of item");
            string count = Console.ReadLine();
            int int_count=-1;
            bool check = int.TryParse(count, out int_count);
            while (!check)
            {
                Console.WriteLine("Incorrect count\nPlease repeat");
                count = Console.ReadLine();
                check = int.TryParse(count, out int_count);
                if (check && int_count <= 0)
                {
                    check = false;
                }
            }
            Console.WriteLine("Write price item");
            string price = Console.ReadLine();
            double double_price=-1;
            check = double.TryParse(price, out double_price);
            while (!check||double_price<=0)
            {
                Console.WriteLine("Incorrect price\nPlease repeat");
                price = Console.ReadLine();
                check = double.TryParse(price, out double_price);
               
            }
            service.New_shipment(shop_name, item_name, int_count, double_price);
            Console.WriteLine("Finish");
        }

        public void Find_more_cheaply_price_for_item()
        {
            Console.WriteLine("Write item name");
            string item_name = Console.ReadLine();
            service.Find_more_cheaply_price_for_item(item_name);
            Console.WriteLine("Finish");
        }

        public void How_much_item_i_can_buy()
        {
            Console.WriteLine("Write budget");
            string budget = Console.ReadLine();
            double double_budget = -1;
            bool check = double.TryParse(budget, out double_budget);
            while (!check || double_budget <= 0)
            {
                Console.WriteLine("Incorrect price\nPlease repeat");
                budget = Console.ReadLine();
                check = double.TryParse(budget, out double_budget);
            }
            service.How_much_item_i_can_buy(double_budget);
            Console.WriteLine("Finish");
        }

        public void Buy_item()
        {
            Console.WriteLine("Write shop name");
            string shop_name = Console.ReadLine();
            Console.WriteLine("Write item name");
            string item_name = Console.ReadLine();
            Console.WriteLine("Write count of item");
            string count = Console.ReadLine();
            int int_count = -1;
            bool check = int.TryParse(count, out int_count);
            while (!check)
            {
                Console.WriteLine("Incorrect count\nPlease repeat");
                count = Console.ReadLine();
                check = int.TryParse(count, out int_count);
                if (check && int_count <= 0)
                {
                    check = false;
                }
            }
            double result = service.Buy_item(shop_name, item_name, int_count);
            if (result>0)
            {
                Console.WriteLine($"You pay: {result}");
            }
            Console.WriteLine("Finish");
        }

        public void Find_more_cheaply_price_for_items()
        {
            Console.WriteLine("Please write item list\n" +
                "Format 'item_name;count'\n" +
                "Write 'end' to end list");
            string line;
            List<string> item_name = new List<string>();
            List<int> count = new List<int>();
            while ((line = Console.ReadLine()) != "end")
            {
                string[] words = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                int tmp_count;
                if (words.Length != 2||!int.TryParse(words[1],out tmp_count))
                {
                    Console.WriteLine("Incorrect line\nPlease repeat");
                }
                else
                {
                    item_name.Add(words[0]);
                    count.Add(tmp_count);
                }
            }
            service.Find_more_cheaply_price_for_items(item_name, count);
            Console.WriteLine("Finish");
        }

        public void Create_shop()
        {
            Console.WriteLine("Write new shop name");
            string line = Console.ReadLine();
            service.Create_shop(line);
            Console.WriteLine("Finish");
        }

        public void Create_item()
        {
            Console.WriteLine("Write shop name");
            string shop_name = Console.ReadLine();
            Console.WriteLine("Write new item name");
            string item_name = Console.ReadLine();
            service.Create_item(shop_name, item_name);
            Console.WriteLine("Finish");
        }

        public void Start()
        {
            this.Info();
            bool work = true;
            while (work)
            {
                string line = Console.ReadLine();
                switch (line)
                {
                    case "nst":
                        this.New_shipment();
                        break;
                    case "ftp":
                        this.Find_more_cheaply_price_for_item();
                        break;
                    case "wbp":
                        this.How_much_item_i_can_buy();
                        break;
                    case "blp":
                        this.Buy_item();
                        break;
                    case "fst":
                        this.Find_more_cheaply_price_for_items();
                        break;
                    case "inf":
                        this.Info();
                        break;
                    case "ext":
                        work = false;
                        break;
                    case "shw":
                        service.show();
                        break;
                    case "cns":
                        this.Create_shop();
                        break;
                    case "cni":
                        this.Create_item();
                        break;
                    default:
                        Console.WriteLine("Incorrect command\nPlease repeat");
                        break;
                }
            }
            Console.WriteLine("Goodbye");
            Console.ReadKey();
        }
    }
}
