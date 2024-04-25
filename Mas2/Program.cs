using Mas2.Models;

namespace Mas2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var student = new Student();
            var cso = student.courses[0].lessons[0].teacher.lesson[0].teacher.lesson[0].grade;

            Console.WriteLine("Hello, World!");
        }
    }
}