using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Practice._9_Chapter
{
    internal class DefaultParamater
    {
        //IL 会在x前面标记一个 [opt]
        //而在编译器内部会为x应用定制特性 InteropServices.OptionalAttribute,最终会在生成的文件的元数据中持久性的存储下来
        public int DefaultParamterMethod(int x = 2)
        {
            return x;
        }
        public int DefaultParamterMethod(int x = 2,string y = "data")
        {
            return x;
        }
        //隐式类型的局部变量，var
        public void ImplicitTypeLocalVariable()
        {
            var list = new List<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            foreach (var x in list)
            { 
                Console.WriteLine(x);
            }
        }
        /// <summary>
        /// 以传引用的方式传递参数
        /// CLR层面是不关心ref和out，都会生成一样的IL代码，比如下面的data和d -> string& data, [out] float64& d  可以看到对应传递的是地址
        /// 为大的值类型使用out，能够避免在进行方法调用时复制值类型实例的字段；
        /// 
        /// 从c#编译器的角度，out和ref会按照不同的标准验证你写的代码是否正确
        /// </summary>
        public void ReferenceTypeParameter(int x,ref string data,out double d)
        {
            d = 1.0;
        }

        /// <summary>
        /// 可变数量的参数
        /// params 关键字告诉编译器向参数应用定制特性System.ParamArrayAttribute
        /// C#编译器检测到方法调用时，会先检查所有具有指定名称、同时参数没有应用ParamArray特性的方法，找到匹配方法就生成调用它所需的代码；没有找到就接着检查应用了
        /// ParamArray特性的方法，找到之后，编译器会先生成代码来构造一个数组，填充他的元素，在生成代码来调用所选的方法
        /// </summary>
        /// <returns></returns>
        public Int32 VariableNumberParameters(params Int32[] values)
        {
            Int32 result = 0;
            if (values != null)
            {
                foreach (var x in values)
                {
                    result += x;
                }
            }
            return result;
        }
    }
}
