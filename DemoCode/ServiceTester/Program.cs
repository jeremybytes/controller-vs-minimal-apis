namespace ServiceTester;

internal class Program
{
    static async Task Main(string[] args)
    {
        DataReader controllerReader = new("http://localhost:5062");
        DataReader minimalReader = new("http://localhost:5194");

        // Minimal API Call
        Console.WriteLine("Minimal /people/v1/3");
        var response = await minimalReader.SendRequest("/people/v1/3");
        Console.WriteLine(response.data);

        Console.WriteLine("----------");

        // Controller API Call
        Console.WriteLine("Controller /people/3");
        response = await controllerReader.SendRequest("/people/3");
        Console.WriteLine(response.data);

        Console.WriteLine("----------");

        // Calls item that does not exist
        //Console.WriteLine("Controller /people/-1");
        //response = await controllerReader.SendRequest("/people/-1");
        //Console.WriteLine(response.status);
        //Console.WriteLine(response.data);

        //Console.WriteLine("----------");

        //Console.WriteLine("Minimal /people/v1/-1");
        //response = await minimalReader.SendRequest("/people/v1/-1");
        //Console.WriteLine(response.status);
        //Console.WriteLine(response.data);

        //Console.WriteLine("----------");

        //Console.WriteLine("Minimal /people/v2/-1");
        //response = await minimalReader.SendRequest("/people/v2/-1");
        //Console.WriteLine(response.status);
        //Console.WriteLine(response.data);

    }
}
