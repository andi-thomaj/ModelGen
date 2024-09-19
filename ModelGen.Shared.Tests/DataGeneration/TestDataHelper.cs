using Bogus;
using ModelGen.Domain;

namespace ModelGen.Shared.Tests.DataGeneration;

public static class TestDataHelper
{
    private static readonly Faker<User> _userFaker = new Faker<User>()
        .RuleFor(x => x.Id, f => f.Random.Guid())
        .RuleFor(x => x.Email, f => f.Person.Email)
        .RuleFor(x => x.FirstName, f => f.Person.FirstName)
        .RuleFor(x => x.MiddleName, f => f.Person.LastName)
        .RuleFor(x => x.LastName, f => f.Person.LastName)
        .RuleFor(x => x.PictureUrl, f => f.Internet.Avatar())
        .RuleFor(x => x.Theme, f => f.Commerce.ProductName());

    public static DataGenerator DataGenerator = new DataGenerator()
        .AddInstanceGenerator(() => _userFaker.Generate());
}