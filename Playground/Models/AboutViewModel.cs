namespace Playground.Models
{
    public class AboutViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public DateTime Today => DateTime.Now;
    }
}
