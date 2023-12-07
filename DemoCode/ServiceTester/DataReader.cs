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

    public async Task<ReaderResponse> GetPeople()
    {
        HttpResponseMessage response = await client.GetAsync("people");
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Unable to process request. Status Code: {response.StatusCode}");
        }
        return new(await response.Content.ReadAsStringAsync(), response.StatusCode);
    }

    public async Task<ReaderResponse> GetPerson(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"people/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Unable to process request. Status Code: {response.StatusCode}");
        }
        return new(await response.Content.ReadAsStringAsync(), response.StatusCode);
    }
}
