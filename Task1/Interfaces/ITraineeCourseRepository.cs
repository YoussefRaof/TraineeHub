using Task01.Models;

namespace Task01.Interfaces
{
    public interface ITraineeCourseRepository
    {
        public List<TraineeCourse> GetAll();
        public TraineeCourse Get(int traineeId, int courseId);
        public int RegisterStudentToCourse(TraineeCourse traineeCourse);
        public void UnRegisterStudentToCourse(TraineeCourse traineeCourse);
        public int Update(TraineeCourse traineeCourse);
       
    }
}
