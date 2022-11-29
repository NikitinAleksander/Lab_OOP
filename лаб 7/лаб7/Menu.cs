using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    class Menu
    {
        List<Bank> banks;
        public Menu()
        {
            banks = new List<Bank>();
        }

        public void Create_bank()
        {
            Console.WriteLine("Write name of bank:");
            string tmp_name = Console.ReadLine();
            Console.WriteLine("Write debit persent:");
            double debit_persent=-1;
            bool check = false;
            while(!check)
            {
                check = Double.TryParse(Console.ReadLine(), out debit_persent);
                if (debit_persent < 0 || debit_persent > 1)
                {
                   Console.WriteLine("Don't correct. Please repeat");
                }
                else
                {
                    check = true;
                }
            }
            Console.WriteLine("Write credit persent:");
            double credit_persent=-1;
            check = false;
            while (!check)
            {
                check = Double.TryParse(Console.ReadLine(), out credit_persent);
                if (credit_persent < 0 || credit_persent > 1)
                {
                    Console.WriteLine("Don't correct. Please repeat");
                }
                else
                {
                    check = true;
                }
            }
            Console.WriteLine("Write deposit persent:");
            double deposit_persent=-1;
            check = false;
            while (!check)
            {
                check = Double.TryParse(Console.ReadLine(), out deposit_persent);
                if (deposit_persent < 0 || deposit_persent > 1)
                {
                    Console.WriteLine("Don't correct. Please repeat");
                }
                else
                {
                    check = true;
                }
            }
            Bank tmp = new Bank(tmp_name, debit_persent, credit_persent, debit_persent);
            banks.Add(tmp);
        }

        public int Find_bank(string name)
        {
            for(int i = 0; i < banks.Count; i++)
            {
                if (name == banks[i].Get_name())
                {
                    return i;
                }
            }
            return -1;
        }

        public void Create_client()
        {
            Console.WriteLine("Write bank's name ");
            int index;
            index = this.Find_bank(Console.ReadLine());
            while (index == -1)
            {
                Console.WriteLine("Don't correct. Write again");
                index = this.Find_bank(Console.ReadLine());
            }

            Console.WriteLine("Name");
            string name = Console.ReadLine();
            Console.WriteLine("Surname");
            string surname = Console.ReadLine();
            Console.WriteLine("Address");
            string address = Console.ReadLine();
            Console.WriteLine("Pasport");
            string pasport = Console.ReadLine();
            Console.WriteLine("Type \n" +
                "0 dibet \n" +
                "1 credit\n" +
                "2 deposit\n");
            string type = Console.ReadLine();
            int type_int = -1;
            bool check = false;
            while(!check)
            {
                check = int.TryParse(type, out type_int);
                if (type_int < 0 || type_int > 2)
                {
                    Console.WriteLine("Don't correct");
                }
                else
                {
                    check = true;
                }
            }
            Console.WriteLine("day month year");
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            Date date = new Date(day, month, year);
            Console.WriteLine("Start count");
            int start_count = int.Parse(Console.ReadLine());
            banks[index].Add_client(name, surname, address, pasport, type_int, date, start_count);
        }

        public int Find_client_in_bank(string bank_name,string client_name)
        {
            int index_of_bank = Find_bank(bank_name);
            if (index_of_bank == -1)
            {
                return -1;
            }
            else
            {
                for(int i = 0; i < banks[index_of_bank].Clients.Count;i++)
                {
                    if (banks[index_of_bank].Clients[i].Get_name() == client_name)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public void Add_sum_to_client_to_bank()
        {
            Console.WriteLine("Write bank name");
            string bank_name=Console.ReadLine();
            Console.WriteLine("Write client name");
            string client_name = Console.ReadLine();
            Console.WriteLine("Write sum");
            double sum = double.Parse(Console.ReadLine());
            int index_of_bank = Find_bank(bank_name);
            if (index_of_bank != -1)
            {
                int index = Find_client_in_bank(bank_name, client_name);
                if (index != -1)
                {
                    banks[index_of_bank].Clients[index].Add_sum(sum);
                }
            }
        }

        public void Withdraw_sum_to_client_to_bank()
        {
            Console.WriteLine("Write bank name");
            string bank_name = Console.ReadLine();
            Console.WriteLine("Write client name");
            string client_name = Console.ReadLine();
            Console.WriteLine("Write sum");
            double sum = double.Parse(Console.ReadLine());
            int index_of_bank = Find_bank(bank_name);

            if (index_of_bank != -1)
                {
                int index = Find_client_in_bank(bank_name, client_name);
                if (index != -1)
                {
                    banks[index_of_bank].Clients[index].Withdraw_sum(sum);
                }
            }
        }

        public int Translate()
        {
            Console.WriteLine("Write bank name");
            string bank_name1 = Console.ReadLine();
            Console.WriteLine("Write client name");
            string client_name1 = Console.ReadLine();
            Console.WriteLine("Write sum");

            Console.WriteLine("Write bank name");
            string bank_name2 = Console.ReadLine();
            Console.WriteLine("Write client name");
            string client_name2 = Console.ReadLine();
            Console.WriteLine("Write sum");
            double sum = double.Parse(Console.ReadLine());

            int index_of_bank1 = Find_bank(bank_name1);
            if (index_of_bank1 != -1)
            {
                int index1 = Find_client_in_bank(bank_name1, client_name1);
                if (index1 != -1)
                {
                    banks[index_of_bank1].Clients[index1].Withdraw_sum(sum);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }

            int index_of_bank2 = Find_bank(bank_name2);
            if (index_of_bank2 != -1)
            {
                int index2 = Find_client_in_bank(bank_name2, client_name2);
                if (index2 != -1)
                {
                    banks[index_of_bank2].Clients[index2].Add_sum(sum);
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public void Info()
        {
            Console.WriteLine("Create bank: crb\n" +
                "Create_client: crc\n" +
                "Add sum: ads\n" +
                "Withdraw sum: wts\n" +
                "Info: inf\n" +
                "Translate: trl\n");
        }

        public void Show()
        {
            for(int i = 0; i < banks.Count; i++)
            {
                banks[i].Show();
            }
        }

        public void Start()
        {
            this.Info();
            string line = Console.ReadLine();
            while (line!="ext")
            {
                switch (line)
                {
                    case "crb":
                        this.Create_bank();
                        break;
                    case "crc":
                        this.Create_client();
                        break;
                    case "ads":
                        this.Add_sum_to_client_to_bank();
                        break;
                    case "inf":
                        this.Info();
                        break;
                    case "trl":
                        this.Translate();
                        break;
                    case "ext":
                        return;
                    case "shw":
                        this.Show();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Update()
        {
            Console.WriteLine("day month year");
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            Date date = new Date(day, month, year);
            for(int i = 0; i < banks.Count; i++)
            {
                banks[i].Update(date);
            }
        }
    }
}
