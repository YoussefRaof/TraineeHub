using Task01.Models;

namespace Task01.Interfaces
{
    public interface ITrackRepository
    {
       List<Track> GetAll();

        Track GetById(int id);

        int Add(Track track);
        int Update(Track track);
        int Delete(Track track);
    }
}
