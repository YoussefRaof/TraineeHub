using Task01.Models;

namespace Task01.Interfaces
{
    public interface ITranieeRepository 
    {
        IEnumerable<Trainee> GetAll();

        Trainee GetById(int id);

        int Add(Trainee trainee);
        int Update(Trainee trainee);
        int Delete(Trainee trainee);
    }
}
