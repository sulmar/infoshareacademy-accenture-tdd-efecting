namespace Parameters;

public class ProductRepository
{
    private List<Product> _products;

    public ProductRepository()
    {
        // Initialize with some sample data
        _products = new List<Product>
        {
            new Product { Name = "Product1", Category = "Electronics", Price = 50.0, Color = "Red", Size = "M", InStock = true },
            new Product { Name = "Product2", Category = "Books", Price = 15.0, Color = "Blue", Size = "L", InStock = false },
            new Product { Name = "Product3", Category = "Electronics", Price = 70.0, Color = "Red", Size = "S", InStock = true }
            // Add more products as needed
        };
    }

    public List<Product> SearchProducts(
        string name,
        string category,
        double minPrice,
        double maxPrice,
        string color,
        string size,
        bool includeOutOfStock
    )
    {
        // Perform the search with the provided criteria using LINQ
        var query = _products.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        if (minPrice > 0)
        {
            query = query.Where(p => p.Price >= minPrice);
        }

        if (maxPrice > 0)
        {
            query = query.Where(p => p.Price <= maxPrice);
        }

        if (!string.IsNullOrEmpty(color))
        {
            query = query.Where(p => p.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(size))
        {
            query = query.Where(p => p.Size.Equals(size, StringComparison.OrdinalIgnoreCase));
        }

        if (!includeOutOfStock)
        {
            query = query.Where(p => p.InStock);
        }

        return query.ToList();
    }


}


public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    public bool InStock { get; set; }
}