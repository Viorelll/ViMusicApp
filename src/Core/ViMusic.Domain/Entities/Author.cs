namespace ViMusic.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        #region Links
        public virtual Song Song { get; set; }
        #endregion
    }
}
