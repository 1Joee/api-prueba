namespace dao_library;
using entity_library;

public class PlayerDAO
{
    public List<Player> GetAllPlayers()
    {
        return MockDatabase.Players;
    }

    public Player? GetPlayerById(int id)
    {
        return MockDatabase.Players.FirstOrDefault(x => x.Id == id);
    }

    public Player CreatePlayer(Player entity)
    {
        int lastId = MockDatabase.Players.Count == 0 ? 0 : MockDatabase.Players.Max(x => x.Id);
        entity.Id = lastId + 1;
        MockDatabase.Players.Add(entity);
        return entity;
    }

    public bool UpdatePlayer(Player entity)
    {
        Player? existing = GetPlayerById(entity.Id);
        if (existing == null)
        {
            return false;
        }
        existing.Name = entity.Name;
        existing.Age = entity.Age;
        existing.Dni = entity.Dni;
        existing.Numero = entity.Numero;
        existing.Teams = entity.Teams;
        return true;
    }

    public bool DeletePlayerById(int id)
    {
        Player? existing = GetPlayerById(id);
        if (existing == null)
        {
            return false;
        }
        MockDatabase.Players.Remove(existing);
        return true;
    }
}
