using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    enum EduLevel
    {
        elementary,
        secondary,
        higher
    }

    public class Student
    {
        Random random = new Random();

        public string FIO { get; }
        public int Grade { get; private set; }
        public double Performance { get; }
        public EduLevel Stage { get; private set; }

        public Student()
        {
            FIO = "?";
            Grade = random.Next(1, 12);
            Performance = Math.Round(random.NextDouble() * 5.0, 1);
            Stage = SetStage();
        }

        public Student(string fio, int grade, double performance)
        {
            FIO = fio;
            Grade = grade;
            Performance = performance;
            Stage = SetStage();
        }

        private EduLevel SetStage()
        {
            if (Grade >= 1 && Grade <= 4)
                return EduLevel.elementary;
            else if (Grade >= 5 && Grade <= 8)
                return EduLevel.secondary;
            else
                return EduLevel.higher;
        }

        public void Pass()
        {
            Grade++;
            Stage = SetStage();
        }

        // Переопределение базового класса ToString
        public override string ToString()
        {
            return $"{FIO} фио, {Stage} школа, {Grade} класс, {Performance} балл";
        }
    }

    public class School
    {
        public string Name { get; }
        public List<Student> ListStudents { get; }

        public School(string name)
        {
            Name = name;
            ListStudents = new List<Student>();
        }

        public void Add(Student student)
        {
            ListStudents.Add(student);
        }

        // 1. Абаев Георгий, средняя школа, 7 класс, 3.4 балла
        public override string ToString()
        {
            //заглушка
            return $"School: {Name}";
        }
    }

    //нужно вынести в отдельные классы 4 правила сравнения

    //сортировка по алфавиту
    public class NameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return string.Compare(x.FIO, y.FIO, StringComparison.Ordinal);
        }

    }

    public class GradeComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            //если x.Grade меньше y.Grade, то -1, наоборот - 1, равны - 0
            int gradeComparison = x.Grade.CompareTo(y.Grade);
            if (gradeComparison != 0)
            {
                return gradeComparison;
            }
            return 0;
        }
    }

    public class PerformanceComparer: IComparable<Student>
    {

    }

}
