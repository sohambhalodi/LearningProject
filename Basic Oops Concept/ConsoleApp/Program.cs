// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Second first= new Second();
first.Print();

int[] ints= new int[5];
ints[0]=0;
ints[1]=1;
var x = ints;
int[] y = new int[x.Length];
Array.Copy(x, y, x.Length);
first.change(ints);
first.printarr(ints);
Console.WriteLine("Hello");
first.printarr(x);
first.printarr(y);

class First
{
    public void Print()
    {
        Console.WriteLine("First");
    }
    public void printarr(int[] ints)
    {
        foreach (var item in ints)
        {
            Console.WriteLine(item);
        }
    }
    public void change(int[] ints)
    {
        ints[2] = 3;
    }
}
class Second:First
{
    public void Print()
    {
        Console.WriteLine("Second");
    }
}