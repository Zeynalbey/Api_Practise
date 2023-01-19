namespace WebApplication4.Database.Model
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImageGuidName { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
