using System;
using System.Collections.Generic;
using RubiksCubeHasher;

namespace test
{
    class Program
    {
        static void CreateTurnsList()
        {
            string[][] turns = new string[][] {
                new string[] { "R ", "R'", "R2" },
                new string[] { "L ", "L'", "L2" },
                new string[] { "U ", "U'", "U2" },
                new string[] { "D ", "D'", "D2" },
                new string[] { "F ", "F'", "F2" },
                new string[] { "B ", "B'", "B2" }
            };
            Console.Write("new string[] {\"");
            for (int i = 0; i < 6; i++)
            {
                foreach (var e in turns[i])
                {
                    bool isChet = i % 2 == 0;
                    for (int j = 0; j < 6; j++)
                    {
                        if (j != i && (i - 1 != j || isChet))
                        {
                            foreach (var e1 in turns[j])
                            {
                                Console.Write(e + "\", \"" + e1 + "\"}, new string[] {\"");
                            }
                        }
                    }
                }
            }
            foreach (var e in turns)
            {
                foreach (var e1 in e)
                {
                    Console.Write(e1 + "\"}, new string[] {\"");
                }
            }
        }

        class MyInt
        {
            public int Value { 
                get 
                { 
                    return Value; 
                } 
                set
                {
                    if(value > 255)
                    {
                        Value = 0;
                    }
                    else if(value < 0)
                    {
                        Value = 0;
                    }
                    else
                    {
                        Value = value;
                    }
                } 
            }
        }

        static void Main()
        {
            Hasher hasher = new Hasher("Hello, my name is Azim, i am 15 and I hate my life");
            List<char> word = new List<char>();
            MyInt a = new MyInt();
            a.Value = 0;
            a.Value = a.Value - 1;
            Console.WriteLine(a);
        }
    }
}