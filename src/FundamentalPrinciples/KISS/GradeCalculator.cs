namespace KISS;

public class GradeCalculator
{
    public double CalculateAverageGrade(List<double> grades)
    {
        if (grades == null || !grades.Any())
        {
            throw new ArgumentException("Grade list cannot be null or empty.");
        }

        return grades.Average();
    }

   

}
