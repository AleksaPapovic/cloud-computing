using BibliotekaCentralna.Domain;
using BibliotekaCentralna.Model;

namespace BibliotekaCentralna.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly CentralnaDbContext _centralnaDb;
        public MemberRepository(CentralnaDbContext centralnaDb) {
            _centralnaDb = centralnaDb;
        }
        public async Task<Member> CreateMember(string member)
        {
            //throw new NotImplementedException();
            return new Member();
        }

        public async Task<Member> GetByJMBG(string jmbg)
        {
            //throw new NotImplementedException();
            return new Member() { Id=1,FirstName="test", LastName="test",Address = "test", JMBG="test"};
        }
    }
}
