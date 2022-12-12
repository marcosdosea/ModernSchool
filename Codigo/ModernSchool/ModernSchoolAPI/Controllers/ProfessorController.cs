using AutoMapper;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModernSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public ProfessorController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

   
        // GET: api/<ProfessorController>
        [HttpGet]
        public ActionResult Get()
        {
            var lista = _pessoaService.GetAllAPI();
            var model = _mapper.Map<List<ProfessorViewModel>>(lista);

            return Ok(lista);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            PessoaProfessorDTO? professor = _pessoaService.GetProfessorDTO(id);

            if (professor == null)
                return NotFound();

            return Ok(professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
