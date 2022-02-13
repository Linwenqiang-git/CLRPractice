using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Practice._7_Chapter
{
    public sealed class Atype
    {
        public static readonly Char[] InvalidChars = new Char[] { 'A', 'B', 'C' };
        public static readonly String[] InvalidStrings = new String[] { "A", "B", "C"};
        public static readonly String InvalidString = "Stype String";
    }
    public sealed class AnotherType
    {
        //当某个字段是引用类型，并且该字段被标记为readonly时，
        //不可改变的是引用，而非字段引用的对象！！
       
        public static void Main()
        {
            Atype.InvalidChars[0] = 'X';
            Atype.InvalidChars[1] = 'Y';
            Atype.InvalidChars[2] = 'Z';
            Atype.InvalidStrings[2] = "SS";
            

            Console.WriteLine(Atype.InvalidChars[0]);
            Console.WriteLine(Atype.InvalidStrings[2]);

            //Atype.InvalidChars = new char[] { 'X', 'Y','Z'};
            //Atype.InvalidString = "11";
        }
    }
}
