using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Practice._8_Chapter
{

    public struct Point
    {
        public int X, Y;
        //CLR允许为值类型定义构造器，但是必须显示调用才会执行
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point()
        { 
            X = Y = 5;
        }
    }
    public class Rectangle
    {
        public Point topLeft, bottomRight;
        public Rectangle()
        {
            //这里必须显示调用，如果不调用 也不会为其附上5的初始值
            topLeft = new Point(10, 10);
            bottomRight = new Point(20, 20);
        }
    }

    public class SomeType
    {
        private static int x = 5;
       
        public static SomeType operator +(SomeType s1, SomeType s2)
        {
            return s1;
        }
    }
}
