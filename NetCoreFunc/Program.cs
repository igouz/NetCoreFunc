// See https://aka.ms/new-console-template for more information
#region Task test1
/*var task1 = new Task(() =>
{
    Console.WriteLine("begin");
    Task.Delay(2000);
    Console.WriteLine("Finished");
});
Console.WriteLine("task1 before:"+task1.Status);
task1.Start();
Console.WriteLine("task1 end :" + task1.Status);

Task.WaitAll(task1);

var task2 = Task.Factory.StartNew(() =>
{
    Console.WriteLine("this is task2");
}
);

Task.WaitAny(task1, task2);
Console.WriteLine("have one task finished");

Task.WaitAll(task1, task2);
Console.WriteLine("all task finished");*/
#endregion

#region Task.WhenAll() 用于长时间任务的用户取消，如下载...
//var tokenSource = new CancellationTokenSource();
//var token = tokenSource.Token;

//var task = Task.Factory.StartNew(() =>
//{
//    for(int i=0;i<1000;i++)
//    {
//        Console.Write("program is running ...,{0}", i);
//        Thread.Sleep(1000);
//        if(token.IsCancellationRequested)
//        {
//            Console.WriteLine("task is canceled");
//            return; 
//        }
//    }
//},token);
//token.Register(() =>
//{
//    Console.WriteLine("canced");
//});
//Console.WriteLine("press any key canceled");
//Console.ReadKey();
//tokenSource.Cancel();
#endregion

#region async wait
//Task<string> task = new Task<string>(() =>
//{
//    return $"hello task1的ID：{Thread.CurrentThread.ManagedThreadId}";
//});
//task.Start();

//Task<string> task2 = Task.Factory.StartNew(() =>
//{
//    return $"hello task2的ID：{Thread.CurrentThread.ManagedThreadId}";

//});

//Task<string> task3 = Task.Run<string>(() =>
//{
//    return $"hello task3的ID：{Thread.CurrentThread.ManagedThreadId}";

//});

//Console.WriteLine("main Thread");
//Console.WriteLine(task.Result);
//Console.WriteLine(task2.Result);
//Console.WriteLine(task3.Result);
//Console.WriteLine("task finished");
#endregion

#region await,async
/*
using System.Diagnostics;
{
    Stopwatch sw = Stopwatch.StartNew();
    string[] websites = new string[] {
        "http://www.baidu.com",
        "http://www.sina.com",
        "http://www.bing.com",
        "http://www.163.com"
        };
    Console.WriteLine("同步下载");
    
    static string DownLoadSync(string url)
    {
        HttpClient client = new HttpClient();
        string result = client.GetStringAsync(url).GetAwaiter().GetResult();
        return $"获取{url}成功：字节长度：{result.Length / 1000:F2}Kb,threadID :{Thread.CurrentThread.ManagedThreadId}";
    }
    foreach (string web in websites)
    {
        string result = DownLoadSync(web);
        Console.WriteLine(result);
    }
    sw.Stop();
    Console.WriteLine($"同步下载耗时:{sw.Elapsed}");
    
    static async Task<string> DownloadAsync(string url)
    {
        HttpClient client = new HttpClient();
        var res = await client.GetStringAsync(url);

        return $"获取{url}成功：字节长度：{res.Length / 1000:F2}Kb,threadID :{Thread.CurrentThread.ManagedThreadId}"; 
    }

   
    static void startAsync(int time){
        Console.WriteLine($"第{time}次下载");
        string[] websites = new string[] {
        "http://www.baidu.com",
        "http://www.sina.com",
        "http://www.bing.com",
        "http://www.163.com"
        };
        Console.WriteLine("异步下载...");
        Stopwatch sw2 = Stopwatch.StartNew();
        sw2.Start();
        List<Task<string>> downloadWebTask = new List<Task<string>>();
        foreach (var item in websites)
        {
            downloadWebTask.Add(DownloadAsync(item));
        }
        var results = Task.WhenAll(downloadWebTask).Result;
        if (results != null)
        {
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
        sw2.Stop();
        Console.WriteLine($"take time:{sw2.Elapsed}S");
    }
    //通过输入来获取数据
    while(true)
    {
        Console.WriteLine("press any key...Enter to exit...");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if(keyInfo.Key == ConsoleKey.Enter)
        {
            break;
        }
        startAsync(1);
    }
}*/
#endregion

#region Action,Func Linq
using NetCoreFunc;
using System.Linq;

List<int> list = new List<int>() { 1, 5, 2, 3, 4, 12, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
List<int> listBig5 = list.Where((x) => x> 4).ToList(); //where的参数是Func(number,bool)的委托;
foreach (var item in listBig5)
{
    Console.WriteLine(item);
}

int max = list.Min<int>();
Console.WriteLine("max:"+max);

int sum = list.Sum();
Console.WriteLine("sum:" + sum);

Console.WriteLine("Linq Group By usage");

var persons = new List<Person>
{
    new Person("Jack","Male"),
    new Person("Iric","Female"),
    new Person("LiLei","Male"),
    new Person("Lacky","Female")
};

var list2 = persons.GroupBy(x => x.Sex).ToList(); //返回值：IEnumerable<IGrouping<string,Person>>

foreach (var item in list2)
{
    Console.WriteLine(item.Key); //item的数据结构为：IGrouping<string,Person>
    foreach (var person in item)
    {
        Console.WriteLine(person);
    }
}
Console.WriteLine("============Linq等效写法C#8.0============="); //相对于代码方式Linq更加直观
var list3 = from p in persons
            group p by p.Sex;

foreach (var item in list3)
{
    Console.WriteLine(item.Key);
    foreach (var person in item)
    {
        Console.WriteLine(person);
    }
}
#endregion
Console.Read();
