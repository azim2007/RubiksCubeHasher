using System;
using System.Collections.Generic;

namespace RubiksCubeHasher
{
    public enum Color
    {
        white,
        yellow,
        green,
        blue,
        orange,
        red
    }

    public class Side
    {
        public Color UpEdge { get; set; }
        public Color RightEdge { get; set; }
        public Color DownEdge { get; set; }
        public Color LeftEdge { get; set; }
        public Color UpRightAngle { get; set; }
        public Color UpLeftAngle { get; set; }
        public Color DownLeftAngle { get; set; }
        public Color DownRightAngle { get; set; }
        public Side() { }

        /// <summary>
        /// конструктор для создания одноцветной стороны
        /// </summary>
        /// <param name="color">цвет, который присваивается всем элементам стороны</param>
        public Side(Color color)
        {
            this.UpLeftAngle = color;
            this.UpEdge = color;
            this.UpRightAngle = color;
            this.RightEdge = color;
            this.DownRightAngle = color;
            this.DownEdge = color;
            this.DownLeftAngle = color;
            this.LeftEdge = color;
        }

        /// <summary>
        /// элементы в массиве должны идти от верхнего левого угла до левого ребра по часовой стрелке
        /// </summary>
        /// <param name="colors"> массив цветов размером 8, каждый из которых присваивается определанному элементу стороны</param>
        public Side(Color[] colors)
        {
            if (colors.Length != 8)
            {
                throw new InvalidOperationException("количество аргументов, передаваемых в конструктор должно быть равно 8, а у вас " + colors.Length);
            }

            this.UpLeftAngle = colors[0];
            this.UpEdge = colors[1];
            this.UpRightAngle = colors[2];
            this.RightEdge = colors[3];
            this.DownRightAngle = colors[4];
            this.DownEdge = colors[5];
            this.DownLeftAngle = colors[6];
            this.LeftEdge = colors[7];
        }

        
        public void ClockwiseTurn()
        {
            Color swap = UpEdge;
            UpEdge = LeftEdge;
            LeftEdge = DownEdge;
            DownEdge = RightEdge;
            RightEdge = swap;
            swap = UpLeftAngle;
            UpLeftAngle = DownLeftAngle;
            DownLeftAngle = DownRightAngle;
            DownRightAngle = UpRightAngle;
            UpRightAngle = swap;
        }

        public void ContrClockwiseTurn()
        {
            Color swap = UpEdge;
            UpEdge = RightEdge;
            RightEdge = DownEdge;
            DownEdge = LeftEdge;
            LeftEdge = swap;
            swap = UpLeftAngle;
            UpLeftAngle = UpRightAngle;
            UpRightAngle = DownRightAngle;
            DownRightAngle = DownLeftAngle;
            DownLeftAngle = swap;
        }

        public void DoubleTurn()
        {
            Color swap = UpEdge;
            UpEdge = DownEdge;
            DownEdge = swap;
            swap = RightEdge;
            RightEdge = LeftEdge;
            LeftEdge = swap;
            swap = UpLeftAngle;
            UpLeftAngle = DownRightAngle;
            DownRightAngle = swap;
            swap = UpRightAngle;
            UpRightAngle = DownLeftAngle;
            DownLeftAngle = swap;
        }

        public override string ToString()
        {
            string[] indexes = new string[] { "w", "y", "g", "b", "o", "r" };
            return indexes[(int)UpLeftAngle] + indexes[(int)UpEdge] + indexes[(int)UpRightAngle] + indexes[(int)RightEdge] + indexes[(int)DownRightAngle] + indexes[(int)DownEdge] + indexes[(int)DownLeftAngle] + indexes[(int)LeftEdge];
        }
    }

    public class Cube
    {
        /// <summary>
        /// конструктор по умолчанию, создает полностью собранный куб, настоятельно рекомендуется использовать этот конструктор при создании куба
        /// </summary>
        public Cube()
        {
            whiteSide = new Side(Color.white);
            yellowSide = new Side(Color.yellow);
            greenSide = new Side(Color.green);
            blueSide = new Side(Color.blue);
            orangeSide = new Side(Color.orange);
            redSide = new Side(Color.red);
        }

