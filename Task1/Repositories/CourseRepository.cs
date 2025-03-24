using Microsoft.EntityFrameworkCore;
using Task01.Context;
using Task01.Interfaces;
using Task01.Models;

namespace Task01.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly TraineeDB _dbContext;

        public CourseRepository(TraineeDB dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Course course)
        {
            if (course is not null)
            {
                _dbContext.Add(course);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public int Delete(Course course)
        {
            if (course is not null)
            {
                _dbContext.Remove(course);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<Course> GetAll()
        {
            return _dbContext.Courses.ToList();
        }

        public Course GetById(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(T => T.Id == id);
            if (course is not null)
                return course;
            return new Course();
        }

        public int Update(Course course)
        {
            if (course is not null)
            {
                _dbContext.Update(course);
                return _dbContext.SaveChanges();
            }
            return 0;
        }
    }
}
