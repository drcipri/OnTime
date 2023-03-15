namespace OnTime.Models
{
    public class Classification
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
    }

    //this class is the template for Classification
    public static class ClassificationTypes
    {
        public static string Awaiting { get; } = "Awaiting";
        public static string Succesfull { get; } = "Succesfull";
        public static string Missed { get; } = "Missed";
        public static string Canceled { get; } = "Canceled";
    }
}