        /// <summary>
        /// конструктор для создания куба с заданными сторонами, стороны задаются в следующем порядке: белая, желтая, зеленая, синяя, оранжевая, красная
        /// </summary>
        /// <param name="sides">массив сторон</param>
        public Cube(Side[] sides)
        {
            if (sides.Length != 6)
            {
                throw new InvalidOperationException("количество аргументов, передаваемых в конструктор должно быть равно 6, а у вас " + sides.Length);
            }

            void FillSide(int index, ref Side side)
            {
                side = new Side(new Color[] { sides[index].UpLeftAngle, sides[index].UpEdge, sides[index].UpRightAngle, sides[index].RightEdge, sides[index].DownRightAngle, sides[index].DownEdge, sides[index].DownLeftAngle, sides[index].LeftEdge });
            }

            FillSide(0, ref whiteSide);
            FillSide(1, ref yellowSide);
            FillSide(2, ref greenSide);
            FillSide(3, ref blueSide);
            FillSide(4, ref orangeSide);
            FillSide(5, ref redSide);
        }
        private Side whiteSide;
        private Side yellowSide;
        private Side greenSide;
        private Side blueSide;
        private Side orangeSide;
        private Side redSide;
        public string R()
        {
            orangeSide.ClockwiseTurn();
            Color swap = greenSide.UpRightAngle;
            greenSide.UpRightAngle = whiteSide.UpRightAngle;
            whiteSide.UpRightAngle = blueSide.UpRightAngle;
            blueSide.UpRightAngle = yellowSide.UpRightAngle;
            yellowSide.UpRightAngle = swap;
            swap = greenSide.RightEdge;
            greenSide.RightEdge = whiteSide.RightEdge;
            whiteSide.RightEdge = blueSide.RightEdge;
            blueSide.RightEdge = yellowSide.RightEdge;
            yellowSide.RightEdge = swap;
            swap = greenSide.DownRightAngle;
            greenSide.DownRightAngle = whiteSide.DownRightAngle;
            whiteSide.DownRightAngle = blueSide.DownRightAngle;
            blueSide.DownRightAngle = yellowSide.DownRightAngle;
            yellowSide.DownRightAngle = swap;
            return "R ";
        }

        public string RContr()
        {
            orangeSide.ContrClockwiseTurn();
            Color swap = greenSide.UpRightAngle;
            greenSide.UpRightAngle = yellowSide.UpRightAngle;
            yellowSide.UpRightAngle = blueSide.UpRightAngle;
            blueSide.UpRightAngle = whiteSide.UpRightAngle;
            whiteSide.UpRightAngle = swap;
            swap = greenSide.RightEdge;
            greenSide.RightEdge = yellowSide.RightEdge;
            yellowSide.RightEdge = blueSide.RightEdge;
            blueSide.RightEdge = whiteSide.RightEdge;
            whiteSide.RightEdge = swap;
            swap = greenSide.DownRightAngle;
            greenSide.DownRightAngle = yellowSide.DownRightAngle;
            yellowSide.DownRightAngle = blueSide.DownRightAngle;
            blueSide.DownRightAngle = whiteSide.DownRightAngle;
            whiteSide.DownRightAngle = swap;
            return "R'";
        }

        public string RDouble()
        {
            orangeSide.DoubleTurn();
            Color swap = greenSide.UpRightAngle;
            greenSide.UpRightAngle = blueSide.UpRightAngle;
            blueSide.UpRightAngle = swap;
            swap = whiteSide.UpRightAngle;
            whiteSide.UpRightAngle = yellowSide.UpRightAngle;
            yellowSide.UpRightAngle = swap;
            swap = greenSide.RightEdge;
            greenSide.RightEdge = blueSide.RightEdge;
            blueSide.RightEdge = swap;
            swap = whiteSide.RightEdge;
            whiteSide.RightEdge = yellowSide.RightEdge;
            yellowSide.RightEdge = swap;
            swap = greenSide.DownRightAngle;
            greenSide.DownRightAngle = blueSide.DownRightAngle;
            blueSide.DownRightAngle = swap;
            swap = whiteSide.DownRightAngle;
            whiteSide.DownRightAngle = yellowSide.DownRightAngle;
            yellowSide.DownRightAngle = swap;
            return "R2";
        }

