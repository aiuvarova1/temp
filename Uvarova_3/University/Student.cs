using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public abstract class Student
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        private int course;
        public int Course
        {
            get => course;
            set
            {
                if (value > 4 || value < 1)
                    throw new ArgumentException();
                course = value;
            }
        }
        public int[] marks;
        public double Mean
        {
            get
            {
                double average = 0;
                for (int i = 0; i < marks.Length; i++)
                {
                    average += marks[i];
                }
                average /= (double)marks.Length;
                if (average < 0 || average > 10)
                    throw new ArgumentException();
                return average;
            }

        }
        public Student(string name,string surname,int course, int[] marks)
        {
            Name = name;
            Surname = surname;
           // if (course < 1 || course > 4)
               // throw new ArgumentException();
            Course = course;
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] > 10 || marks[i] < 0)
                    throw new NotAppropriateMarkException();
            }
            this.marks = (int[])marks.Clone();

        }
        public abstract double Rating { get; }
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Course: {Course}, Average: {Mean.ToString("F3")}";
        }

    }
}
