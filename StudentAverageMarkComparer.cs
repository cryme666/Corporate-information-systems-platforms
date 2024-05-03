using System;
using System.Collections.Generic;

public class StudentAverageMarkComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        if (x == null && y == null)
            return 0;
        if (x == null)
            return -1;
        if (y == null)
            return 1;

        double averageMarkX = x.AverageMark;
        double averageMarkY = y.AverageMark;

        return averageMarkX.CompareTo(averageMarkY);
    }
}