        public string L()
        {
            redSide.ClockwiseTurn();
            Color swap = greenSide.UpLeftAngle;
            greenSide.UpLeftAngle = yellowSide.UpLeftAngle;
            yellowSide.UpLeftAngle = blueSide.UpLeftAngle;
            blueSide.UpLeftAngle = whiteSide.UpLeftAngle;
            whiteSide.UpLeftAngle = swap;
            swap = greenSide.LeftEdge;
            greenSide.LeftEdge = yellowSide.LeftEdge;
            yellowSide.LeftEdge = blueSide.LeftEdge;
            blueSide.LeftEdge = whiteSide.LeftEdge;
            whiteSide.LeftEdge = swap;
            swap = greenSide.DownLeftAngle;
            greenSide.DownLeftAngle = yellowSide.DownLeftAngle;
            yellowSide.DownLeftAngle = blueSide.DownLeftAngle;
            blueSide.DownLeftAngle = whiteSide.DownLeftAngle;
            whiteSide.DownLeftAngle = swap;
            return "L ";
        }

        public string LContr()
        {
            redSide.ContrClockwiseTurn();
            Color swap = greenSide.UpLeftAngle;
            greenSide.UpLeftAngle = whiteSide.UpLeftAngle;
            whiteSide.UpLeftAngle = blueSide.UpLeftAngle;
            blueSide.UpLeftAngle = yellowSide.UpLeftAngle;
            yellowSide.UpLeftAngle = swap;
            swap = greenSide.LeftEdge;
            greenSide.LeftEdge = whiteSide.LeftEdge;
            whiteSide.LeftEdge = blueSide.LeftEdge;
            blueSide.LeftEdge = yellowSide.LeftEdge;
            yellowSide.LeftEdge = swap;
            swap = greenSide.DownLeftAngle;
            greenSide.DownLeftAngle = whiteSide.DownLeftAngle;
            whiteSide.DownLeftAngle = blueSide.DownLeftAngle;
            blueSide.DownLeftAngle = yellowSide.DownLeftAngle;
            yellowSide.DownLeftAngle = swap;
            return "L'";
        }

        public string LDouble()
        {
            redSide.DoubleTurn();
            Color swap = greenSide.UpLeftAngle;
            greenSide.UpLeftAngle = blueSide.UpLeftAngle;
            blueSide.UpLeftAngle = swap;
            swap = whiteSide.UpLeftAngle;
            whiteSide.UpLeftAngle = yellowSide.UpLeftAngle;
            yellowSide.UpLeftAngle = swap;
            swap = greenSide.LeftEdge;
            greenSide.LeftEdge = blueSide.LeftEdge;
            blueSide.LeftEdge = swap;
            swap = whiteSide.LeftEdge;
            whiteSide.LeftEdge = yellowSide.LeftEdge;
            yellowSide.LeftEdge = swap;
            swap = greenSide.DownLeftAngle;
            greenSide.DownLeftAngle = blueSide.DownLeftAngle;
            blueSide.DownLeftAngle = swap;
            swap = whiteSide.DownLeftAngle;
            whiteSide.DownLeftAngle = yellowSide.DownLeftAngle;
            yellowSide.DownLeftAngle = swap;
            return "L2";
        }

        public string U()
        {
            UContr();
            UContr();
            UContr();
            return "U ";
        }

