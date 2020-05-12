using System;
using System.Linq;
using System.IO;

namespace TRanslators1CS
{
    class Class1
    {
        static void Main(string[] args)
        {
            string pathToInput = args.First();
            Outputer.SetPath(args[1]);
            Transliterator.start(pathToInput);

        }

        class Transliterator
        {
            public static void start(string path)
            {
              
                bool isOK=true;
                if (!File.Exists(path))
                {
                    Console.WriteLine("Входной файл не найден");
                    System.Environment.Exit(1);
                }
                

                string[] allText = File.ReadAllLines(path);      //Получаем все строки
                int row = 0;                                //Номер строки
                foreach (string str in allText)             //Идём по каждой строке
                {
                    row++;
                    string[] line = str.Split(' ');      //Получаем все слова 
                    foreach (string word in line)
                    {
                        if (isAdd(word)) { Outputer.WriteToFile(row, word, "Adding"); continue; }
                        if (isDiv(word)) { Outputer.WriteToFile(row, word, "Dividing"); continue; }
                        if (isMul(word)) { Outputer.WriteToFile(row, word, "Multiplying"); continue; }
                        if (isMod(word)) { Outputer.WriteToFile(row, word, "division with remainder"); continue; }
                        if (isEqual(word)) { Outputer.WriteToFile(row, word, "equal"); continue; }
                        if (isLet(word)) { Outputer.WriteToFile(row, word, "equating"); continue; }
                        if (isNot(word)) { Outputer.WriteToFile(row, word, "Not_equal"); continue; }
                        if (isRRB(word)) { Outputer.WriteToFile(row, word, "}"); continue; }
                        if (isLRB(word)) { Outputer.WriteToFile(row, word, "Left_R_Brace}"); continue; }
                        if (isDecimal(word)) { Outputer.WriteToFile(row, word, "Decimal"); continue; }
                        if (isBin(word)) { Outputer.WriteToFile(row, word, "Bin"); continue; }
                        if(isOctal(word)) { Outputer.WriteToFile(row, word, "Octal"); continue; }
                        if (isHex(word)) { Outputer.WriteToFile(row, word, "Hex"); continue; }
                        Outputer.WriteToFile(row, word, "Error");
                        isOK = false;
                        Console.WriteLine("Error:" + "row" + row + "word-" + word +":Unknown word") ;
                    }
                    if (isOK) { Console.WriteLine("Ok"); }
                }
            }
            public static bool isAdd(string ch)
            {
                if (string.Compare(ch, "Add", true) == 0)
                {
                    return true;
                }
                return false;
            }

            static bool isDecimal(string ch)
            {
                if (ch[0] == '1' && ch[1] == '0' && ch[2] == '#')
                {
                    bool isNumber = true;
                    for (int i = 3; i < ch.Length; i++)
                    {
                        if (ch[i] <= 0 && ch[i] >= 9) //если не входят в диапазон=опускаем флаг
                        {
                            isNumber = false;
                        }
                    }
                    if (isNumber) return true; else return false;
                }
                return false;
            }
            static bool isBin(string ch)
            {
                if (ch[0] == '2' && ch[1] == '#')
                {
                    bool isNumber = true;
                    for (int i = 2; i < ch.Length; i++)
                    {
                        if (ch[i] <= 0 && ch[i] >= 1) //если не входят в диапазон=опускаем флаг
                        {
                            isNumber = false;
                        }
                    }
                    if (isNumber) return true; else return false;
                }
                return false;
            }
        }
        static bool isOctal(string ch)
        {
            if (ch[0] == '8' && ch[1] == '#')
            {
                bool isNumber = true;
                for (int i = 2; i < ch.Length; i++)
                {
                    if (ch[i] <= 0 && ch[i] >= 8) //если не входят в диапазон=опускаем флаг
                    {
                        isNumber = false;
                    }
                }
                if (isNumber) return true; else return false;
            }
            return false;
        }

        static bool isHex(string ch)
        {
            if (ch[0] == '1' && ch[1] == '6' && ch[2] == '#')
            {
                bool isNumber = true;
                for (int i = 3; i < ch.Length; i++)
                {
                    if ((ch[i] >= '0' && ch[i] <= '9') ||         //если не входят в диапазон=опускаем флаг
                        (ch[i] >= 'A' && ch[i] <= 'F') ||
                        (ch[i] >= 'a' && ch[i] <= 'f'))
                    {
                        isNumber = false;
                    }
                }
                if (isNumber) return true; else return false;
            }
            return false;
        }
        public static bool isMin(string ch)
            {
                if (string.Compare(ch, "min", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isMul(string ch)
            {
                if (string.Compare(ch, "mul", true) == 0)
                {
                    return true;
                }
                return false;
            }

            public static bool isDiv(string ch)
            {
                if (string.Compare(ch, "Div", true) == 0)
                {
                    return true;
                }
                return false;
            }

            public static bool isMod(string ch)
            {
                if (string.Compare(ch, "mod", true) == 0)
                {
                    return true;
                }
                return false;
            }

            public static bool isEqual(string ch)
            {
                if (string.Compare(ch, "EQ", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isNot(string ch)
            {
                if (string.Compare(ch, "NE", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isLess(string ch)
            {
                if (string.Compare(ch, "LT", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isMore(string ch)
            {
                if (string.Compare(ch, "GT", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isLet(string ch)
            {
                if (string.Compare(ch, "Let", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isLBox(string ch)
            {
                if (string.Compare(ch, "box", true) == 0)
                {
                    return true;
                }
                return false;
            }

            public static bool isEnd(string ch)
            {
                if (string.Compare(ch, "end", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isCast(string ch)
            {
                if (string.Compare(ch, "Cast", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isInt(string ch)
            {
                if (string.Compare(ch, "int", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isReal(string ch)
            {
                if (string.Compare(ch, "real", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isId(string ch)
            {
                if (string.Compare(ch, "id", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isLRB(string ch)
            {
                if (string.Compare(ch, "LRB", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isRRB(string ch)
            {
                if (string.Compare(ch, "RRB", true) == 0)
                {
                    return true;
                }
                return false;
            }
            public static bool isLSB(string ch)
            {
                if (string.Compare(ch, "LSB", true) == 0)
                {
                    return true;
                }
                return false;
            }
            


            


             

            }
        abstract class Outputer
        {
            public static string path;

            public static void SetPath(string Path)
            {
                path = Path;
            }

            public static void WriteToFile(int row, string lexema, string type)
            
            {
                File.AppendAllText(path, row + "_lex:" + type + ':' + lexema + "\n");
            }
        }
    }








