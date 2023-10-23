namespace FullStackAuth_WebAPI.Models
{
    public class AnimeResponse
    {
        public List<AnimeData> Data { get; set; }
    }
    public class AnimeData
    {
        public AnimeNode Node { get; set; }
    }
    public class AnimeNode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AnimePicture MainPicture { get; set; }
    }

    public class AnimePicture
    {
        public string Medium { get; set; }
        public string Large { get; set; }
    }
}
