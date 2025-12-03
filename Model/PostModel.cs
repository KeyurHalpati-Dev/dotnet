namespace PMS.Model
{
    public class UpsertPostsModel
    {
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public string? Caption { get; set; }
        public string? Image_Url { get; set; }
    }
    public class PostsListModel
    {
        public int? UserId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public bool? Is_Home { get; set; }
    }
}