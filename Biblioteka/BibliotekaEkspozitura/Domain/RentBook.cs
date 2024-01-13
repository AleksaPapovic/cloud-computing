namespace BibliotekaEkspozitura.Domain
{
    public class RentBook : Entity
    {
        public int MemberId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
