using System.Collections.Generic;

namespace WebApplication4.Database.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
