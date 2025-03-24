using Microsoft.EntityFrameworkCore;
using Task01.Context;
using Task01.Interfaces;
using Task01.Models;

namespace Task01.Repositories
{
    public class TraineeRepository : ITranieeRepository
    {
        private readonly TraineeDB _dbContext;

        public TraineeRepository(TraineeDB dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Trainee trainee)
        {
            if (trainee is not null)
            {
                _dbContext.Add(trainee);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public int Delete(Trainee trainee)
        {
            if (trainee is not null)
            {
                _dbContext.Remove(trainee);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<Trainee> GetAll()
        {
            return _dbContext.Trainees.Include(T => T.Trk).ToList();
        }

        public Trainee GetById(int id)
        {
            var trainee = _dbContext.Trainees.Include(T => T.Trk).FirstOrDefault(T=>T.Id == id);
            return trainee ?? new Trainee();
        }

        public int Update(Trainee trainee)
        {
            if (trainee is not null)
            {
                _dbContext.Update(trainee);
                return _dbContext.SaveChanges();
            }
            return 0;
        }
    }
}
