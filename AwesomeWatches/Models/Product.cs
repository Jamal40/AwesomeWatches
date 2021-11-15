namespace AwesomeWatches.Models
{
    public class Product
    {
        public Product()
        {
            Categories = new HashSet<Category>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Item Item { get; set; }
    }
}
