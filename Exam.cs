using System;

public class Exam : IDateAndCopy
{
    public string SubjectName { get; init; }
    public int Mark { get; init; }
    public DateTime DateTime { get; set; } 

    public Exam(string subjectName, int mark, DateTime dateTime)
    {
        SubjectName = subjectName;
        Mark = mark;
        DateTime = dateTime;
    }

    public Exam()
    {
        SubjectName = "Corporate information systems platforms";
        Mark = 80;
        DateTime = new DateTime(2024, 05, 25);
    }

    public override string ToString()
    {
        return $"Subject: {SubjectName}\nMark: {Mark}\nDate: {DateTime}";
    }

    public object DeepCopy()
    {
        return new Exam(SubjectName, Mark, DateTime);
    }

    public DateTime Date
    {
        get => DateTime;
        set => DateTime = value; 
    }
}
