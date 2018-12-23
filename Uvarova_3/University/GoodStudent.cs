using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class GoodStudent:Student
    {
        //private string glassesStyle;
        public string Glasses { get; protected set; }
        public GoodStudent(string name, string surname, int course,string glassesStyle,int[] marks) : base(name, surname, course, marks)
        {
            if (glassesStyle != "None" && glassesStyle != "Round" && glassesStyle != "Square")
                throw new ArgumentException();
            this.Glasses = glassesStyle;
            if (Mean < 4)
                throw new ArgumentException();

        }
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Course: {Course}, Average: {Mean.ToString("F3")}, GlassesStyle: {Glasses} ";
        }
        public override double Rating
        {
            get
            {
                if (Glasses == "None")
                    return Math.Abs(Mean + 10);
                else
                    return (Math.Abs((Mean + Course) / (10 * Mean)) % 11);
            }
        }

    }
}
