﻿using System;
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
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if (averageGrade >= grade[threshold - 1])
                return 'A';
            else if (averageGrade >= grade[(threshold * 2) - 1])
                return 'B';
            else if (averageGrade >= grade[(threshold * 3) - 1])
                return 'C';
            else if (averageGrade >= grade[(threshold * 4) - 1])
                return 'D';
            else
            return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count <5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
