namespace ServiceTester;

public static class RawResponseString
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
}
