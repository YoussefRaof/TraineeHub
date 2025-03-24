using Microsoft.EntityFrameworkCore;
using Task01.Context;
using Task01.Interfaces;
using Task01.Models;

namespace Task01.Repositories
{
    public class TraineeCourseRepository : ITraineeCourseRepository
    {
        private readonly TraineeDB _dbContext;

        public TraineeCourseRepository(TraineeDB dbContext)
        {
            _dbContext = dbContext;
        }

      

        public TraineeCourse Get(int traineeId, int courseId)
        {
           return _dbContext.TraineesCourses.FirstOrDefault(TC => TC.TraineeId ==traineeId && TC.CourseId ==courseId);
        }

        public List<TraineeCourse> GetAll()
        {
           return _dbContext.TraineesCourses.Include(TC => TC.Trainee).Include(Tc => Tc.Course).ToList();
        }

        public int RegisterStudentToCourse(TraineeCourse traineeCourse)
        {
            if (traineeCourse is not null)
            {
                _dbContext.TraineesCourses.Add(traineeCourse);
                return _dbContext.SaveChanges();

            }
            return 0;
        }

        public void UnRegisterStudentToCourse(TraineeCourse traineeCourse)
        {
           if(traineeCourse is not null)
            {
                _dbContext.Remove(traineeCourse);
                _dbContext.SaveChanges();
                    
                    
                    
            }
        }

        public int Update(TraineeCourse traineeCourse)
        {
            if (traineeCourse == null)
                return 0;
           _dbContext.Update(traineeCourse);
            return _dbContext.SaveChanges();
        }
    }
}
