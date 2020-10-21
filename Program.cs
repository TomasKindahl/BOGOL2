using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BOGOL2
{
    class Program
    {
        static int GetValue(int[] var, string val)
        {
            switch (val)
            {
                case "a": return var[0];
                case "b": return var[1];
                case "c": return var[2];
                case "d": return var[3];
                case "e": return var[4];
                default: return int.Parse(val);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to BOGOL!");
            Console.WriteLine("Quit by writing 'quit'!");
            string command;
            string[] cword;
            int[] var = new int[5];
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                cword = command.Split(' ');
                if (cword[0] == "set" && cword[2] == "=")
                {
                    if (cword.Length == 6)
                    {
                        int res, res1, res2;
                        bool varOK = true, opOK = true;
                        res1 = GetValue(var, cword[3]);
                        res2 = GetValue(var, cword[5]);
                        switch (cword[4])
                        {
                            case "+": res = res1 + res2; break;
                            case "-": res = res1 - res2; break;
                            case "*": res = res1 * res2; break;
                            case "/": res = res1 / res2; break;
                            case "%": res = res1 % res2; break;
                            default: opOK = false; res = -1; break;
                        }
                        if (opOK)
                        {
                            varOK = true;
                            switch (cword[1])
                            {
                                case "a": var[0] = res; break;
                                case "b": var[1] = res; break;
                                case "c": var[2] = res; break;
                                case "d": var[3] = res; break;
                                case "e": var[4] = res; break;
                                default: varOK = false; break;
                            }
                            if (varOK)
                            {
                                Console.WriteLine("variable {0} now has the value {1}",
                                    cword[1], res);
                            }
                            else
                            {
                                Console.WriteLine("No such operator!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No such variable!");
                        }
                    }
                    else if (cword.Length == 4)
                    {
                        bool OK = true;
                        switch (cword[1])
                        {
                            case "a": var[0] = GetValue(var, cword[3]); break;
                            case "b": var[1] = GetValue(var, cword[3]); break;
                            case "c": var[2] = GetValue(var, cword[3]); break;
                            case "d": var[3] = GetValue(var, cword[3]); break;
                            case "e": var[4] = GetValue(var, cword[3]); break;
                            default: OK = false; break;
                        }
                        if (OK)
                        {
                            Console.WriteLine("variable {0} now has the value {1}", cword[1], cword[3]);
                        }
                        else
                        {
                            Console.WriteLine("No such variable!");
                        }
                    }
                }
                else if (cword[0] == "print")
                {
                    switch (cword[1])
                    {
                        case "a": Console.WriteLine(var[0]); break;
                        case "b": Console.WriteLine(var[1]); break;
                        case "c": Console.WriteLine(var[2]); break;
                        case "d": Console.WriteLine(var[3]); break;
                        case "e": Console.WriteLine(var[4]); break;
                        case "all":
                            Console.WriteLine("a = {0}", var[0]);
                            Console.WriteLine("b = {0}", var[1]);
                            Console.WriteLine("c = {0}", var[2]);
                            Console.WriteLine("d = {0}", var[3]);
                            Console.WriteLine("e = {0}", var[4]);
                            break;
                        default: Console.WriteLine(cword[1]); break;
                    }
                }
                else if (cword[0] == "quit") ;
                else
                {
                    Console.WriteLine("unknown command: {0}", command);
                }
            } while (cword[0] != "quit");
            Console.WriteLine("Goodbye!");
        }
    }
}