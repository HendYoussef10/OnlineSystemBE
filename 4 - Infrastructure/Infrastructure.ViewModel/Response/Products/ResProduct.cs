using Infrastructure.ViewModel.Response.Products;

namespace Infrastructure.ViewModel.Response.Product
{
    public class ResProduct
    {
        public Guid Id { set; get; }
        public Guid CategoryId { set; get; }
        public string? Description { set; get; }
        public string? Name { set; get; }
        public string? NameEn { set; get; }

        public bool HasAvailableStock { set; get; }
        public decimal Price { set; get; }
        public string? Image { set; get; }
        public ResCategory? Category { get; set; }
    }
}
