using System.Collections.Generic;
using System.Linq;

namespace dao_library
{
    public class PlayerDao : IDao<Player>
    {
        private static List<Player> _players = new List<Player>();
        public List<Player> GetAll()
        {
            return _players;
        }
        public Player GetById(int id)
        {
            // Busca al jugador por su número o índice
            return _players.FirstOrDefault(p => p.Numero == id);
        }
        public void Add(Player player)
        {
            _players.Add(player);
        }
        public void Delete(int id)
        {
            var player = GetById(id);
            if (player != null)
            {
                _players.Remove(player);
            }
        }
        public void Update(Player player)
        {
            var existingPlayer = GetById(player.Numero);
            if (existingPlayer != null)
            {
                existingPlayer.Name = player.Name;
                existingPlayer.Age = player.Age;
                existingPlayer.Dni = player.Dni;
            }
        }
    }
}