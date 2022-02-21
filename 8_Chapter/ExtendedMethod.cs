using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Practice._8_Chapter
{
    public static class StringExtendMethod
    {
        public static void ShowItem(this string str)
        { 
            Console.WriteLine(str);
        }
    }
    public class ExtendedMethod
    {        
        public void Main()
        {
            Action a = "Jeff".ShowItem;
            a();
        }
    }
}
