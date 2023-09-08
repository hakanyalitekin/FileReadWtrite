namespace FileReadWtrite.Entities
{
    public class FileStore
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
