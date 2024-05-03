using System;
using System.Collections;
using System.Collections.Generic;

public class Student : Person, IDateAndCopy 
{
    private Education _educationForm;
    private int _groupNumber;
    private ArrayList _exams;

     private List<Test> _tests;

    // Конструктор з параметрами для ініціалізації відповідних полів класу
    public Student(Person person, Education educationForm, int groupNumber) 
        : base(person.FirstName, person.LastName, person.BirthDate)
    {
        EducationForm = educationForm;
        GroupNumber = groupNumber;
        Exams = new ArrayList();
    }

    // Конструктор без параметрів для ініціалізації за замовчуванням
    public Student() : this(new Person(), Education.Bachelor, 0)
    {
    }

    public Person Person
    {
        get { return new Person(FirstName, LastName, BirthDate); }
        init
        {
            FirstName = value.FirstName;
            LastName = value.LastName;
            BirthDate = value.BirthDate;
        }
    }

 
    public double AverageMark
    {
        get
        { 

            if (Exams is null || Exams.Count == 0)
                return 0;

            double totalMarks = 0;
            foreach (Exam exam in Exams)
            {
                totalMarks += exam.Mark;
            }
            return totalMarks / Exams.Count;
        }
    }
    public ArrayList Exams
    {
        get { return _exams; }
        init { _exams = value; }
    }

    public Education EducationForm
{
    get { return _educationForm; }
    init { _educationForm = value; }
}


    public void AddExams(params Exam[] exams)
    {
        foreach (Exam exam in exams)
        {
            _exams.Add(exam);
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

        return studentInfo + "\n" + educationInfo + "\n" + examsInfo;
    }

    public virtual string ToShortString()
    {
                //! to change name convention 

        return $"{base.ToString()}, Education Form: {EducationForm}, Group Number: {GroupNumber}, Average Mark: {AverageMark}";
    }


 public DateTime Date { get; set; }

 public override object DeepCopy()
    {
        Student copiedStudent = new Student((Person)Person.DeepCopy(), EducationForm, GroupNumber);
        copiedStudent.Date = Date;
        var list = new ArrayList();

        if (_exams is not null)
        foreach(var exam in _exams) list.Add(((Exam)exam).DeepCopy());

        copiedStudent._exams = list;
        return copiedStudent;
    }

public int GroupNumber
{
    get => _groupNumber;
    set
    {
        if (value < 100 || value > 699)
        {
            throw new ArgumentOutOfRangeException(nameof(GroupNumber), $"The group number must be between 100 and 699. Set value: {value}");
        }         

        _groupNumber = value;
    }
}
    public IEnumerable<object> GetAllExamsAndTests()
    {
        foreach (Exam exam in _exams)
        {
            yield return exam;
        }

        foreach (Test test in _tests)
        {
            yield return test;
        }
    }

    public IEnumerable<Exam> GetExamsWithGradeGreaterThan(int grade)
    {
        foreach (Exam exam in _exams)
        {
            if (exam.Mark > grade)
            {
                yield return exam;
            }
        }
    }

    public void AddTests(params Test[] tests)
{
    if (_tests == null)
        _tests = new List<Test>();
    
    _tests.AddRange(tests);
}

}
