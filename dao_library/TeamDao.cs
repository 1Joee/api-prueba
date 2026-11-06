namespace dao_library;
using entity_library;

public class TeamDAO
{
    public List<Team> GetAllTeams()
    {
        return MockDatabase.Teams;
    }

    public Team? GetTeamById(int id)
    {
        return MockDatabase.Teams.FirstOrDefault(x => x.Id == id);
    }

    public Team CreateTeam(Team entity)
    {
        int lastId = MockDatabase.Teams.Count == 0 ? 0 : MockDatabase.Teams.Max(x => x.Id);
        entity.Id = lastId + 1;
        MockDatabase.Teams.Add(entity);
        return entity;
    }

    public bool UpdateTeam(Team entity)
    {
        Team? existing = GetTeamById(entity.Id);
        if (existing == null)
        {
            return false;
        }
        existing.Name = entity.Name;
        existing.Category = entity.Category;
        existing.Players = entity.Players;
        return true;
    }

    public bool DeleteTeamById(int id)
    {
        Team? existing = GetTeamById(id);
        if (existing == null)
        {
            return false;
        }
        MockDatabase.Teams.Remove(existing);
        return true;
    }
}