        public string UContr()
        {
            yellowSide.ContrClockwiseTurn();
            Color swap = greenSide.UpRightAngle;
            greenSide.UpRightAngle = redSide.UpRightAngle;
            redSide.UpRightAngle = blueSide.DownLeftAngle;
            blueSide.DownLeftAngle = orangeSide.UpRightAngle;
            orangeSide.UpRightAngle = swap;
            swap = greenSide.UpLeftAngle;
            greenSide.UpLeftAngle = redSide.UpLeftAngle;
            redSide.UpLeftAngle = blueSide.DownRightAngle;
            blueSide.DownRightAngle = orangeSide.UpLeftAngle;
            orangeSide.UpLeftAngle = swap;
            swap = greenSide.UpEdge;
            greenSide.UpEdge = redSide.UpEdge;
            redSide.UpEdge = blueSide.DownEdge;
            blueSide.DownEdge = orangeSide.UpEdge;
            orangeSide.UpEdge = swap;
            return "U'";
        }

        public string UDouble()
        {
            yellowSide.DoubleTurn();
            Color swap = greenSide.UpRightAngle;
            greenSide.UpRightAngle = blueSide.DownLeftAngle;
            blueSide.DownLeftAngle = swap;
            swap = orangeSide.UpRightAngle;
            orangeSide.UpRightAngle = redSide.UpRightAngle;
            redSide.UpRightAngle = swap;
            swap = greenSide.UpLeftAngle;
            greenSide.UpLeftAngle = blueSide.DownRightAngle;
            blueSide.DownRightAngle = swap;
            swap = orangeSide.UpLeftAngle;
            orangeSide.UpLeftAngle = redSide.UpLeftAngle;
            redSide.UpLeftAngle = swap;
            swap = greenSide.UpEdge;
            greenSide.UpEdge = blueSide.DownEdge;
            blueSide.DownEdge = swap;
            swap = orangeSide.UpEdge;
            orangeSide.UpEdge = redSide.UpEdge;
            redSide.UpEdge = swap;
            return "U2";
        }

        public string D()
        {
            whiteSide.ClockwiseTurn();
            Color swap = greenSide.DownRightAngle;
            greenSide.DownRightAngle = redSide.DownRightAngle;
            redSide.DownRightAngle = blueSide.UpLeftAngle;
            blueSide.UpLeftAngle = orangeSide.DownRightAngle;
            orangeSide.DownRightAngle = swap;
            swap = greenSide.DownLeftAngle;
            greenSide.DownLeftAngle = redSide.DownLeftAngle;
            redSide.DownLeftAngle = blueSide.UpRightAngle;
            blueSide.UpRightAngle = orangeSide.DownLeftAngle;
            orangeSide.DownLeftAngle = swap;
            swap = greenSide.DownEdge;
            greenSide.DownEdge = redSide.DownEdge;
            redSide.DownEdge = blueSide.UpEdge;
            blueSide.UpEdge = orangeSide.DownEdge;
            orangeSide.DownEdge = swap;
            return "D ";
        }

        public string DContr()
        {
            whiteSide.ContrClockwiseTurn();
            Color swap = greenSide.DownRightAngle;
            greenSide.DownRightAngle = orangeSide.DownRightAngle;
            orangeSide.DownRightAngle = blueSide.UpLeftAngle;
            blueSide.UpLeftAngle = redSide.DownRightAngle;
            redSide.DownRightAngle = swap;
            swap = greenSide.DownLeftAngle;
            greenSide.DownLeftAngle = orangeSide.DownLeftAngle;
            orangeSide.DownLeftAngle = blueSide.UpRightAngle;
            blueSide.UpRightAngle = redSide.DownLeftAngle;
            redSide.DownLeftAngle = swap;
            swap = greenSide.DownEdge;
            greenSide.DownEdge = orangeSide.DownEdge;
            orangeSide.DownEdge = blueSide.UpEdge;
            blueSide.UpEdge = redSide.DownEdge;
            redSide.DownEdge = swap;
            return "D'";
        }

