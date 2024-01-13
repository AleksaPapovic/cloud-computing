
using BibliotekaCentralna.Model;

namespace BibliotekaCentralna.Repository
{
    public interface IMemberRepository
    {
        Task<Member> GetByJMBG(string jmbg);
        Task<Member> CreateMember(string member);
    }
}
