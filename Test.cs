public class Test
{
    public string SubjectName { get; set; }
    public bool Passed { get; set; }

    // Конструктор з параметрами
    public Test(string subjectName, bool passed)
    {
        SubjectName = subjectName;
        Passed = passed;
    }

    // Конструктор без параметрів
    public Test()
    {
        SubjectName = "Default Subject";
        Passed = false;
    }


    public override string ToString()
    {
        return $"Subject: {SubjectName}, Passed: {Passed}";
    }
}
