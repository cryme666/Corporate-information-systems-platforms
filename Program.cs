using System;

class Program
{
    static void Main(string[] args)
    {
        
        Person person1 = new Person("John", "Doe", new DateTime(1990, 5, 15));
        Person person2 = new Person("John", "Doe", new DateTime(1990, 5, 15));

        
        Console.WriteLine("Reference equality: " + ReferenceEquals(person1, person2));

       
        Console.WriteLine("HashCode of person1: " + person1.GetHashCode());
        Console.WriteLine("HashCode of person2: " + person2.GetHashCode());

        
        Student student = new Student(person1, Education.Bachelor, 123);

        
        student.AddExams(new Exam("Math", 90, new DateTime(2023, 5, 10)),
                  new Exam("Physics", 85, new DateTime(2023, 6, 15)));
        student.AddTests(new Test("Programming", true), new Test("English", false));

        
        Console.WriteLine("\nStudent Information:");
        Console.WriteLine(student.ToString());

    
        Console.WriteLine("\nPerson information for the student:");
        Console.WriteLine(student.Person.ToString());

        
        Student copiedStudent = (Student)student.DeepCopy();
        student.FirstName = "Alex"; 

      
        Console.WriteLine("\nOriginal Student:");
        Console.WriteLine(student.ToString());
        Console.WriteLine("\nCopied Student:");
        Console.WriteLine(copiedStudent.ToString());

        try
        {
            // введення неприпустимого значення номеру групи
            student.GroupNumber = 800;
        }
        catch (ArgumentOutOfRangeException ex)
        {
        
            Console.WriteLine("\nError: " + ex.Message);
        }

        // Використання оператора foreach для ітератора з параметром
        Console.WriteLine("\nExams with grade greater than 3:");
        foreach (var exam in student.GetExamsWithGradeGreaterThan(3))
        {
            Console.WriteLine(exam.ToString());
        }
    }
}
