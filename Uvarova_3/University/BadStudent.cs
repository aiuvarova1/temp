using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class BadStudent:Student
    {
        string hairStyle;
        public string HairStyle
        {
            get => hairStyle;
            protected set => hairStyle = value;
        }
        public BadStudent(string name,string surname,int course,string hairStyle, int[] marks) : base(name, surname, course, marks)
        {
            if (hairStyle != "Undercut" && hairStyle != "Chubby" && hairStyle != "Bald")
                throw new ArgumentException();
            this.HairStyle = hairStyle;
            if (this.Mean > 4)
                throw new ArgumentException();
        }
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Course: {Course}, Average: {Mean.ToString("F3")}, HairStyle: {HairStyle}";
        }
        public override double Rating
        {
            get{
                if (Mean == 0)
                    return 0;
                if (HairStyle == "Chubby")

                    return Math.Abs((Mean + Course) / (Mean * Course));

                else
                    return (Math.Abs((Mean + Course) / (Mean * Course * 0.5)) % 12);
            }


        }

    }
}
