namespace ServiceTester;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.Clear();

        Uri minimalUri = new("http://localhost:5194");
        Uri controllerUri = new("http://localhost:5062");

        // Minimal API Call
        Console.WriteLine("Minimal /people/3");
        var response = await minimalUri.GetResponse("/people/3");
        Console.WriteLine(response);

        Console.WriteLine("----------");

        // Controller API Call
        Console.WriteLine("Controller /people/3");
        response = await controllerUri.GetResponse("/people/3");
        Console.WriteLine(response);

        Console.WriteLine("----------");

        // Calls item that does not exist

        Console.WriteLine("Controller /people/-1");
        var statusResponse = await controllerUri.GetStatusAndResponse("/people/-1");
        Console.WriteLine($"{(int)statusResponse.Status} {statusResponse.Status}");
        Console.WriteLine(statusResponse.Data);

        Console.WriteLine("----------");

        Console.WriteLine("Minimal /people/-1");
        statusResponse = await minimalUri.GetStatusAndResponse("/people/-1");
        Console.WriteLine($"{(int)statusResponse.Status} {statusResponse.Status}");
        Console.WriteLine(statusResponse.Data);

        Console.WriteLine("----------");

        Console.WriteLine("Minimal /people/v2/-1");
        statusResponse = await minimalUri.GetStatusAndResponse("/people/v2/-1");
        Console.WriteLine($"{(int)statusResponse.Status} {statusResponse.Status}");
        Console.WriteLine(statusResponse.Data);
    }
}
