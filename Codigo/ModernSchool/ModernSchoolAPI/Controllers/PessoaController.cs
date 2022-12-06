using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using ModernSchoolAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModernSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {


        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

    
        // GET: api/<PessoaController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaPessoa = _pessoaService.GetAll();
            var model = _mapper.Map<List<PessoaViewModel>>(listaPessoa);

            return Ok(listaPessoa);
        }

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Pessoa pessoa = _pessoaService.Get(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        // POST api/<PessoaController>
        [HttpPost]
        public ActionResult Post([FromBody] Pessoa pessoa)
        {
            if (ModelState.IsValid)
                return BadRequest("Dados invalidos.");
            var _pessoa = _mapper.Map<Pessoa>(pessoa);
            _pessoaService.Create(pessoa);
            return Ok();
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            if(ModelState.IsValid)
                return BadRequest("Dados invalidos.");
            var _pessoa = _mapper.Map<Pessoa>(pessoa);
            if (_pessoa == null)
            {
                return NotFound();
            }
            _pessoaService.Edit(_pessoa);
            return Ok();
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Pessoa _pessoa = _pessoaService.Get(id);
            if (_pessoa == null)
                return NotFound();
            _pessoaService.Delete(id);
            return Ok(); 
        }
    }
}
