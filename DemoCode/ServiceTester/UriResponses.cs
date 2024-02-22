using System.Net;

namespace ServiceTester;

public record StatusResponse(HttpStatusCode Status, string Data);

public static class UriResponses
{
    public static async Task<string> GetResponse(this Uri uri, string endpoint)
    {
        HttpClient client = new() { BaseAddress = uri };

        HttpResponseMessage response = await client.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Unable to process request. Status Code: {response.StatusCode}");
        }
        return await response.Content.ReadAsStringAsync();
    }

    public static async Task<StatusResponse> GetStatusAndResponse(this Uri uri, string endpoint)
    {
        HttpClient client = new() { BaseAddress = uri };

        HttpResponseMessage response = await client.GetAsync(endpoint);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Unable to process request. Status Code: {response.StatusCode}");
        }
        string data = await response.Content.ReadAsStringAsync();
        return new(response.StatusCode, data);
    }
}
