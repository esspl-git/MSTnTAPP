namespace MSTnTAPP.Models
{
    public class SearchCriterion
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public SearchCriterion(int id, string label)
        {
            Id = id;
            Label = label;
        }
    }
}
