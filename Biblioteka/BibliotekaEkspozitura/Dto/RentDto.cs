namespace BibliotekaEkspozitura.Dto
{
    public record RentDto
    {
        public int MemberId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

    public record RentBookDto
    {
        public int MemberId { get; set; }
        public int? Count { get; set; }
    }
}
