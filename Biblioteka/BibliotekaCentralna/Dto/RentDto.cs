namespace BibliotekaCentralna.Dto
{
    public record RentBookDto
    {
        public int MemberId { get; set; }
        public int? Count { get; set; }
    }
}
