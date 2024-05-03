using System;

public interface IDateAndCopy
{
    DateTime Date { get; set; }
    object DeepCopy();
}

public class Person : IDateAndCopy, IEquatable<Person>, IComparable<Person>,  IComparer<Person> 
{
    protected string _firstName;
    protected string _lastName;
    protected DateTime _birthDate;

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public Person() : this("Valentyn", "Vikovan", new DateTime(2004, 06, 21))
    {
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public DateTime BirthDate
    {
        get { return _birthDate; }
        set { _birthDate = value; }
    }

    public int BirthYear
    {
        get { return _birthDate.Year; }
        set { _birthDate = new DateTime(value, _birthDate.Month, _birthDate.Day); }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Birth Date: {_birthDate}";
    }

    public virtual object DeepCopy()
    {
        return new Person(FirstName, LastName, BirthDate);
    }

    public DateTime Date
    {
        get { return _birthDate; }
        set { _birthDate = value; }
    }

    public bool Equals(Person? other)
    {
        if (other is null)
            return false;
        return FirstName == other.FirstName && LastName == other.LastName && BirthDate == other.BirthDate;
    }

    public override int GetHashCode()
    { 
        return HashCode.Combine(FirstName, LastName, BirthDate);
    }

    public static bool operator ==(Person person1, Person person2)
    {
        if (ReferenceEquals(person1, person2))
            return true;

        if (person1 is null || person2 is null)
            return false;

        return person1.Equals(person2);
    }

    public static bool operator !=(Person person1, Person person2)
    {
        return !(person1 == person2);
    }


    public int CompareTo(Person other)
    {
        if (other == null)
            return 1;

        return string.Compare(this.LastName, other.LastName, StringComparison.Ordinal);
    }

    public int Compare(Person x, Person y)
    {
        if (x == null && y == null)
            return 0;
        if (x == null)
            return -1;
        if (y == null)
            return 1;

        return DateTime.Compare(x.BirthDate, y.BirthDate);
    }

}
