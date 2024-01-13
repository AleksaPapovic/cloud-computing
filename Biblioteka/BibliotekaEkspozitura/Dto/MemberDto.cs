namespace BibliotekaEkspozitura.Dto
{
    public record MemberDto : EntityDto
    {
    }

    public record RegisterMemberDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string JMBG { get; set; }
    }
}
