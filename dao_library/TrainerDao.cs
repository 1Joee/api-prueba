namespace dao_library;
using entity_library;

public class TrainerDAO
{
    public List<Trainer> GetAllTrainers()
    {
        return MockDatabase.Trainers;
    }

    public Trainer? GetTrainerById(int id)
    {
        return MockDatabase.Trainers.FirstOrDefault(x => x.Id == id);
    }

    public Trainer CreateTrainer(Trainer entity)
    {
        int lastId = MockDatabase.Trainers.Count == 0 ? 0 : MockDatabase.Trainers.Max(x => x.Id);
        entity.Id = lastId + 1;
        MockDatabase.Trainers.Add(entity);
        return entity;
    }

    public bool UpdateTrainer(Trainer entity)
    {
        Trainer? existing = GetTrainerById(entity.Id);
        if (existing == null)
        {
            return false;
        }
        existing.Name = entity.Name;
        existing.Age = entity.Age;
        existing.Dni = entity.Dni;
        return true;
    }

    public bool DeleteTrainerById(int id)
    {
        Trainer? existing = GetTrainerById(id);
        if (existing == null)
        {
            return false;
        }
        MockDatabase.Trainers.Remove(existing);
        return true;
    }
}
