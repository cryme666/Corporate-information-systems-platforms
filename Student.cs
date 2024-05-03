using System;
using System.Collections.Generic;

public class Student : Person, IDateAndCopy 
{
    private Education _educationForm;
    private int _groupNumber;
    private List<Exam> _exams;
    private List<Test> _tests;

    public Student(Person person, Education educationForm, int groupNumber) 
        : base(person.FirstName, person.LastName, person.BirthDate)
    {
        EducationForm = educationForm;
        GroupNumber = groupNumber;
        _exams = new List<Exam>();
        _tests = new List<Test>();
    }

    public Student() : this(new Person(), Education.Bachelor, 0)
    {
    }

    public List<Exam> Exams
    {
        get { return _exams; }
        set { _exams = value; }
    }

    public List<Test> Tests
    {
        get { return _tests; }
        set { _tests = value; }
    }

    public double AverageMark
    {
        get
        { 
            if (_exams.Count == 0)
                return 0;

            double totalMarks = 0;
            foreach (Exam exam in _exams)
            {
                totalMarks += exam.Mark;
            }
            return totalMarks / _exams.Count;
        }
    }

    public override string ToString()
    {
        string studentInfo = base.ToString(); 
        string educationInfo = $"Education Form: {EducationForm}\nGroup Number: {GroupNumber}\n";
        string examsInfo = "Exams:\n";
        foreach (Exam exam in _exams)
        {
            examsInfo += exam.ToString() + "\n";
        }
        string testsInfo = "Tests:\n";
        foreach (Test test in _tests)
        {
            testsInfo += test.ToString() + "\n";
        }
        return studentInfo + "\n" + educationInfo + "\n" + examsInfo + testsInfo;
    }

    public virtual string ToShortString()
    {
        return $"{base.ToString()}, Education Form: {EducationForm}, Group Number: {GroupNumber}, Average Mark: {AverageMark}";
    }

    public override object DeepCopy()
    {
        Student copiedStudent = new Student((Person)Person.DeepCopy(), EducationForm, GroupNumber);
        copiedStudent.Date = Date;

        List<Exam> copiedExams = new List<Exam>();
        foreach (Exam exam in _exams)
        {
            copiedExams.Add((Exam)exam.DeepCopy());
        }
        copiedStudent.Exams = copiedExams;

        List<Test> copiedTests = new List<Test>();
        foreach (Test test in _tests)
        {
            copiedTests.Add((Test)test.DeepCopy());
        }
        copiedStudent.Tests = copiedTests;

        return copiedStudent;
    }

    public int GroupNumber
    {
        get { return _groupNumber; }
        set
        {
            if (value < 100 || value > 699)
            {
                throw new ArgumentOutOfRangeException(nameof(GroupNumber), $"The group number must be between 100 and 699. Set value: {value}");
            }         
            _groupNumber = value;
        }
    }
}