        public string DDouble()
        {
            whiteSide.DoubleTurn();
            Color swap = greenSide.DownRightAngle;
            greenSide.DownRightAngle = blueSide.UpLeftAngle;
            blueSide.UpLeftAngle = swap;
            swap = orangeSide.DownRightAngle;
            orangeSide.DownRightAngle = redSide.DownRightAngle;
            redSide.DownRightAngle = swap;
            swap = greenSide.DownLeftAngle;
            greenSide.DownLeftAngle = blueSide.UpRightAngle;
            blueSide.UpRightAngle = swap;
            swap = orangeSide.DownLeftAngle;
            orangeSide.DownLeftAngle = redSide.DownLeftAngle;
            redSide.DownLeftAngle = swap;
            swap = greenSide.DownEdge;
            greenSide.DownEdge = blueSide.UpEdge;
            blueSide.UpEdge = swap;
            swap = orangeSide.DownEdge;
            orangeSide.DownEdge = redSide.DownEdge;
            redSide.DownEdge = swap;
            return "D2";
        }

        public string F()
        {
            greenSide.ClockwiseTurn();
            Color swap = yellowSide.DownLeftAngle;
            yellowSide.DownLeftAngle = redSide.DownRightAngle;
            redSide.DownRightAngle = whiteSide.UpRightAngle;
            whiteSide.UpRightAngle = orangeSide.UpLeftAngle;
            orangeSide.UpLeftAngle = swap;
            swap = yellowSide.DownRightAngle;
            yellowSide.DownRightAngle = redSide.UpRightAngle;
            redSide.UpRightAngle = whiteSide.UpLeftAngle;
            whiteSide.UpLeftAngle = orangeSide.DownLeftAngle;
            orangeSide.DownLeftAngle = swap;
            swap = yellowSide.DownEdge;
            yellowSide.DownEdge = redSide.RightEdge;
            redSide.RightEdge = whiteSide.UpEdge;
            whiteSide.UpEdge = orangeSide.LeftEdge;
            orangeSide.LeftEdge = swap;
            return "F ";
        }

        public string FContr()
        {
            greenSide.ContrClockwiseTurn();
            Color swap = yellowSide.DownLeftAngle;
            yellowSide.DownLeftAngle = orangeSide.UpLeftAngle;
            orangeSide.UpLeftAngle = whiteSide.UpRightAngle;
            whiteSide.UpRightAngle = redSide.DownRightAngle;
            redSide.DownRightAngle = swap;
            swap = yellowSide.DownRightAngle;
            yellowSide.DownRightAngle = orangeSide.DownLeftAngle;
            orangeSide.DownLeftAngle = whiteSide.UpLeftAngle;
            whiteSide.UpLeftAngle = redSide.UpRightAngle;
            redSide.UpRightAngle = swap;
            swap = yellowSide.DownEdge;
            yellowSide.DownEdge = orangeSide.LeftEdge;
            orangeSide.LeftEdge = whiteSide.UpEdge;
            whiteSide.UpEdge = redSide.RightEdge;
            redSide.RightEdge = swap;
            return "F'";
        }

        public string FDouble()
        {

            F();
            F();
            return "F2";
        }

        public string B()
        {
            blueSide.ClockwiseTurn();
            Color swap = yellowSide.UpLeftAngle;
            yellowSide.UpLeftAngle = orangeSide.UpRightAngle;
            orangeSide.UpRightAngle = whiteSide.DownRightAngle;
            whiteSide.DownRightAngle = redSide.DownLeftAngle;
            redSide.DownLeftAngle = swap;
            swap = yellowSide.UpRightAngle;
            yellowSide.UpRightAngle = orangeSide.DownRightAngle;
            orangeSide.DownRightAngle = whiteSide.DownLeftAngle;
            whiteSide.DownLeftAngle = redSide.UpLeftAngle;
            redSide.UpLeftAngle = swap;
            swap = yellowSide.UpEdge;
            yellowSide.UpEdge = orangeSide.RightEdge;
            orangeSide.RightEdge = whiteSide.DownEdge;
            whiteSide.DownEdge = redSide.LeftEdge;
            redSide.LeftEdge = swap;
            return "B ";
        }

