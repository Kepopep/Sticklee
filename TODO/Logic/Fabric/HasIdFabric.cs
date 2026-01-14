using TODO.Logic.Interfaces;

namespace TODO.Logic.Fabric;

public static class HasIdFabric<T> where T : IHasId, new()
{
    public static T GetObject()
    {
        return new T()
        {
            Id = Guid.NewGuid()
        };
    }

    public static T GetObject(Guid id)
    {
        return new T()
        {
            Id = id
        };
    }
}