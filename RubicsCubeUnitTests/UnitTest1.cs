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
            string res = cube.RContr();
            Assert.AreEqual("yybbbyyywwgggwwwggyyygggbbwwwbbboooooooorrrrrrrr", cube.ToString());
            Assert.AreEqual("R'", res);
        }
    }
}