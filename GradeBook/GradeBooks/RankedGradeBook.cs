using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            else
            {
                var totalGrade = 0.0;
                foreach (var student in Students)
                {
                    totalGrade += student.AverageGrade;
                }
                var averageStutentGrade = totalGrade / Students.Count;
                if (averageGrade >= .8 * averageStutentGrade)
                    return 'A';
                else if (averageGrade >= .6 * averageStutentGrade)
                    return 'B';
                else if (averageGrade >= .4 * averageStutentGrade)
                    return 'C';
                else if (averageGrade >= .2 * averageStutentGrade)
                    return 'D';
                else
                    return 'F';

            }
        }
    }
}
