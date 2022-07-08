using System;
using System.Collections.Generic;
using RubiksCubeHasher;

namespace test
{
    class Program
    {
        static void Main()
        {
            //Hasher hasher = new Hasher("Hello, my name is Azim, i am 15 and I hate my life", 10);
            //Console.WriteLine(hasher.Hash);
            Hasher.createTurnsList();
            Console.WriteLine("done");
            Hasher.loadTurnsList();
            Console.WriteLine("done");
            Hasher hasher = new Hasher("фывоафвыиррйцукенгшщзхъфывапролджэячсмитьбю 我叫伊拉。 我是学生。 我在大学学习外语 😄😋😚😋😋😊😊😊");
            Console.WriteLine(hasher.Hash);
            hasher = new Hasher("фывоафвыиррйцукенгшщзхъфывапролджэячсмитьбю 我叫伊拉。 我是学生。 我在大学学习外语 😄😋😚😋😋😊😊");
            Console.WriteLine(hasher.Hash);
        }
    }
}