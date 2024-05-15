namespace Parameters;

// Parameter Object

public abstract class SearchCriteria
{

}

public class ProductSearchCriteria : SearchCriteria
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double MinPrice { get; set; }
    public double MaxPrice { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    public bool IncludeOutOfStock { get; set; }
    public float Weight { get; set; }
}

public class CustomerSearchCriteria : SearchCriteria
{

}

public interface IProductRepository
{
    List<Product> SearchProducts(ProductSearchCriteria searchCriteria);
}

public class ProductRepository : IProductRepository
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

    public List<Product> SearchProducts(ProductSearchCriteria searchCriteria
    )
    {
        // Perform the search with the provided criteria using LINQ
        var query = _products.AsQueryable();

        if (!string.IsNullOrEmpty(searchCriteria.Name))
        {
            query = query.Where(p => p.Name.Contains(searchCriteria.Name, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(searchCriteria.Category))
        {
            query = query.Where(p => p.Category.Equals(searchCriteria.Category, StringComparison.OrdinalIgnoreCase));
        }

        if (searchCriteria.MinPrice > 0)
        {
            query = query.Where(p => p.Price >= searchCriteria.MinPrice);
        }

        if (searchCriteria.MaxPrice > 0)
        {
            query = query.Where(p => p.Price <= searchCriteria.MaxPrice);
        }

        if (!string.IsNullOrEmpty(searchCriteria.Color))
        {
            query = query.Where(p => p.Color.Equals(searchCriteria.Color, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(searchCriteria.Size))
        {
            query = query.Where(p => p.Size.Equals(searchCriteria.Size, StringComparison.OrdinalIgnoreCase));
        }

        if (!searchCriteria.IncludeOutOfStock)
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