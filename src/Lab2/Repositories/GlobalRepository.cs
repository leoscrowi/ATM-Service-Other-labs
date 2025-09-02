namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class GlobalRepository
{
    private static readonly GlobalRepository? _instance = null;
    private readonly Dictionary<Guid, object?> _repository = new Dictionary<Guid, object?>();

    private GlobalRepository()
    {
    }

    public static GlobalRepository Instance()
    {
        if (_instance == null) return new GlobalRepository();
        return _instance;
    }

    public void Add(Guid identifier, object? entity)
    {
        _repository.Add(identifier, entity);
    }

    public object? FindById(Guid identifier)
    {
        return _repository.ContainsKey(identifier) ? _repository[identifier] : null;
    }
}