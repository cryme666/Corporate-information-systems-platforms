using System;
using System.Collections.Generic;
using System.Text;

public class StudentCollection
{
    private List<Student> _students;

    public StudentCollection()
    {
        _students = new List<Student>();
    }

    public void AddDefaults()
    {
        _students.Add(new Student("Petro", "Poroshenko", new DateTime(2000, 1, 1)));
        _students.Add(new Student("Vikovan", "Valentyn", new DateTime(2004, 2, 2)));
    }

    public void AddStudents(params Student[] students)
    {
        _students.AddRange(students);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Student student in _students)
        {
            sb.AppendLine(student.ToString());
        }
        return sb.ToString();
    }

    public string ToShortString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Student student in _students)
        {
            sb.AppendLine(student.ToShortString());
        }
        return sb.ToString();
    }

     // Сортування за прізвищем за допомогою IComparable
    public void SortByLastName()
    {
        _students.Sort();
    }

    // Сортування за датою народження за допомогою IComparer
    public void SortByBirthDate()
    {
        _students.Sort((x, y) => x.CompareTo(y));
    }

    // Сортування за середнім балом за допомогою IComparer
    public void SortByAverageMark()
    {
        _students.Sort(new StudentAverageMarkComparer());
   
    public double MaxAverageMark => _students.Select(s => s.AverageMark).DefaultIfEmpty(0).Max();
    public IEnumerable<Student> MasterStudents => _students.Where(s => s.EducationForm == Education.Master);

     public List<Student> AverageMarkGroup(double value)
    {
        return _students.GroupBy(s => s.AverageMark)
                        .Where(g => g.Key == value)
                        .SelectMany(g => g.ToList())
                        .ToList();
    }
}