        public string BContr()
        {
            blueSide.ContrClockwiseTurn();
            Color swap = yellowSide.UpLeftAngle;
            yellowSide.UpLeftAngle = redSide.DownLeftAngle;
            redSide.DownLeftAngle = whiteSide.DownRightAngle;
            whiteSide.DownRightAngle = orangeSide.UpRightAngle;
            orangeSide.UpRightAngle = swap;
            swap = yellowSide.UpRightAngle;
            yellowSide.UpRightAngle = redSide.UpLeftAngle;
            redSide.UpLeftAngle = whiteSide.DownLeftAngle;
            whiteSide.DownLeftAngle = orangeSide.DownRightAngle;
            orangeSide.DownRightAngle = swap;
            swap = yellowSide.UpEdge;
            yellowSide.UpEdge = redSide.LeftEdge;
            redSide.LeftEdge = whiteSide.DownEdge;
            whiteSide.DownEdge = orangeSide.RightEdge;
            orangeSide.RightEdge = swap;
            return "B'";
        }

        public string BDouble()
        {
            blueSide.DoubleTurn();
            Color swap = yellowSide.UpLeftAngle;
            yellowSide.UpLeftAngle = whiteSide.DownRightAngle;
            whiteSide.DownRightAngle = swap;
            swap = orangeSide.UpRightAngle;
            orangeSide.UpRightAngle = redSide.DownLeftAngle;
            redSide.DownLeftAngle = swap;
            swap = yellowSide.UpRightAngle;
            yellowSide.UpRightAngle = whiteSide.DownLeftAngle;
            whiteSide.DownLeftAngle = swap;
            swap = orangeSide.DownRightAngle;
            orangeSide.DownRightAngle = redSide.UpLeftAngle;
            redSide.UpLeftAngle = swap;
            swap = yellowSide.UpEdge;
            yellowSide.UpEdge = whiteSide.DownEdge;
            whiteSide.DownEdge = swap;
            swap = orangeSide.RightEdge;
            orangeSide.RightEdge = redSide.LeftEdge;
            redSide.LeftEdge = swap;
            return "B2";
        }

        public override string ToString()
        {
            return yellowSide.ToString() + whiteSide.ToString() + greenSide.ToString() + blueSide.ToString() + orangeSide.ToString() + redSide.ToString();
        }
    }

