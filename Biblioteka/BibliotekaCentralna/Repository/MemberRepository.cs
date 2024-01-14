using BibliotekaCentralna.Domain;
using BibliotekaCentralna.Model;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaCentralna.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly CentralnaDbContext _centralnaDb;
        public MemberRepository(CentralnaDbContext centralnaDb)
        {
            _centralnaDb = centralnaDb;
        }
        public async Task<Member> CreateMember(Member newMember)
        {
            Member member = _centralnaDb.Members.Add(newMember).Entity;
            await _centralnaDb.SaveChangesAsync();
            return member;
        }

        public async Task<Member?> GetById(int id)
        {
            return await _centralnaDb.Members.FirstOrDefaultAsync(member => member.Id == id);
        }

        public async Task<Member?> GetByJMBG(string jmbg)
        {
            return await _centralnaDb.Members.FirstOrDefaultAsync(member => member.JMBG.Equals(jmbg));
        }

        public async Task<int> GetRentCount(int memberId)
        {
            Rent? rent = await _centralnaDb.Rents.FirstOrDefaultAsync(member => member.Id == memberId);
            if(rent != null)
            {
                return rent.Count;
            }
            return 0;
        }

        public async Task<int> CreateRent(int memberId)
        {
            Rent? rent = await _centralnaDb.Rents.FirstOrDefaultAsync(member => member.Id == memberId);
            if (rent == null)
            {
                rent = new Rent() { MemberId = memberId, Count = 1 };
                await _centralnaDb.Rents.AddAsync(rent);
            }
            else
            {
                rent.Count += 1;
                _centralnaDb.Rents.Update(rent);
            }
            await _centralnaDb.SaveChangesAsync();
            return rent.Count;
        }

        public async Task<int> DeleteRent(int memberId)
        {
            Rent? rent = await _centralnaDb.Rents.FirstOrDefaultAsync(member => member.Id == memberId);
            if (rent != null)
            {
                if(rent.Count == 0)
                {
                    return 0;
                }
                rent.Count -= 1;
                _centralnaDb.Rents.Update(rent);
                await _centralnaDb.SaveChangesAsync();
                return rent.Count;
            }
            return 0;
        }
    }
}
