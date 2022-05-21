﻿using System;

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
        public Side() { }

        /// <summary>
        /// конструктор для создания одноцветной стороны
        /// </summary>
        /// <param name="color">цвет, который присваивается всем элементам стороны</param>
        public Side(Color color)
        {
            this.upLeftAngle = color;
            this.upEdge = color;
            this.upRightAngle = color;
            this.rightEdge = color;
            this.downRightAngle = color;
            this.downEdge = color;
            this.downLeftAngle = color;
            this.leftEdge = color;
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

            this.upLeftAngle = colors[0];
            this.upEdge = colors[1];
            this.upRightAngle = colors[2];
            this.rightEdge = colors[3];
            this.downRightAngle = colors[4];
            this.downEdge = colors[5];
            this.downLeftAngle = colors[6];
            this.leftEdge = colors[7];
        }

        public Color upEdge;
        public Color rightEdge;
        public Color downEdge;
        public Color leftEdge;
        public Color upRightAngle;
        public Color upLeftAngle;
        public Color downLeftAngle;
        public Color downRightAngle;
        public void ClockwiseTurn()
        {
            Color swap = upEdge;
            upEdge = leftEdge;
            leftEdge = downEdge;
            downEdge = rightEdge;
            rightEdge = swap;
            swap = upLeftAngle;
            upLeftAngle = downLeftAngle;
            downLeftAngle = downRightAngle;
            downRightAngle = upRightAngle;
            upRightAngle = swap;
        }

        public void ContrClockwiseTurn()
        {
            Color swap = upEdge;
            upEdge = rightEdge;
            rightEdge = downEdge;
            downEdge = leftEdge;
            leftEdge = swap;
            swap = upLeftAngle;
            upLeftAngle = upRightAngle;
            upRightAngle = downRightAngle;
            downRightAngle = downLeftAngle;
            downLeftAngle = swap;
        }

        public void DoubleTurn()
        {
            Color swap = upEdge;
            upEdge = downEdge;
            downEdge = swap;
            swap = rightEdge;
            rightEdge = leftEdge;
            leftEdge = swap;
            swap = upLeftAngle;
            upLeftAngle = downRightAngle;
            downRightAngle = swap;
            swap = upRightAngle;
            upRightAngle = downLeftAngle;
            downLeftAngle = swap;
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
                side = new Side(new Color[] { sides[index].upLeftAngle, sides[index].upEdge, sides[index].upRightAngle, sides[index].rightEdge, sides[index].downRightAngle, sides[index].downEdge, sides[index].downLeftAngle, sides[index].leftEdge });
            }

            FillSide(0, ref whiteSide);
            FillSide(1, ref yellowSide);
            FillSide(2, ref greenSide);
            FillSide(3, ref blueSide);
            FillSide(4, ref orangeSide);
            FillSide(5, ref redSide);
        }
        public Side whiteSide;
        public Side yellowSide;
        public Side greenSide;
        public Side blueSide;
        public Side orangeSide;
        public Side redSide;
        public string R()
        {
            orangeSide.ClockwiseTurn();
            Color swap = greenSide.upRightAngle;
            greenSide.upRightAngle = whiteSide.upRightAngle;
            whiteSide.upRightAngle = blueSide.upRightAngle;
            blueSide.upRightAngle = yellowSide.upRightAngle;
            yellowSide.upRightAngle = swap;
            swap = greenSide.rightEdge;
            greenSide.rightEdge = whiteSide.rightEdge;
            whiteSide.rightEdge = blueSide.rightEdge;
            blueSide.rightEdge = yellowSide.rightEdge;
            yellowSide.rightEdge = swap;
            swap = greenSide.downRightAngle;
            greenSide.downRightAngle = whiteSide.downRightAngle;
            whiteSide.downRightAngle = blueSide.downRightAngle;
            blueSide.downRightAngle = yellowSide.downRightAngle;
            yellowSide.downRightAngle = swap;
            return "R ";
        }

        public string RContr()
        {
            orangeSide.ContrClockwiseTurn();
            Color swap = greenSide.upRightAngle;
            greenSide.upRightAngle = yellowSide.upRightAngle;
            yellowSide.upRightAngle = blueSide.upRightAngle;
            blueSide.upRightAngle = whiteSide.upRightAngle;
            whiteSide.upRightAngle = swap;
            swap = greenSide.rightEdge;
            greenSide.rightEdge = yellowSide.rightEdge;
            yellowSide.rightEdge = blueSide.rightEdge;
            blueSide.rightEdge = whiteSide.rightEdge;
            whiteSide.rightEdge = swap;
            swap = greenSide.downRightAngle;
            greenSide.downRightAngle = yellowSide.downRightAngle;
            yellowSide.downRightAngle = blueSide.downRightAngle;
            blueSide.downRightAngle = whiteSide.downRightAngle;
            whiteSide.downRightAngle = swap;
            return "R'";
        }

        public string RDouble()
        {
            orangeSide.DoubleTurn();
            Color swap = greenSide.upRightAngle;
            greenSide.upRightAngle = blueSide.upRightAngle;
            blueSide.upRightAngle = swap;
            swap = whiteSide.upRightAngle;
            whiteSide.upRightAngle = yellowSide.upRightAngle;
            yellowSide.upRightAngle = swap;
            swap = greenSide.rightEdge;
            greenSide.rightEdge = blueSide.rightEdge;
            blueSide.rightEdge = swap;
            swap = whiteSide.rightEdge;
            whiteSide.rightEdge = yellowSide.rightEdge;
            yellowSide.rightEdge = swap;
            swap = greenSide.downRightAngle;
            greenSide.downRightAngle = blueSide.downRightAngle;
            blueSide.downRightAngle = swap;
            swap = whiteSide.downRightAngle;
            whiteSide.downRightAngle = yellowSide.downRightAngle;
            yellowSide.downRightAngle = swap;
            return "R2";
        }

        public string L()
        {
            redSide.ClockwiseTurn();
            Color swap = greenSide.upLeftAngle;
            greenSide.upLeftAngle = yellowSide.upLeftAngle;
            yellowSide.upLeftAngle = blueSide.upLeftAngle;
            blueSide.upLeftAngle = whiteSide.upLeftAngle;
            whiteSide.upLeftAngle = swap;
            swap = greenSide.leftEdge;
            greenSide.leftEdge = yellowSide.leftEdge;
            yellowSide.leftEdge = blueSide.leftEdge;
            blueSide.leftEdge = whiteSide.leftEdge;
            whiteSide.leftEdge = swap;
            swap = greenSide.downLeftAngle;
            greenSide.downLeftAngle = yellowSide.downLeftAngle;
            yellowSide.downLeftAngle = blueSide.downLeftAngle;
            blueSide.downLeftAngle = whiteSide.downLeftAngle;
            whiteSide.downLeftAngle = swap;
            return "L ";
        }

        public string LContr()
        {
            redSide.ContrClockwiseTurn();
            Color swap = greenSide.upLeftAngle;
            greenSide.upLeftAngle = whiteSide.upLeftAngle;
            whiteSide.upLeftAngle = blueSide.upLeftAngle;
            blueSide.upLeftAngle = yellowSide.upLeftAngle;
            yellowSide.upLeftAngle = swap;
            swap = greenSide.leftEdge;
            greenSide.leftEdge = whiteSide.leftEdge;
            whiteSide.leftEdge = blueSide.leftEdge;
            blueSide.leftEdge = yellowSide.leftEdge;
            yellowSide.leftEdge = swap;
            swap = greenSide.downLeftAngle;
            greenSide.downLeftAngle = whiteSide.downLeftAngle;
            whiteSide.downLeftAngle = blueSide.downLeftAngle;
            blueSide.downLeftAngle = yellowSide.downLeftAngle;
            yellowSide.downLeftAngle = swap;
            return "L'";
        }

        public string LDouble()
        {
            redSide.DoubleTurn();
            Color swap = greenSide.upLeftAngle;
            greenSide.upLeftAngle = blueSide.upLeftAngle;
            blueSide.upLeftAngle = swap;
            swap = whiteSide.upLeftAngle;
            whiteSide.upLeftAngle = yellowSide.upLeftAngle;
            yellowSide.upLeftAngle = swap;
            swap = greenSide.leftEdge;
            greenSide.leftEdge = blueSide.leftEdge;
            blueSide.leftEdge = swap;
            swap = whiteSide.leftEdge;
            whiteSide.leftEdge = yellowSide.leftEdge;
            yellowSide.leftEdge = swap;
            swap = greenSide.downLeftAngle;
            greenSide.downLeftAngle = blueSide.downLeftAngle;
            blueSide.downLeftAngle = swap;
            swap = whiteSide.downLeftAngle;
            whiteSide.downLeftAngle = yellowSide.downLeftAngle;
            yellowSide.downLeftAngle = swap;
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
            Color swap = greenSide.upRightAngle;
            greenSide.upRightAngle = redSide.upRightAngle;
            redSide.upRightAngle = blueSide.downLeftAngle;
            blueSide.downLeftAngle = orangeSide.upRightAngle;
            orangeSide.upRightAngle = swap;
            swap = greenSide.upLeftAngle;
            greenSide.upLeftAngle = redSide.upLeftAngle;
            redSide.upLeftAngle = blueSide.downRightAngle;
            blueSide.downRightAngle = orangeSide.upLeftAngle;
            orangeSide.upLeftAngle = swap;
            swap = greenSide.upEdge;
            greenSide.upEdge = redSide.upEdge;
            redSide.upEdge = blueSide.downEdge;
            blueSide.downEdge = orangeSide.upEdge;
            orangeSide.upEdge = swap;
            return "U'";
        }

        public string UDouble()
        {
            yellowSide.DoubleTurn();
            Color swap = greenSide.upRightAngle;
            greenSide.upRightAngle = blueSide.downLeftAngle;
            blueSide.downLeftAngle = swap;
            swap = orangeSide.upRightAngle;
            orangeSide.upRightAngle = redSide.upRightAngle;
            redSide.upRightAngle = swap;
            swap = greenSide.upLeftAngle;
            greenSide.upLeftAngle = blueSide.downRightAngle;
            blueSide.downRightAngle = swap;
            swap = orangeSide.upLeftAngle;
            orangeSide.upLeftAngle = redSide.upLeftAngle;
            redSide.upLeftAngle = swap;
            swap = greenSide.upEdge;
            greenSide.upEdge = blueSide.downEdge;
            blueSide.downEdge = swap;
            swap = orangeSide.upEdge;
            orangeSide.upEdge = redSide.upEdge;
            redSide.upEdge = swap;
            return "U2";
        }

        public string D()
        {
            whiteSide.ClockwiseTurn();
            Color swap = greenSide.downRightAngle;
            greenSide.downRightAngle = redSide.downRightAngle;
            redSide.downRightAngle = blueSide.upLeftAngle;
            blueSide.upLeftAngle = orangeSide.downRightAngle;
            orangeSide.downRightAngle = swap;
            swap = greenSide.downLeftAngle;
            greenSide.downLeftAngle = redSide.downLeftAngle;
            redSide.downLeftAngle = blueSide.upRightAngle;
            blueSide.upRightAngle = orangeSide.downLeftAngle;
            orangeSide.downLeftAngle = swap;
            swap = greenSide.downEdge;
            greenSide.downEdge = redSide.downEdge;
            redSide.downEdge = blueSide.upEdge;
            blueSide.upEdge = orangeSide.downEdge;
            orangeSide.downEdge = swap;
            return "D ";
        }

        public string DContr()
        {
            whiteSide.ContrClockwiseTurn();
            Color swap = greenSide.downRightAngle;
            greenSide.downRightAngle = orangeSide.downRightAngle;
            orangeSide.downRightAngle = blueSide.upLeftAngle;
            blueSide.upLeftAngle = redSide.downRightAngle;
            redSide.downRightAngle = swap;
            swap = greenSide.downLeftAngle;
            greenSide.downLeftAngle = orangeSide.downLeftAngle;
            orangeSide.downLeftAngle = blueSide.upRightAngle;
            blueSide.upRightAngle = redSide.downLeftAngle;
            redSide.downLeftAngle = swap;
            swap = greenSide.downEdge;
            greenSide.downEdge = orangeSide.downEdge;
            orangeSide.downEdge = blueSide.upEdge;
            blueSide.upEdge = redSide.downEdge;
            redSide.downEdge = swap;
            return "D'";
        }

        public string DDouble()
        {
            whiteSide.DoubleTurn();
            Color swap = greenSide.downRightAngle;
            greenSide.downRightAngle = blueSide.upLeftAngle;
            blueSide.upLeftAngle = swap;
            swap = orangeSide.downRightAngle;
            orangeSide.downRightAngle = redSide.downRightAngle;
            redSide.downRightAngle = swap;
            swap = greenSide.downLeftAngle;
            greenSide.downLeftAngle = blueSide.upRightAngle;
            blueSide.upRightAngle = swap;
            swap = orangeSide.downLeftAngle;
            orangeSide.downLeftAngle = redSide.downLeftAngle;
            redSide.downLeftAngle = swap;
            swap = greenSide.downEdge;
            greenSide.downEdge = blueSide.upEdge;
            blueSide.upEdge = swap;
            swap = orangeSide.downEdge;
            orangeSide.downEdge = redSide.downEdge;
            redSide.downEdge = swap;
            return "D2";
        }

        public string F()
        {
            greenSide.ClockwiseTurn();
            Color swap = yellowSide.downLeftAngle;
            yellowSide.downLeftAngle = redSide.downRightAngle;
            redSide.downRightAngle = whiteSide.upRightAngle;
            whiteSide.upRightAngle = orangeSide.upLeftAngle;
            orangeSide.upLeftAngle = swap;
            swap = yellowSide.downRightAngle;
            yellowSide.downRightAngle = redSide.upRightAngle;
            redSide.upRightAngle = whiteSide.upLeftAngle;
            whiteSide.upLeftAngle = orangeSide.downLeftAngle;
            orangeSide.downLeftAngle = swap;
            swap = yellowSide.downEdge;
            yellowSide.downEdge = redSide.rightEdge;
            redSide.rightEdge = whiteSide.upEdge;
            whiteSide.upEdge = orangeSide.leftEdge;
            orangeSide.leftEdge = swap;
            return "F ";
        }

        public string FContr()
        {
            greenSide.ContrClockwiseTurn();
            Color swap = yellowSide.downLeftAngle;
            yellowSide.downLeftAngle = orangeSide.upLeftAngle;
            orangeSide.upLeftAngle = whiteSide.upRightAngle;
            whiteSide.upRightAngle = redSide.downRightAngle;
            redSide.downRightAngle = swap;
            swap = yellowSide.downRightAngle;
            yellowSide.downRightAngle = orangeSide.downLeftAngle;
            orangeSide.downLeftAngle = whiteSide.upLeftAngle;
            whiteSide.upLeftAngle = redSide.upRightAngle;
            redSide.upRightAngle = swap;
            swap = yellowSide.downEdge;
            yellowSide.downEdge = orangeSide.leftEdge;
            orangeSide.leftEdge = whiteSide.upEdge;
            whiteSide.upEdge = redSide.rightEdge;
            redSide.rightEdge = swap;
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
            Color swap = yellowSide.upLeftAngle;
            yellowSide.upLeftAngle = orangeSide.upRightAngle;
            orangeSide.upRightAngle = whiteSide.downRightAngle;
            whiteSide.downRightAngle = redSide.downLeftAngle;
            redSide.downLeftAngle = swap;
            swap = yellowSide.upRightAngle;
            yellowSide.upRightAngle = orangeSide.downRightAngle;
            orangeSide.downRightAngle = whiteSide.downLeftAngle;
            whiteSide.downLeftAngle = redSide.upLeftAngle;
            redSide.upLeftAngle = swap;
            swap = yellowSide.upEdge;
            yellowSide.upEdge = orangeSide.rightEdge;
            orangeSide.rightEdge = whiteSide.downEdge;
            whiteSide.downEdge = redSide.leftEdge;
            redSide.leftEdge = swap;
            return "B ";
        }

        public string BContr()
        {
            blueSide.ContrClockwiseTurn();
            Color swap = yellowSide.upLeftAngle;
            yellowSide.upLeftAngle = redSide.downLeftAngle;
            redSide.downLeftAngle = whiteSide.downRightAngle;
            whiteSide.downRightAngle = orangeSide.upRightAngle;
            orangeSide.upRightAngle = swap;
            swap = yellowSide.upRightAngle;
            yellowSide.upRightAngle = redSide.upLeftAngle;
            redSide.upLeftAngle = whiteSide.downLeftAngle;
            whiteSide.downLeftAngle = orangeSide.downRightAngle;
            orangeSide.downRightAngle = swap;
            swap = yellowSide.upEdge;
            yellowSide.upEdge = redSide.leftEdge;
            redSide.leftEdge = whiteSide.downEdge;
            whiteSide.downEdge = orangeSide.rightEdge;
            orangeSide.rightEdge = swap;
            return "B'";
        }

        public string BDouble()
        {
            blueSide.DoubleTurn();
            Color swap = yellowSide.upLeftAngle;
            yellowSide.upLeftAngle = whiteSide.downRightAngle;
            whiteSide.downRightAngle = swap;
            swap = orangeSide.upRightAngle;
            orangeSide.upRightAngle = redSide.downLeftAngle;
            redSide.downLeftAngle = swap;
            swap = yellowSide.upRightAngle;
            yellowSide.upRightAngle = whiteSide.downLeftAngle;
            whiteSide.downLeftAngle = swap;
            swap = orangeSide.downRightAngle;
            orangeSide.downRightAngle = redSide.upLeftAngle;
            redSide.upLeftAngle = swap;
            swap = yellowSide.upEdge;
            yellowSide.upEdge = whiteSide.downEdge;
            whiteSide.downEdge = swap;
            swap = orangeSide.rightEdge;
            orangeSide.rightEdge = redSide.leftEdge;
            redSide.leftEdge = swap;
            return "B2";
        }

        public override string ToString()
        {
            string sCube = "";
            string[] indexes = new string[] { "w", "y", "g", "b", "o", "r" };
            void FillStrBySide(Side side)
            {
                sCube += indexes[(int)side.upLeftAngle] + indexes[(int)side.upEdge] + indexes[(int)side.upRightAngle] + indexes[(int)side.rightEdge] + indexes[(int)side.downRightAngle] + indexes[(int)side.downEdge] + indexes[(int)side.downLeftAngle] + indexes[(int)side.leftEdge];
            }

            FillStrBySide(yellowSide);
            FillStrBySide(whiteSide);
            FillStrBySide(greenSide);
            FillStrBySide(blueSide);
            FillStrBySide(orangeSide);
            FillStrBySide(redSide);
            return sCube;
        }
    }


}