    /// <summary>
    /// класс для хэширования информации
    /// </summary>
    public class Hasher : IEquatable<string>
    {
        private string[][] turnsList = new string[][] { new string[] { "R ", "L " }, new string[] { "R ", "L'" }, new string[] { "R ", "L2" }, new string[] { "R ", "U " }, new string[] { "R ", "U'" }, new string[] { "R ", "U2" }, new string[] { "R ", "D " }, new string[] { "R ", "D'" }, new string[] { "R ", "D2" }, new string[] { "R ", "F " }, new string[] { "R ", "F'" }, new string[] { "R ", "F2" }, new string[] { "R ", "B " }, new string[] { "R ", "B'" }, new string[] { "R ", "B2" }, new string[] { "R'", "L " }, new string[] { "R'", "L'" }, new string[] { "R'", "L2" }, new string[] { "R'", "U " }, new string[] { "R'", "U'" }, new string[] { "R'", "U2" }, new string[] { "R'", "D " }, new string[] { "R'", "D'" }, new string[] { "R'", "D2" }, new string[] { "R'", "F " }, new string[] { "R'", "F'" }, new string[] { "R'", "F2" }, new string[] { "R'", "B " }, new string[] { "R'", "B'" }, new string[] { "R'", "B2" }, new string[] { "R2", "L " }, new string[] { "R2", "L'" }, new string[] { "R2", "L2" }, new string[] { "R2", "U " }, new string[] { "R2", "U'" }, new string[] { "R2", "U2" }, new string[] { "R2", "D " }, new string[] { "R2", "D'" }, new string[] { "R2", "D2" }, new string[] { "R2", "F " }, new string[] { "R2", "F'" }, new string[] { "R2", "F2" }, new string[] { "R2", "B " }, new string[] { "R2", "B'" }, new string[] { "R2", "B2" }, new string[] { "L ", "U " }, new string[] { "L ", "U'" }, new string[] { "L ", "U2" }, new string[] { "L ", "D " }, new string[] { "L ", "D'" }, new string[] { "L ", "D2" }, new string[] { "L ", "F " }, new string[] { "L ", "F'" }, new string[] { "L ", "F2" }, new string[] { "L ", "B " }, new string[] { "L ", "B'" }, new string[] { "L ", "B2" }, new string[] { "L'", "U " }, new string[] { "L'", "U'" }, new string[] { "L'", "U2" }, new string[] { "L'", "D " }, new string[] { "L'", "D'" }, new string[] { "L'", "D2" }, new string[] { "L'", "F " }, new string[] { "L'", "F'" }, new string[] { "L'", "F2" }, new string[] { "L'", "B " }, new string[] { "L'", "B'" }, new string[] { "L'", "B2" }, new string[] { "L2", "U " }, new string[] { "L2", "U'" }, new string[] { "L2", "U2" }, new string[] { "L2", "D " }, new string[] { "L2", "D'" }, new string[] { "L2", "D2" }, new string[] { "L2", "F " }, new string[] { "L2", "F'" }, new string[] { "L2", "F2" }, new string[] { "L2", "B " }, new string[] { "L2", "B'" }, new string[] { "L2", "B2" }, new string[] { "U ", "R " }, new string[] { "U ", "R'" }, new string[] { "U ", "R2" }, new string[] { "U ", "L " }, new string[] { "U ", "L'" }, new string[] { "U ", "L2" }, new string[] { "U ", "D " }, new string[] { "U ", "D'" }, new string[] { "U ", "D2" }, new string[] { "U ", "F " }, new string[] { "U ", "F'" }, new string[] { "U ", "F2" }, new string[] { "U ", "B " }, new string[] { "U ", "B'" }, new string[] { "U ", "B2" }, new string[] { "U'", "R " }, new string[] { "U'", "R'" }, new string[] { "U'", "R2" }, new string[] { "U'", "L " }, new string[] { "U'", "L'" }, new string[] { "U'", "L2" }, new string[] { "U'", "D " }, new string[] { "U'", "D'" }, new string[] { "U'", "D2" }, new string[] { "U'", "F " }, new string[] { "U'", "F'" }, new string[] { "U'", "F2" }, new string[] { "U'", "B " }, new string[] { "U'", "B'" }, new string[] { "U'", "B2" }, new string[] { "U2", "R " }, new string[] { "U2", "R'" }, new string[] { "U2", "R2" }, new string[] { "U2", "L " }, new string[] { "U2", "L'" }, new string[] { "U2", "L2" }, new string[] { "U2", "D " }, new string[] { "U2", "D'" }, new string[] { "U2", "D2" }, new string[] { "U2", "F " }, new string[] { "U2", "F'" }, new string[] { "U2", "F2" }, new string[] { "U2", "B " }, new string[] { "U2", "B'" }, new string[] { "U2", "B2" }, new string[] { "D ", "R " }, new string[] { "D ", "R'" }, new string[] { "D ", "R2" }, new string[] { "D ", "L " }, new string[] { "D ", "L'" }, new string[] { "D ", "L2" }, new string[] { "D ", "F " }, new string[] { "D ", "F'" }, new string[] { "D ", "F2" }, new string[] { "D ", "B " }, new string[] { "D ", "B'" }, new string[] { "D ", "B2" }, new string[] { "D'", "R " }, new string[] { "D'", "R'" }, new string[] { "D'", "R2" }, new string[] { "D'", "L " }, new string[] { "D'", "L'" }, new string[] { "D'", "L2" }, new string[] { "D'", "F " }, new string[] { "D'", "F'" }, new string[] { "D'", "F2" }, new string[] { "D'", "B " }, new string[] { "D'", "B'" }, new string[] { "D'", "B2" }, new string[] { "D2", "R " }, new string[] { "D2", "R'" }, new string[] { "D2", "R2" }, new string[] { "D2", "L " }, new string[] { "D2", "L'" }, new string[] { "D2", "L2" }, new string[] { "D2", "F " }, new string[] { "D2", "F'" }, new string[] { "D2", "F2" }, new string[] { "D2", "B " }, new string[] { "D2", "B'" }, new string[] { "D2", "B2" }, new string[] { "F ", "R " }, new string[] { "F ", "R'" }, new string[] { "F ", "R2" }, new string[] { "F ", "L " }, new string[] { "F ", "L'" }, new string[] { "F ", "L2" }, new string[] { "F ", "U " }, new string[] { "F ", "U'" }, new string[] { "F ", "U2" }, new string[] { "F ", "D " }, new string[] { "F ", "D'" }, new string[] { "F ", "D2" }, new string[] { "F ", "B " }, new string[] { "F ", "B'" }, new string[] { "F ", "B2" }, new string[] { "F'", "R " }, new string[] { "F'", "R'" }, new string[] { "F'", "R2" }, new string[] { "F'", "L " }, new string[] { "F'", "L'" }, new string[] { "F'", "L2" }, new string[] { "F'", "U " }, new string[] { "F'", "U'" }, new string[] { "F'", "U2" }, new string[] { "F'", "D " }, new string[] { "F'", "D'" }, new string[] { "F'", "D2" }, new string[] { "F'", "B " }, new string[] { "F'", "B'" }, new string[] { "F'", "B2" }, new string[] { "F2", "R " }, new string[] { "F2", "R'" }, new string[] { "F2", "R2" }, new string[] { "F2", "L " }, new string[] { "F2", "L'" }, new string[] { "F2", "L2" }, new string[] { "F2", "U " }, new string[] { "F2", "U'" }, new string[] { "F2", "U2" }, new string[] { "F2", "D " }, new string[] { "F2", "D'" }, new string[] { "F2", "D2" }, new string[] { "F2", "B " }, new string[] { "F2", "B'" }, new string[] { "F2", "B2" }, new string[] { "B ", "R " }, new string[] { "B ", "R'" }, new string[] { "B ", "R2" }, new string[] { "B ", "L " }, new string[] { "B ", "L'" }, new string[] { "B ", "L2" }, new string[] { "B ", "U " }, new string[] { "B ", "U'" }, new string[] { "B ", "U2" }, new string[] { "B ", "D " }, new string[] { "B ", "D'" }, new string[] { "B ", "D2" }, new string[] { "B'", "R " }, new string[] { "B'", "R'" }, new string[] { "B'", "R2" }, new string[] { "B'", "L " }, new string[] { "B'", "L'" }, new string[] { "B'", "L2" }, new string[] { "B'", "U " }, new string[] { "B'", "U'" }, new string[] { "B'", "U2" }, new string[] { "B'", "D " }, new string[] { "B'", "D'" }, new string[] { "B'", "D2" }, new string[] { "B2", "R " }, new string[] { "B2", "R'" }, new string[] { "B2", "R2" }, new string[] { "B2", "L " }, new string[] { "B2", "L'" }, new string[] { "B2", "L2" }, new string[] { "B2", "U " }, new string[] { "B2", "U'" }, new string[] { "B2", "U2" }, new string[] { "B2", "D " }, new string[] { "B2", "D'" }, new string[] { "B2", "D2" }, new string[] { "R " }, new string[] { "R'" }, new string[] { "R2" }, new string[] { "L " }, new string[] { "L'" }, new string[] { "L2" }, new string[] { "U " }, new string[] { "U'" }, new string[] { "U2" }, new string[] { "D " }, new string[] { "D'" }, new string[] { "D2" }, new string[] { "F " } };
        public int turnsListCount { get { return turnsList.Length; } }
        public string Hash { get; private set; }
        /// <summary>
        /// функция хэширования
        /// </summary>
        /// <param name="information">информация, которую надо захэшировать</param>
        /// <param name="height">сложность, должна быть больше 1</param>
        /// <returns></returns>
        public Hasher(string information, int height = 10)
        {
            if(height < 2)
            {
                throw new InvalidOperationException("height должно быть больше 1, а у вас " + height);
            }

            Cube cube = new Cube();
            List<string> turns = new List<string>();
            foreach (var e in information)
            {
                string[] eNumber = turnsList[(int)e];
                foreach(var e1 in eNumber)
                {
                    turns.Add(e1);
                }
            }
        }

        public bool Equals(string other)
        {
            throw new NotImplementedException();
        }
    }
}
