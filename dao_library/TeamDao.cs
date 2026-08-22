using System.Collections.Generic;
using System.Linq;

namespace dao_library
{
    public class TeamDao : IDao<Team>
    {
        private static List<Team> _teams = new List<Team>();

        public List<Team> GetAll() => _teams;

        public Team GetById(int id)
        {
            return _teams.ElementAtOrDefault(id)!;
        }

        public void Add(Team team) => _teams.Add(team);

        public void Delete(int id)
        {
            var team = GetById(id);
            if (team != null) _teams.Remove(team);
        }

        public void Update(Team team)
        {
            var existingTeam = _teams.FirstOrDefault(t => t.Name == team.Name);
            if (existingTeam != null)
            {
                existingTeam.Category = team.Category;
                existingTeam.Players = team.Players;
            }
        }
    }
}