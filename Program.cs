// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using CLR_Practice._7_Chapter;
using CLR_Practice._8_Chapter;

<<<<<<< HEAD
//Rectangle rectangle = new Rectangle();
//Console.WriteLine(rectangle.topLeft.X);
//Console.WriteLine(rectangle.topLeft.Y);
//SomeType some = new SomeType();
Dictionary<int,string> keyValuePairs = new Dictionary<int,string>();
Task.Run(async() => {
    for (int i = 0; i < 100000; i++)
    {
        //await Task.Delay(1);
        keyValuePairs.Add(i, Guid.NewGuid().ToString());
    }
    Console.WriteLine("The End");
});

Task.Run(async() => {
    await Task.Delay(10);
    for (int i = 0; i < 1000; i++)
    {
        keyValuePairs.TryGetValue(i,out var data);
        Console.WriteLine(String.Format("{0} = {1}",i,data));
    }
});

Console.ReadLine(); 

//AnotherType.Main();
=======
ExtendedMethod instance = new ExtendedMethod();
instance.Main();
AnotherType.Main();
>>>>>>> d27edf4c1e28abd12cec22b217c5be3d28757b30
