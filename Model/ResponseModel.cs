namespace PMS.Model
{
    public class ResponseModel
    {
        public bool error_status { get; set; }
        public string? error_message { get; set; }
        public object? data { get; set; }
    }

    public class ProjData
    {
        public List<ProjModel>? Mid { get; set; }
        public List<ProjModel>? Low { get; set; }
        public List<ProjModel>? High { get; set; }

    }
}