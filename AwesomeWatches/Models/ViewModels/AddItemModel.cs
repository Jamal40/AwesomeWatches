namespace AwesomeWatches.Models.ViewModels;

public class AddItemModel
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CategoriesString { get; set; }
    public IFormFile Picture { get; set; }

}
