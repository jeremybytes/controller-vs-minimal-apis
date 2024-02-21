using ControllerApi.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging.Abstractions;
using MinimalApi;
using People.Service;

namespace ApiTests;

public class Tests
{
    [Test]
    public async Task MinimalApi_WithValidId_ReturnsData()
    {
        var result = await ApiMethods.TestableCall(3, new FakePeopleProvider());
        Assert.That(result, Is.TypeOf<JsonHttpResult<Person>>());
    }

    [Test]
    public async Task MinimalApi_WithInvalidId_ReturnsNoContent()
    {
        var result = await ApiMethods.TestableCall(-1, new FakePeopleProvider());
        Assert.That(result, Is.TypeOf<NoContent>());
    }

    [Test]
    public async Task ControllerApi_WithValidId_ReturnsData()
    {
        PeopleController controller = new(NullLogger<PeopleController>.Instance);
        var result = await controller.GetPerson(new FakePeopleProvider(), 3);
        Assert.That(result!.Id, Is.EqualTo(3));
    }

    [Test]
    public async Task ControllerApi_WithInvalidId_ReturnsNull()
    {
        PeopleController controller = new(NullLogger<PeopleController>.Instance);
        var result = await controller.GetPerson(new FakePeopleProvider(), -1);
        Assert.That(result, Is.Null);
    }
}