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
    class HasherTest
    {
        [Test]
        public void turnListCountTest()
        {
            Assert.AreEqual(new Hasher("").turnsListCount, 256);
        }
    }
}