using System;
using System.Collections.Generic;


namespace Project4
{
    class Rational_Fraction
    {
        public float m;
        public float n;

        public Rational_Fraction(float a,float b)
        {
            m = a;
            n = b;
        }
        public Rational_Fraction()
        {
            m = new float();
            n = new float();
        }
        public static bool operator >(Rational_Fraction a,Rational_Fraction b)
        {
            if (a.m / a.n > b.m / b.n)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(Rational_Fraction a, Rational_Fraction b)
        {
            if (a.m / a.n < b.m / b.n)
            {
                return true;
            }
            return false;
        }

        public static Rational_Fraction operator +(Rational_Fraction a,Rational_Fraction b)
        {
            Rational_Fraction c = new Rational_Fraction();
            if (a.n != b.n)
            {
                c.m = a.m * b.n + b.m * a.n;
                c.n = a.n * b.n;
            }
            else
            {
                c.m = a.m + b.m;
                c.n = a.n;
            }
            return c;
        }
        
        public void show()
        {
            if (m / n < 0)
            {
                Console.Write("- ");
            }
            else
            {
                Console.Write("+ ");
            }
            if (m < 0)
            {
                Console.Write(-m);
            }
            else
            {
                Console.Write(m);
            }
            Console.Write("/");
            if (n < 0)
            {
                Console.Write(-n);
            }
            else
            {
                Console.Write(n);
            }
        }
    }

    class Set_of_Fraction
    {
        public List<Rational_Fraction> set;
        public Rational_Fraction max, min;
        public Rational_Fraction tmp_bigger, tmp_less;
        public int tmp_count_bigger, tmp_count_less;
        
        public Set_of_Fraction()
        {
            set = new List<Rational_Fraction>();
        }

        public void Add(Rational_Fraction a)
        {
            tmp_bigger = null;
            tmp_count_bigger = 0;
            tmp_less = null;
            tmp_count_less = 0;
            if (max == null||a > max)
            {
                max = a;
            }
            if (min == null||a < min)
            {
                min = a;
            }
            set.Add(a);
        }

        public int Bigger_than(Rational_Fraction a)
        {
            if (tmp_bigger == a)
            {
                return tmp_count_bigger;
            }
            int count = new int();
            count = 0;
            for (int i = 0; i < set.Count; i++)
            {
                if (set[i] > a)
                {
                    count++;
                }
            }
            tmp_bigger = a;
            tmp_count_bigger = count;
            return count;
        }


        public int Less_than(Rational_Fraction a)
        {
            if (tmp_less == a)
            {
                return tmp_count_less;
            }
            int count = new int();
            count = 0;
            for (int i = 0; i < set.Count; i++)
            {
                if (set[i] < a)
                {
                    count++;
                }
            }
            tmp_less = a;
            tmp_count_less = count;
            return count;
        }
    }

    class Polinom
    {
        public Set_of_Fraction set;
        public Polinom(Set_of_Fraction a)
        {
            set = a;
        }
        public Polinom()
        {
            set = new Set_of_Fraction();
        }
        public void show()
        {
            char num = 'a';
            int count = set.set.Count;
            for (int i = 0; i < count; i++)
            {
                set.set[i].show();
                Console.Write($"a{i+1}");
            }
            Console.WriteLine();
        }
        public static Polinom operator +(Polinom a,Polinom b)
        {
            Polinom c = new Polinom();
            int i = 0;
            while(i<a.set.set.Count && i < b.set.set.Count)
            {
                
                c.set.set.Add((a.set.set[i] + b.set.set[i]));
                
                i++;
            }
            return c;
        }
    }

    class Class1
    {
        public static void Main()
        {
            
            Rational_Fraction b=new Rational_Fraction(1,5);
            Set_of_Fraction a = new Set_of_Fraction();
            a.Add(b);
            Rational_Fraction c = b;
            a.Add(c);
            Rational_Fraction d = new Rational_Fraction(1, 2);
            Rational_Fraction e = new Rational_Fraction(1, 121);
            a.Add(d);
            a.Add(e);
            Set_of_Fraction z = new Set_of_Fraction();
            z.Add(e);
            z.Add(d);
            Polinom test1 = new Polinom(a);
            test1.show();
            Polinom test2 = new Polinom(z);
            test2.show();
            
            (test1 + test2).show();

            Console.ReadLine();
        }
    }
}
