
using BibliotekaCentralna.Model;

namespace BibliotekaCentralna.Repository
{
    public interface IMemberRepository
    {
        Task<Member?> GetById(int id);
        Task<Member> GetByJMBG(string jmbg);
        Task<Member?> CreateMember(Member newMember);
        Task<int> GetRentCount(int memberId);
        Task<int> CreateRent(int memberId);
        Task<int> DeleteRent(int memberId);
    }
}
