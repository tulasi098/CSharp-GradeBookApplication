using System;
using System.Linq;

using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name,isWeighted)
        {
            Type = GradeBookType.Ranked; 
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            var x = (int)Math.Ceiling(Students.Count * 0.2);
            var grade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if (averageGrade >= grade[x - 1])
                return 'A';
            if (averageGrade >= grade[(x * 2) - 1])
                return 'B';
            if (averageGrade >= grade[(x * 3) - 1])
                return 'C';
            if (averageGrade >= grade[(x * 4) - 1])
                return 'D';
            return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count() <5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
