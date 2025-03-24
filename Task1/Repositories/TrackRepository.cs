using Microsoft.EntityFrameworkCore;
using Task01.Context;
using Task01.Interfaces;
using Task01.Models;

namespace Task01.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly TraineeDB _dbContext;
        public TrackRepository(TraineeDB dbContext)
        {
          _dbContext = dbContext;   
        }
        public int Add(Track track)
        {
            if (track is not null)
            {
                _dbContext.Add(track);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public int Delete(Track track)
        {
            //var track = _dbContext.Tracks.Find(id);
            if (track is not null)
            {
                _dbContext.Remove(track);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public List<Track> GetAll()
        {
            return _dbContext.Tracks.ToList();
        }

        public Track GetById(int id)
        {
            var track = _dbContext.Tracks.Include(T => T.Trainees).FirstOrDefault(T => T.Id == id);
            if (track is not null)
                return track;
            return new Track();
        }

        public int Update(Track track)
        {
            if (track is not null)
            {
                _dbContext.Update(track);
                return _dbContext.SaveChanges();
            }
            return 0;
        }


    }
}
