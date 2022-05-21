using System;
using RubiksCubeHasher;

namespace test
{
    class Program
    {
        static void Main()
        {
            Cube cube = new Cube();
            Console.WriteLine(cube);
            cube.R();
            Console.WriteLine(cube);

        }
    }
}