using BibliotekaEkspozitura.Dto;
using BibliotekaEkspozitura.Service;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekaEkspozitura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EkspozituraController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly ILogger<EkspozituraController> _logger;

        public EkspozituraController(IMemberService memberService, ILogger<EkspozituraController> logger)
        {
            _memberService = memberService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<MemberDto?>> RegisterMember(RegisterMemberDto registerMember)
        {
            return Ok(await _memberService.RegisterMember(registerMember));
        }

        [HttpPost("rent")]
        public async Task<ActionResult<RentDto?>> RentBook(RentBookDto rentBook)
        {
            return Ok(await _memberService.RentBook(rentBook));
        }

        [HttpPost("return")]
        public async Task<ActionResult<RentDto?>> ReturnBook(ReturnBookDto returnBook)
        {
            return Ok(await _memberService.ReturnBook(returnBook));
        }
    }
}
