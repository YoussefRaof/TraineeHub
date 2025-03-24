using Task01.Models;

namespace Task01.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();

        Course GetById(int id);

        int Add(Course course);
        int Update(Course course);
        int Delete(Course course);
    }
}
