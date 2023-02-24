
class Jar
{
    public int capacity { get; set; }
    public int size { get; set; }

    public Jar(int capacity, int size)
    {
        this.capacity = capacity;
        this.size = size;
    }

    public void Deposit(int n)
    {
        if (size + n <= capacity)
        {
            size += n;
        }
        else
        {
            Console.WriteLine("Cannot add that many cookies to the jar");
        }
    }
    public void Withdraw(int n)
    {
        if (n > size)
        {
            Console.WriteLine("There isn't that many cookies in the Jar");
        }
        else
        {
            size -= n;
        }

    }
}

class Execute
{
    static void Main(string[] args)
    {
        Jar jar = new Jar(10, 5);
        Console.WriteLine($"Jar capacity: {jar.capacity}, Jar size: {jar.size}");
        jar.size += 1;
        Console.WriteLine(jar.size);
        jar.Deposit(1);
        Console.WriteLine(jar.size);
        jar.Deposit(20);
        jar.Withdraw(1);
        Console.WriteLine(jar.size);
    }
}