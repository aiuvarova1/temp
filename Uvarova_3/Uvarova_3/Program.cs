using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University;


namespace Uvarova_3
{
    class Program
    {
        static Random rand = new Random();
        static string[] glasses = { "None", "Square", "Round" };
        static string[] hairStyles = { "Undercut", "Bald", "Chubby" };
        static string[] names = { "Kolya", "Ivan", "Andrew", "Leonid", "Misha" };
        static string[] surnames = { "Ivanov", "Petrov", "Sidorov" };
        static void Main(string[] args)
        {
            //try
            //{
            do
            {
                int n = GetSize();
                Student[] students = null;
                try
                {
                    students = new Student[n];
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("The size is too big.");
                    continue;
                }
                GenerateArray(ref students);

                if(students[0]==null)
                {
                    Console.WriteLine("The size is too big.\nPress Esc to exit, any other key to continue");
                    continue;
                }

                foreach (Student stud in students)
                {
                    Console.WriteLine(stud);
                }
                Console.WriteLine();
                Student student = CreateStudent(students.Length);
                Console.WriteLine(student);

                Console.WriteLine("Students with less rating: ");

                int number = 0;
                GoodStudent best = null;

                for (int i = 0; i < students.Length; i++)
                {

                    if (students[i].Rating < student.Rating)
                    {
                        number++;
                        Console.WriteLine(students[i]);
                    }
                }

                int numOf1 = 0;
                Console.WriteLine($"The number of students: {number}");
                Console.WriteLine($"The bad students fron the 1 course: ");

                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i].GetType() == typeof(GoodStudent))
                    {
                        if (best == null)
                            best = (GoodStudent)students[i];
                        if (students[i].Mean > best.Mean)
                            best = (GoodStudent)students[i];
                    }
                    if (students[i].GetType() == typeof(BadStudent) && students[i].Course == 1)
                    {
                        numOf1++;
                        Console.WriteLine(students[i]);
                    }

                }
                Console.WriteLine($"The number of bad students from the 1 course: {numOf1}");
                Console.WriteLine($"The best student: {best}");


                Console.WriteLine("Press Esc to exit");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            // }
            //catch { }
        }




        static int GetSize()
        {
            int data;
            Console.WriteLine("Enter a size of the array: ");
            while (!int.TryParse(Console.ReadLine(), out data) || data <= 0)
            {
                Console.WriteLine("Invalid input. Size should be a positive integer.");
            }
            return data;
        }

        static Student CreateStudent(int length)
        {

            int choice = rand.Next(1, 11);

            Student student = null;


            if (choice < 6)
            {
                do
                {
                    try
                    {
                        int[] marks = null;

                        //(!!!)
                        checked
                        {
                            try
                            {
                                marks = new int[3 * length];
                            }
                            catch (OutOfMemoryException)
                            {
                                return null;

                            }
                            catch (OverflowException)
                            {
                                return null;
                            }
                        }

                        for (int j = 0; j < marks.Length; j++)
                        {
                            // try
                            // {
                            marks[j] = rand.Next(0, 11);
                            // }
                            // catch (NotAppropriateMarkException)
                            // {
                            // j--;
                            // }
                        }
                        student = new BadStudent(names[rand.Next(0, 5)], surnames[rand.Next(0, 3)], rand.Next(-5, 6), hairStyles[rand.Next(0, 3)], marks);
                    }
                    catch (ArgumentException)
                    {

                    }
                } while (student == null);
            }
            else
            {
                do
                {
                    try

                    {
                        int[] marks = null;
                        checked
                        {
                            try
                            {
                                marks = new int[3 * length];
                            }
                            catch (OutOfMemoryException)
                            {
                                return null;

                            }
                            catch (OverflowException)
                            {
                                return null;
                            }
                        }

                        for (int j = 0; j < marks.Length; j++)
                        {
                            // try
                            // {
                            marks[j] = rand.Next(0, 11);
                            // }
                            // catch (NotAppropriateMarkException)
                            // {
                            // j--;
                            // }
                        }
                        student = new GoodStudent(names[rand.Next(0, 5)], surnames[rand.Next(0, 3)], rand.Next(-5, 6), glasses[rand.Next(0, 3)], marks);
                    }
                    catch (ArgumentException) { }
                } while (student == null);
            }
            return student;

        }

        static void GenerateArray(ref Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = CreateStudent(students.Length);
                if (students[i] == null)
                    return;
            }
        }
    }
}
