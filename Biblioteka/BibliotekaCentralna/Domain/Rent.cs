using BibliotekaCentralna.Model;

namespace BibliotekaCentralna.Domain
{
    public class Rent: Entity
    {
        public int MemberId { get; set; }
        public int Count { get; set; }
    }
}
