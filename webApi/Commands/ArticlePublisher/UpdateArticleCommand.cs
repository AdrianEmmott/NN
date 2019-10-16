namespace webApi.Commands
{
    public class UpdateArticleCommand
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Summary { get; set; }

        public string HeaderImage { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string PublishDate { get; set; }
    }
}