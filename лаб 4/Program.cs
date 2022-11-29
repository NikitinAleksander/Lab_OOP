using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Section
    {
        private string name;
        private List<string> variable;
        private ArrayList values;
        public string Get_name()
        {
            return name;
        }
        public int Find(string var)
        {
            int find = -1;
            for(int i = 0; i < variable.Count; i++)
            {
                if (var == variable[i])
                {
                    find = i;
                    break;
                }
            }
            if (find != -1)
            {
                return find;
            }
            else
            {
                Console.WriteLine("Don't correct variable name ");
                return -1;
            }
        }

        public string Get_value(int index_variable)
        {
            return values[index_variable].ToString();
        }

        public Section(string str)
        {
            name = str;
            variable = new List<string>();
            values = new ArrayList();
        }
        public void Set(string a)
        {
            if (a.IndexOf(';')!=-1)
            {
                a = a.Substring(0, a.IndexOf(';'));
            }
            if (a != "")
            {
                string[] words = a.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if ((words.Length != 3) || (words[1] != "="))
                {
                    Console.WriteLine("Don't correct line");
                    Console.WriteLine(a);
                    return;
                }
                variable.Add(words[0]);
                double tmp_d = new double();
                Int32 tmp_i = new Int32();
                if (Int32.TryParse(words[2], out tmp_i))
                {
                    values.Add(tmp_i);
                }
                else
                {
                    if (double.TryParse(words[2], out tmp_d))
                    {
                        values.Add(tmp_d);
                    }
                    else
                    {
                        values.Add(words[2]);
                    }

                }
            }
            
        }

        public void Show()
        {
            Console.WriteLine(name);
            Console.WriteLine();
            for(int i = 0; i < variable.Count; i++)
            {
                Console.WriteLine($"--{variable[i]} = {values[i].ToString()} ");
            }
            Console.WriteLine();
        }

    }

    class File_ini
    {
        private StreamReader data;
        private List<Section> sections;
        public File_ini(string path)
        {
            try
            {
                data = new StreamReader(path);
                sections = new List<Section>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Read_Info()
        {
            string line;
            try
            {
                while ((line = data.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        if (line[0] == '[')
                        {
                            Section tmp = new Section(line);
                            sections.Add(tmp);
                        }
                        else
                        {
                            sections[sections.Count - 1].Set(line);
                        }
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Show()
        {
            for(int i = 0; i < sections.Count; i++)
            {
                sections[i].Show();
            }
        }

        public dynamic Find(string section,string variable,string type)
        {
            int index_section = -1;
            int index_variable = -1;
            for(int i = 0; i < sections.Count; i++)
            {
                if (sections[i].Get_name() == section)
                {
                    index_section = i;
                    break;
                }
            }
            if (index_section != -1)
            {
                index_variable = sections[index_section].Find(variable);
                if (index_variable != -1)
                {
                    string result = sections[index_section].Get_value(index_variable);
                    if (type == "int")
                    {
                        int tmp ;
                        if(int.TryParse(result,out tmp))
                        {
                            return tmp;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect type conversation");
                            return "";
                        }
                    }
                    else
                    {
                        if (type == "double")
                        {
                            double tmp;
                            if(double.TryParse(result,out tmp))
                            {
                                return tmp;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect type conversation");
                                return "";
                            }
                        }
                        else
                        {
                            if (type == "string")
                            {
                                return result;  
                            }
                            else
                            {
                                Console.WriteLine("Don't correct type");
                                return "";
                            }
                        }
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                Console.WriteLine("Don't correct section name");
                return "";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            File_ini test = new File_ini("C:/ /учеба/3 семестр/ооп/лаб 4/lab4/lab4/text.ini");
            test.Read_Info();
            test.Show();
            Console.WriteLine((test.Find("[LEGACY_XML]", "ListenTcpPort","int")));
            Console.WriteLine((test.Find("[NCMD]", "SampleRate", "double")));
            Console.Read();
        }
    }
}
