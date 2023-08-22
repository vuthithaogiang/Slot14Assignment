using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot14Assignment.classes
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public double MathScore { get; set; }
        public double PhysicsScore { get; set; }
        public double ChemistryScore { get; set; }
        public double AverageScore => Math.Round((MathScore + PhysicsScore + ChemistryScore) / 3, 2);
        public string GPA
        {
            get
            {
                if (AverageScore >= 8)
                    return "Excellent";
                else if (AverageScore >= 6.5)
                    return "Good";
                else if (AverageScore >= 5)
                    return "Average";
                else
                    return "Weak";
            }
        }

        public Student()
        {

        }

        public Student(int id, string name, int age, string gender, double mathScore, double physicsScore, double chemistryScore)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            MathScore = mathScore;
            PhysicsScore = physicsScore;
            ChemistryScore = chemistryScore;
        }
    }
}
