using System;
using RubiksCubeHasher;

namespace test
{
    class Program
    {
        static void Main()
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
            for(int i = 0; i < 6; i++)
            {
                foreach(var e in turns[i])
                {
                    bool isChet = i % 2 == 0;
                    for(int j = 0; j < 6; j++)
                    {
                        if(j != i && (i - 1 != j || isChet))
                        {
                            foreach(var e1 in turns[j])
                            {
                                Console.Write(e + "\", \"" + e1 + "\"}, new string[] {\"");
                            }
                        }
                    }
                }
            }
            foreach(var e in turns)
            {
                foreach(var e1 in e)
                {
                    Console.Write(e1 + "\"}, new string[] {\"");
                }
            }
        }
    }
}