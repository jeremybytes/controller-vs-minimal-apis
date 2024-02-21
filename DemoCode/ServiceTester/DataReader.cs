using System.Net;

namespace ServiceTester;

public record ReaderResponse(string data, HttpStatusCode status);

public class DataReader
{
    HttpClient client = new HttpClient();

    public DataReader(string baseAddress)
    {
        client.BaseAddress = new Uri(baseAddress);
    }

    public async Task<ReaderResponse> SendRequest(string endpoint)
    {
        HttpResponseMessage response = await client.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Unable to process request. Status Code: {response.StatusCode}");
        }
        return new(await response.Content.ReadAsStringAsync(), response.StatusCode);
    }
}
