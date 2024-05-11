namespace KISS;

public class GradeCalculator
{
    public double CalculateAverageGrade(List<double> grades)
    {
        if (grades == null || grades.Count == 0)
        {
            throw new ArgumentException("Grade list cannot be null or empty.");
        }

        double sum = SumOfGrades(grades);
        double average = CalculateAverage(sum, grades.Count);
        return average;
    }

    private double SumOfGrades(List<double> grades)
    {
        double sum = 0;
        foreach (var grade in grades)
        {
            sum += grade;
        }
        return sum;
    }

    private double CalculateAverage(double sum, int count)
    {
        return sum / count;
    }
}
