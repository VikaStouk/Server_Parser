using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Parser
{
    public class Command
    {
        private int[] set_parameters;
        private int[] color = new int[3];
        private int[] color0 = new int[3] { 0, 0, 0 };
        private int[] set_parameters0 = new int[2] { 0, 0 };
        private int[] set_parameters0_2 = new int[4] { 0, 0, 0, 0 };
        private int CommandNumber;
        private string parameter1 = "", parameter2 = "", parameter3 = "", parameter4 = "";
        private string color_number1 = "", color_number2 = "", color_number3 = "";
        public (int CommandNumber, int[] parameters, int[] color) Parser(string command)
        {
            char[] CommandArray = new char[command.Length];
            CommandArray = command.ToCharArray();
            try
            {
                CommandNumber = Convert.ToInt32(CommandArray[1].ToString());
            }catch
            {
                Console.WriteLine("Принята неправильная комманда!");
            }
            
            var tuple_parse0 = (0, set_parameters, color);
            if (CommandArray[0] == '#' && CommandArray[2] == '#' && CommandArray[CommandArray.Length - 1] == '$' && CommandNumber < 8 && command.Length <= 25)
            {

                if (CommandArray[1] == '1')
                {
                    tuple_parse0 = (0, set_parameters, color0);
                    for (int index = 3; index < ((CommandArray.Length) - 1); index++)
                    {
                        if (index == 3 || index == 4 || index == 5)
                        {
                            color_number1 += CommandArray[index].ToString();
                        }
                        else
                            if (index == 6 || index == 7 || index == 8)
                        {
                            color_number2 += CommandArray[index].ToString();
                        }
                        else
                            if (index == 9 || index == 10 || index == 11)
                        {
                            color_number3 += CommandArray[index].ToString();
                        }
                    }
                    color[0] = Convert.ToInt32(color_number1);
                    color[1] = Convert.ToInt32(color_number2);
                    color[2] = Convert.ToInt32(color_number3);
                    foreach (var color_num in color)
                    {
                        if (color_num < 0 || color_num >= 255)
                        {
                            Console.WriteLine("Ошибка!Номер цвета должен находиться в диапазоне от 0 до 255");
                            return tuple_parse0;
                        }
                    }
                }
                else
                    if (CommandArray[1] == '2')
                {
                    tuple_parse0 = (0, set_parameters0, color0);
                    set_parameters = new int[2];
                    for (int index = 3; index < CommandArray.Length - 1; index++)
                    {
                        if (index == 3 || index == 4 || index == 5)
                        {
                            parameter1 += CommandArray[index].ToString();
                        }
                        else
                             if (index == 6 || index == 7 || index == 8)
                        {
                            parameter2 += CommandArray[index].ToString();
                        }
                        else
                            if (index == 9 || index == 10 || index == 11)
                        {
                            color_number1 += CommandArray[index].ToString();
                        }
                        else
                             if (index == 12 || index == 13 || index == 14)
                        {
                            color_number2 += CommandArray[index].ToString();
                        }
                        else
                             if (index == 15 || index == 16 || index == 17)
                        {
                            color_number3 += CommandArray[index].ToString();
                        }
                    }
                    set_parameters[0] = Convert.ToInt32(parameter1);
                    set_parameters[1] = Convert.ToInt32(parameter2);
                    color[0] = Convert.ToInt32(color_number1);
                    color[1] = Convert.ToInt32(color_number2);
                    color[2] = Convert.ToInt32(color_number3);
                    foreach (var parameter in set_parameters)
                    {
                        if (parameter < 0 || parameter > 255)
                        {
                            Console.WriteLine("Ошибка!Параметры должны находиться в диапазоне от 0 до 255");
                            return tuple_parse0;
                        }
                    }
                    foreach (var color_num in color)
                    {
                        if (color_num < 0 || color_num > 255)
                        {
                            Console.WriteLine("Ошибка!Номер цвета должен находиться в диапазоне от 0 до 255");
                            return tuple_parse0;
                        }
                    }
                }
                else
                {
                    set_parameters = new int[4];
                    tuple_parse0 = (0, set_parameters0_2, color0);
                    for (int index = 3; index < CommandArray.Length - 1; index++)
                    {
                        if (index == 3 || index == 4 || index == 5)
                        {
                            parameter1 += CommandArray[index].ToString();
                        }
                        else
                             if (index == 6 || index == 7 || index == 8)
                        {
                            parameter2 += CommandArray[index].ToString();
                        }
                        else
                             if (index == 9 || index == 10 || index == 11)
                        {
                            parameter3 += CommandArray[index].ToString();
                        }
                        else
                            if (index == 12 || index == 13 || index == 14)
                        {
                            parameter4 += CommandArray[index].ToString();
                        }
                        else
                            if (index == 15 || index == 16 || index == 17)
                        {
                            color_number1 += CommandArray[index].ToString();
                        }
                        else
                             if (index == 18 || index == 19 || index == 20)
                        {
                            color_number2 += CommandArray[index].ToString();
                        }
                        else
                             if (index == 21 || index == 22 || index == 23)
                        {
                            color_number3 += CommandArray[index].ToString();
                        }
                    }
                    set_parameters[0] = Convert.ToInt32(parameter1);
                    set_parameters[1] = Convert.ToInt32(parameter2);
                    set_parameters[2] = Convert.ToInt32(parameter3);
                    set_parameters[3] = Convert.ToInt32(parameter4);
                    color[0] = Convert.ToInt32(color_number1);
                    color[1] = Convert.ToInt32(color_number2);
                    color[2] = Convert.ToInt32(color_number3);
                    foreach (var parameter in set_parameters)
                    {
                        if (parameter < 0 || parameter > 255)
                        {
                            Console.WriteLine("Ошибка!Параметры должны находиться в диапазоне от 0 до 255");
                            return tuple_parse0;
                        }
                    }
                    foreach (var color_num in color)
                    {
                        if (color_num < 0 || color_num > 255)
                        {
                            Console.WriteLine("Ошибка!Номер цвета должен находиться в диапазоне от 0 до 255");
                            return tuple_parse0;
                        }
                    }
                }
                var tuple_parse = (CommandNumber, set_parameters, color);
                return tuple_parse;
            }
            else
            {
                Console.WriteLine("Ошибка! Введены неправильные символы начала/конца команды!");
                return tuple_parse0;
            }
        }
        string[] split_string(string str, int interval)
        {
            List<string> substrs = new List<string>();
            int i;
            for (i = 0; i < str.Length - interval; i += interval)
            {
                substrs.Add(str.Substring(i, interval));
            }
            substrs.Add(str.Substring(i));
            return substrs.ToArray();
        }
    }

}
