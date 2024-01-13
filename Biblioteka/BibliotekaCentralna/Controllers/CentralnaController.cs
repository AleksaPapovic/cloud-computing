﻿using BibliotekaCentralna.Dto;
using BibliotekaCentralna.Service;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekaCentralna.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CentralnaController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly ILogger<CentralnaController> _logger;

        public CentralnaController(IMemberService memberService, ILogger<CentralnaController> logger)
        {
            _memberService = memberService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<MemberDto?>> RegisterMember(RegisterMemberDto registerMember)
        {
            return Ok(await _memberService.RegisterMember(registerMember));
        }

        [HttpPost("rent-book")]
        public async Task<ActionResult<RentDto?>> RentBook(RentBookDto rentBook)
        {
            return Ok(await _memberService.RentBook(rentBook));
        }
    }
}
