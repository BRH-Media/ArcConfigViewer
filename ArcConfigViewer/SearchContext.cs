namespace ArcConfigViewer
{
    public class SearchContext
    {
        public string SearchTerm { get; set; } = @"";
        public string SearchColumn { get; set; } = @"";
        public bool SearchSubmitted { get; set; } = false;
    }
}