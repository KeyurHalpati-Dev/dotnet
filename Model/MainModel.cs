namespace PMS.Model
{
    public class EmpModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? pass { get; set; }
        public string? dept { get; set; }

    }

    public class ProjModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? detail { get; set; }
        public int LeadId { get; set; }
        public string? Priority { get; set; }
        public string? deadline { get; set; }
    }
}