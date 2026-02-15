namespace exe1.Dto
{
    public class DtoInsertPrize
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int DonorId { get; set; }
        public int? CategoryId { get; set; }
        public string? ImgUrl { get; set; }

    }
    public class PrizeUpdateDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int DonorId { get; set; }
        public int? CategoryId { get; set; }
        public string? ImgUrl { get; set; }

    }

}
