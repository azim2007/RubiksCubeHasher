using NUnit.Framework;
using RubiksCubeHasher;

namespace RubicsCubeUnitTests
{
    [TestFixture]
    public class CubeTest
    {
        [Test]
        public void DefaultConstructAndToString()
        {
            Cube cube = new Cube();
            Assert.AreEqual("yyyyyyyywwwwwwwwggggggggbbbbbbbboooooooorrrrrrrr", cube.ToString());
        }

        [Test]
        public void RTurnTest()
        {
            Cube cube = new Cube();
            string res = cube.R();
            Assert.AreEqual("yygggyyywwbbbwwwggwwwgggbbyyybbboooooooorrrrrrrr", cube.ToString());
            Assert.AreEqual("R ", res);
        }

        [Test]
        public void RContrTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.RContr();
            cube.R();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("R'", res);
        }

        [Test]
        public void RDoubleTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.RDouble();
            cube.R();
            cube.R();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("R2", res);
        }

        [Test]
        public void LTurnTest()
        {
            Cube cube = new Cube();
            string res = cube.L();
            Assert.AreEqual("byyyyybbgwwwwwggygggggyywbbbbbwwoooooooorrrrrrrr", cube.ToString());
            Assert.AreEqual("L ", res);
        }

        [Test]
        public void LContrTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.LContr();
            cube.L();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("L'", res);
        }

        [Test]
        public void LDoubleTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.LDouble();
            cube.L();
            cube.L();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("L2", res);
        }

        [Test]
        public void UTurnTest()
        {
            Cube cube = new Cube();
            string res = cube.U();
            Assert.AreEqual("yyyyyyyywwwwwwwwooogggggbbbbrrrbbbbooooogggrrrrr", cube.ToString());
            Assert.AreEqual("U ", res);
        }

        [Test]
        public void UContrTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.UContr();
            cube.U();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("U'", res);
        }

        [Test]
        public void UDoubleTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.UDouble();
            cube.U();
            cube.U();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("U2", res);
        }

        [Test]
        public void DTurnTest()
        {
            Cube cube = new Cube();
            string res = cube.D();
            Assert.AreEqual("yyyyyyyywwwwwwwwggggrrrgooobbbbboooogggorrrrbbbr", cube.ToString());
            Assert.AreEqual("D ", res);
        }

        [Test]
        public void DContrTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.DContr();
            cube.D();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("D'", res);
        }

        [Test]
        public void DDoubleTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.DDouble();
            cube.D();
            cube.D();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("D2", res);
        }

        [Test]
        public void FTurnTest()
        {
            Cube cube = new Cube();
            string res = cube.F();
            Assert.AreEqual("yyyyrrryooowwwwwggggggggbbbbbbbbyoooooyyrrwwwrrr", cube.ToString());
            Assert.AreEqual("F ", res);
        }

        [Test]
        public void FContrTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.FContr();
            cube.F();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("F'", res);
        }

        [Test]
        public void FDoubleTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.FDouble();
            cube.F();
            cube.F();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("F2", res);
        }

        [Test]
        public void BTurnTest()
        {
            Cube cube = new Cube();
            string res = cube.B();
            Assert.AreEqual("oooyyyyywwwwrrrwggggggggbbbbbbbboowwwoooyrrrrryy", cube.ToString());
            Assert.AreEqual("B ", res);
        }

        [Test]
        public void BContrTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.BContr();
            cube.B();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("B'", res);
        }

        [Test]
        public void BDoubleTurnTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            string res = cube.BDouble();
            cube.B();
            cube.B();
            Assert.AreEqual(cube1.ToString(), cube.ToString());
            Assert.AreEqual("B2", res);
        }
    }

    [TestFixture]
    class ScrambleFunctoinTest
    {
        public void Test(string scramble, string cubeToString)
        {
            var scr = scramble.Split(" ");
            Cube cube = new Cube();
            cube.ScrambleCube(new System.Collections.Generic.List<string>(scr));
            Assert.AreEqual(cube.ToString(), cubeToString);
        }
        [Test]
        public void SixPifPafTest()
        {
            Cube cube = new Cube();
            Cube cube1 = new Cube();
            cube.ScrambleCube(new System.Collections.Generic.List<string> { "R ", "U ", "R'", "U'", "R ", "U ", "R'", "U'", "R ", "U ", "R'", "U'", "R ", "U ", "R'", "U'", "R ", "U ", "R'", "U'", "R ", "U ", "R'", "U'" });
            Assert.AreEqual(cube1.ToString(), cube.ToString());
        }

        [Test]
        public void LambdaTest()
        {
            Cube cube = new Cube();
            cube.ScrambleCube(new System.Collections.Generic.List<string> { "R ", "U ", "R'", "F'", "R ", "U ", "R'", "U'", "R'", "F ", "R2", "U'", "R'", "U'" });
            Assert.AreEqual(cube.ToString(), "yyyyyyyywwwwwwwwgoogggggbbbbobbbbggooooorrrrrrrr");
        }

        [Test]
        public void KopioTest()
        {
            Cube cube = new Cube();
            cube.ScrambleCube(new System.Collections.Generic.List<string> { "F ", "R ", "U'", "R'", "U'", "R ", "U ", "R'", "F'", "R ", "U ", "R'", "U'", "R'", "F ", "R ", "F'" });
            Assert.AreEqual(cube.ToString(), "yyyyyyyywwwwwwwwggbgggggbbbbbrgbroooooooobrrrrrr");
        }

        [Test]
        public void ScramblesTest()
        {
            Test("R D2 B D R B2 R D2 R B2 U B2 U F2 L2 D B2 U D2", "obywywborygyyggbwrrgwgbgowbroybwgogbrrrryyoowowb");
            Test("F2 L2 U2 F2 L2 D F2 U' B2 U2 L2 R B R D' U L D2 U2 F' U", "ggwyrrbryobbbryrwygoywobowwggwryyboororywgowbbgg");
        }
    }

    [TestFixture]
    class HasherTest
    {
        [Test]
        public void turnListCountTest()
        {
            Assert.AreEqual(new Hasher("").turnsListCount, 256);
        }

        [Test]
        public void HasherEqualsFunctionTest()
        {
            Hasher hasher = new Hasher("Hello world!");
            Assert.AreEqual(hasher.Equals("Hello world!"), true);
            Assert.AreEqual(hasher.Equals("hello world!"), false);
            Assert.AreEqual(hasher.Equals("hello-world!"), false);
            hasher = new Hasher("Hello world!", 42);
            Assert.AreEqual(hasher.Equals("Hello world!"), true);
            Assert.AreEqual(hasher.Equals("hello world!"), false);
            Assert.AreEqual(hasher.Equals("hello-world!"), false);
            hasher = new Hasher("Hello, my name is Azim", 12);
            Assert.AreEqual(hasher.Equals("Hello, my name is Azim"), true);
            Assert.AreEqual(hasher.Equals("hello Azim!"), false);
            Assert.AreEqual(hasher.Equals("hello-world!"), false);
        }

        [Test]
        public void HasherEqualsUtf16FunctionTest()
        {
            Hasher hasher = new Hasher("рузкие букавы");
            Assert.AreEqual(hasher.Equals("рузкие букавы"), true);
            Assert.AreEqual(hasher.Equals("англизкие букавы"), false);
            Assert.AreEqual(hasher.Equals("hehey1234"), false);
            hasher = new Hasher("我叫伊拉。 我是学生。 我在大学学习外语", 42);
            Assert.AreEqual(hasher.Equals("我叫伊拉。 我是学生。 我在大学学习外语"), true);
            Assert.AreEqual(hasher.Equals("чо то на китаянском"), false);
            Assert.AreEqual(hasher.Equals("ohhhh shit"), false);
            hasher = new Hasher("😀😁😂🤣", 12);
            Assert.AreEqual(hasher.Equals("😀😁😂🤣"), true);
            Assert.AreEqual(hasher.Equals("опа.. смайлики!"), false);
            Assert.AreEqual(hasher.Equals("ahahahahahah"), false);
        }
    }
}