using People.Service;

namespace MinimalApi;

public static class ApiMethods
{
    public async static Task<IResult> TestableCall(int id, IPeopleProvider provider)
    {
        var person = await provider.GetPerson(id);
        return person switch
        {
            null => Results.NoContent(),
            _ => Results.Json(person)
        };
    }
}
