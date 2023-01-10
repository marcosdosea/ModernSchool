using Microsoft.AspNetCore.Mvc;
using Core.Service;
using Core;
using AutoMapper;
using ModernSchoolAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModernSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {


        private readonly IAvaliacaoService _avaliacao;
        private readonly IMapper _mapper;

        public AvaliacaoController(IAvaliacaoService avaliacao, IMapper mapper)
        {
            _avaliacao = avaliacao;
            _mapper = mapper;
        }





        // GET: api/<AvaliacaoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaAvaliacao = _avaliacao.GetAll();
            var model = _mapper.Map<List<AvaliacaoViewModel>>(listaAvaliacao);
            return Ok(model);
        }

        // GET api/<AvaliacaoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var avaliacao = _avaliacao.Get(id);
            if (avaliacao == null)
                return NotFound();
            return Ok(avaliacao);
            
        }

        // POST api/<AvaliacaoController>
        [HttpPost]
        public ActionResult Post([FromBody] AvaliacaoViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest("Dados invalidos");

            var avaliacao = _mapper.Map<Avaliacao>(model);
            _avaliacao.Create(avaliacao);
            return Ok();

        }

        // PUT api/<AvaliacaoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AvaliacaoViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest("Dados invalidos");
            var avaliacao = _mapper.Map<Avaliacao>(model);
            avaliacao.Id = id;
            _avaliacao.Edit(avaliacao);
            return Ok();

        }

        // DELETE api/<AvaliacaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _avaliacao.Delete(id);
        }
    }
}
