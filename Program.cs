using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            Student studA = new Student();
            Student studB = new Student();
            Student studBagaev = new Student("Багаев Аслан", 4, 4);
            Student studAbaev = new Student("Абаев Георгий", 4, 3.4);
            Student studAtaev = new Student("Атаев Сослан", 4, 3);
            Student studLabaev = new Student("ЪЕЪ", 5, 4);

            School school = new School("ФизМат");
            school.Add(studB);
            school.Add(studBagaev);
            school.Add(studAbaev);
            school.Add(studA);
            school.Add(studAtaev);
            school.Add(studLabaev);

            Console.WriteLine("Исходная школа!");
            Console.WriteLine(school);

            Console.WriteLine("отсортировали по уровню обр");
            school.Sort(new StageComparer());
            Console.WriteLine(school);

            Console.WriteLine("отсортировали по имени! по алфавиту");
            school.Sort(new NameComparer());
            Console.WriteLine(school);

            Console.WriteLine("сортировка по классам!");
            school.Sort(new GradeComparer());
            Console.WriteLine(school);
        }
    }
}
