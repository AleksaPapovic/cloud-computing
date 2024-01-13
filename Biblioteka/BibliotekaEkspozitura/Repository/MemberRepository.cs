using BibliotekaEkspozitora.Domain;

namespace BibliotekaEkspozitura.Repository
{
    public class MemberRepository: IMemberRepository
    {
        private readonly EkspozituraDbContext _ekspozituraDb;
        public MemberRepository(EkspozituraDbContext ekspozituraDb)
        {
            _ekspozituraDb = ekspozituraDb;
        }
    }
}
