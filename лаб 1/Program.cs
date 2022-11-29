using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace lab_1

{

    class Mission_1

    {

        public void Start()

        {

            int sum = 0;

            try

            {

                using (StreamReader sr = new StreamReader("C:/Users/383/source/repos/lab_1/lab_1/input.txt"))

                {

                    string line;

                    int tmp;

                    while ((line = sr.ReadLine()) != null)

                    {

                        tmp = int.Parse(line);

                        sum += tmp;

                    }

                }

            }

            catch (Exception e)

            {

                Console.WriteLine("Mission one failed");

                Console.WriteLine(e.Message);

            }

            try

            {

                using (StreamWriter sw = new StreamWriter("C:/Users/383/source/repos/lab_1/lab_1/output.txt"))

                {

                    sw.WriteLine(sum);

                }

            }

            catch (Exception e)

            {

                Console.WriteLine("Mission one failed");

                Console.WriteLine(e.Message);

            }

            Console.WriteLine("Mission one complete");

        }

    }

    class Mission_2

    {

        public void Start()

        {

            try

            {

                string line;

                Console.WriteLine("How many fibonacci numbers to output?");

                line = Console.ReadLine();

                int count = int.Parse(line);

                if (count < 1)

                {

                    Console.WriteLine("Wrong number");

                    Console.WriteLine("Mission two failed");

                    return;

                }

                int num_1 = 1;

                int num_2 = 1;

                if (count >= 2)

                {

                    Console.WriteLine($" 1: {num_1}");

                    Console.WriteLine($" 2: {num_2}");

                }

                if (count == 1)

                {

                    Console.WriteLine($" 1: {num_1}");

                }

                for (int i = 3; i <= count; i++)

                {

                    int tmp = num_1 + num_2;

                    num_1 = num_2;

                    num_2 = tmp;

                    Console.WriteLine($" {i}: {tmp}");

                }

            }

            catch (Exception e)

            {

                Console.WriteLine("Mission two failed");

                Console.WriteLine(e.Message);

            }

        }

    }

    class Mission_3

    {
        static Regex regex = new Regex("^(?:(M{0,4})(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})|\\d+)$");
        public void Start()

        {
            Console.WriteLine("Write a roman numeral");
            string line = Console.ReadLine();
            int[] mas = new int[line.Length];
            Match match = regex.Match(line);
            if (match.Success)
            {
                Console.WriteLine("good");
            }
            else
            {
                Console.WriteLine("not good");
                return;
            }
            for (int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case 'I':

                        mas[i] = 1;

                        break;

                    case 'V':

                        mas[i] = 5;

                        break;

                    case 'X':

                        mas[i] = 10;

                        break;

                    case 'L':

                        mas[i] = 50;

                        break;

                    case 'C':

                        mas[i] = 100;

                        break;

                    case 'D':

                        mas[i] = 500;

                        break;

                    case 'M':

                        mas[i] = 1000;

                        break;

                    default:
                        break;

                }

            }

            int sum = 0;

            int j = 0;
            while (j < line.Length)

            {

                if ((j + 1) < line.Length)

                {


                    if (mas[j + 1] > mas[j])

                    {

                        sum += mas[j + 1] - mas[j];

                        j += 2;

                    }

                    else

                    {

                        sum += mas[j];

                        j++;

                    }

                }

                else

                {

                    sum += mas[j];

                    j++;

                }

            }

            Console.WriteLine($"{line} = {sum}");

        }

    }

    class Menu

    {

        private Mission_1 one;

        private Mission_2 two;

        private Mission_3 three;

        public Menu()

        {

            one = new Mission_1();

            two = new Mission_2();

            three = new Mission_3();

        }

        public void Start()

        {

            int tmp = this.Info();

            while (tmp != 0)

            {
                tmp = this.Info();
            }
        }

        public int Info()
        {
            Console.WriteLine("What mission do you check?");
            Console.WriteLine("1 :read from file and write to file");
            Console.WriteLine("2 :numbers fibonacci");
            Console.WriteLine("3 :roman numeral converter");
            Console.WriteLine("4 :exit");
            string line = Console.ReadLine();
            switch (line)
            {
                case "1":
                    one.Start();
                    break;
                case "2":
                    two.Start();
                    break;
                case "3":
                    three.Start();
                    break;
                case "4":
                    return 0;
                default:
                    Console.WriteLine("I don't know this command");
                    break;
            }
            return 1;
        }
    }

    class Lab_1
    {
        static void Main()
        {
            Menu menu = new Menu();
            menu.Start();
        }
    }
}