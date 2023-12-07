namespace ServiceTester;

internal class Program
{
    static async Task Main(string[] args)
    {
        DataReader controllerReader = new("http://localhost:5062");

        Console.WriteLine("Controller GetPerson(3):");
        var response = await controllerReader.GetPerson(3);
        Console.WriteLine(response.status);
        Console.WriteLine(response.data);

        Console.WriteLine("----------");

        Console.WriteLine("Controller GetPerson(-1):");
        response = await controllerReader.GetPerson(-1);
        Console.WriteLine(response.status);
        Console.WriteLine(response.data);

        DataReader minimalReader = new("http://localhost:5194");
        Console.WriteLine("Minimal GetPerson(3):");
        response = await minimalReader.GetPerson(3);
        Console.WriteLine(response.status);
        Console.WriteLine(response.data);

        Console.WriteLine("----------");

        Console.WriteLine("Minimal GetPerson(-1):");
        response = await minimalReader.GetPerson(-1);
        Console.WriteLine(response.status);
        Console.WriteLine(response.data);

    }
}
