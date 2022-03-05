using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLR_Practice._21_Chapter
{
    public static class GCNotification
    {
        private static Action<Int32> s_gcDone = null;
        public static event Action<Int32> GCDone
        {
            add {
                if (s_gcDone == null)
                {
                    new GenObjct(0);
                    new GenObjct(2);
                }
                s_gcDone += value;

            }
            remove { 
                s_gcDone -= value;
            }
        }

        private sealed class GenObjct
        {
            private Int32 m_generation;
            public GenObjct(Int32 generation)
            {
                m_generation = generation;
            }
            ~GenObjct() {
                
                //当该对象在我们希望的或者更高的代中，则通知委托一次GC完成
                var currentGeneration = GC.GetGeneration(this);
                Console.WriteLine($"GenObjct：[{m_generation}] Start Recycle,当前对象处于第{currentGeneration}代");
                if (currentGeneration >= m_generation)
                {
                    /*
                        Volatile.Read(ref s_gcDone)方法:
                        从指定的字段中读取对象引用。在需要它的系统上，插入一个内存屏障，阻止处理器重新排序内存,操作如下：
                        如果在此方法之后出现读或写，处理器不能在此方法之前移动它。 
                        这段代码的作用：保证后面执行的内容，是之前正确初始化的对象；
                    */
                    Action<Int32> temp = Volatile.Read(ref s_gcDone);
                    temp?.Invoke(m_generation);
                }
                //如果至少还有一个已登记的委托，且AppDomain并非正在卸载，且进程并非正在关闭，就继续报告通知
                if ((s_gcDone != null) && !AppDomain.CurrentDomain.IsFinalizingForUnload() && !Environment.HasShutdownStarted)
                {
                    //第0代，创建一个新对象
                    if (m_generation == 0)
                        new GenObjct(0);//对于第0代，创建一个新对象
                    else
                        /*补充：
                         * 析构函数在IL层面就是Finalize方法，是被GC调用的
                         * GC.SuppressFinalize(this)表示告诉GC不需要在调用Finalize方法
                         * GC.ReRegisterForFinalize(this)再下次垃圾回收时再次调用该对象的Finalize
                         */
                        GC.ReRegisterForFinalize(this);//对于第2代，复活对象，使第2代在下次回收时，GC会再次调用Finalize
                }
                else
                {
                    Console.WriteLine($"对象[{m_generation}]被释放");
                }
            }   
        }
    }
}
