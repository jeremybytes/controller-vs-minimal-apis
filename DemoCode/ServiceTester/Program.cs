namespace ServiceTester;

internal class Program
{
    static async Task Main(string[] args)
    {
        Uri controllerUri = new("http://localhost:5062");
        Uri minimalUri = new("http://localhost:5194");

        // Minimal API Call
        Console.WriteLine("Minimal /people/v1/3");
        var response = await minimalUri.GetResponse("/people/v1/3");
        Console.WriteLine(response);

        Console.WriteLine("----------");

        // Controller API Call
        Console.WriteLine("Controller /people/3");
        response = await controllerUri.GetResponse("/people/3");
        Console.WriteLine(response);

        Console.WriteLine("----------");

        // Calls item that does not exist

        //DataReader controllerReader = new("http://localhost:5062");
        //DataReader minimalReader = new("http://localhost:5194");

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
