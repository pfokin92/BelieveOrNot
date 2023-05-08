namespace BelieveOrNot
{
    public class BaseQuestion
    {
        public string Text { get; set; }
        public bool Answer { get; set; }
        public string Description { get; set; }

        //public override string ToString()
        //{
        //    return $"Question: {Text}, Answer {Answer}, Description {Description}";
        //}

        public static BaseQuestion ParseFileCsv(string line)
        {
            string[] parts = line.Split(";");
            return new BaseQuestion()
            {
                Text = parts[0],
                Answer = parts[1] == "Yes",
                Description = parts[2]
            };
        }


    }
}
