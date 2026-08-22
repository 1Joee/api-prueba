using System.Collections.Generic;
using System.Linq;

namespace dao_library
{
    public class TrainerDao : IDao<Trainer>
    {
        private static List<Trainer> _trainers = new List<Trainer>();
        public List<Trainer> GetAll() => _trainers;
        public Trainer GetById(int id)
        {
            // Como Trainer hereda de Person y no tiene un ID único en el UML, 
            // podemos buscar por índice o DNI adaptado
            return _trainers.ElementAtOrDefault(id)!;
        }
        public void Add(Trainer trainer) => _trainers.Add(trainer);
        public void Delete(int id)
        {
            var trainer = GetById(id);
            if (trainer != null) _trainers.Remove(trainer);
        }

        public void Update(Trainer trainer)
        {
            // Si tenés una referencia directa o índice
            var index = _trainers.FindIndex(t => t.Dni == trainer.Dni);
            if (index != -1)
            {
                _trainers[index] = trainer;
            }
        }
    }
}