// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using CLR_Practice._7_Chapter;
using CLR_Practice._8_Chapter;
using CLR_Practice._21_Chapter;

//object o = new object();
//Console.WriteLine($"程序启动时间：{DateTime.Now}\n");
//int x = 0;
//Action<Int32> s_gcDone = (x) => { 
//    Console.WriteLine($"对象:[{x}]GC完成,调用时间：{DateTime.Now}"); 
//    Console.WriteLine($"第0代发上了 {GC.CollectionCount(0)} 次垃圾回收"); 
//    Console.WriteLine($"第1代发上了 {GC.CollectionCount(1)} 次垃圾回收"); 
//    Console.WriteLine($"第2代发上了 {GC.CollectionCount(2)} 次垃圾回收");
//    Int64 totalMemery = GC.GetTotalMemory(false);
//    Console.WriteLine($"当前对象占用了[{totalMemery}]\n");
//};
//GCNotification.GCDone += s_gcDone;

List<InternalClass>  data = CreareObject().ToList();
Console.WriteLine("打印完成1");

Console.ReadLine();
data.AddRange(CreareObject());
Console.WriteLine("打印完成2");

Console.ReadLine();
data.AddRange(CreareObject());
Console.WriteLine("打印完成3");

Console.ReadLine();
data.AddRange(CreareObject());
Console.WriteLine("打印完成4");

Console.ReadLine();


IEnumerable<InternalClass> CreareObject()
{
    for (int i = 0; i < 200; i++)
    {
       yield return new InternalClass();
    }
}

sealed class InternalClass
{
    private int x;
    private string y;
    private DateTime t;
    public InternalClass() 
    {
        x = 1;
        y = $"data{x}";
        t = DateTime.Now;
    }


}