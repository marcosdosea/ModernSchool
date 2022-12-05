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
    public class AnoLetivoController : ControllerBase
    {
        private readonly IAnoLetivoService _anoLetivoService;
        private readonly IMapper _mapper;
        public AnoLetivoController(IAnoLetivoService anoLetivoService, IMapper mapper)
        {
            _anoLetivoService = anoLetivoService;
            _mapper = mapper;
        }
        // GET: api/<AnoLetivoController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaAnoLetivo = _anoLetivoService.GetAll();
            var listaAnoLetivosModel = _mapper.Map<List<AnoLetivoViewModel>>(listaAnoLetivo);
            return Ok(listaAnoLetivosModel);
        }

        // GET api/<AnoLetivoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Anoletivo anoLetivo = _anoLetivoService.Get(id);
            if (anoLetivo == null)
                return NotFound();
            return Ok(anoLetivo);
        }

        // POST api/<AnoLetivoController>
        [HttpPost]
        public ActionResult Post([FromBody] Anoletivo anoLetivo)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var anoletivo = _mapper.Map<Anoletivo>(anoLetivo);
            _anoLetivoService.Create(anoletivo);

            return Ok();
        }
        // PUT api/<AnoLetivoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Anoletivo anoLetivo)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var anoletivo = _mapper.Map<Anoletivo>(anoLetivo);
            if (anoletivo == null)
                return NotFound();

            _anoLetivoService.Edit(anoletivo);

            return Ok();
        }

        // DELETE api/<AnoLetivoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Anoletivo autor = _anoLetivoService.Get(id);
            if (autor == null)
                return NotFound();

            _anoLetivoService.Delete(id);
            return Ok();
        }
    }
}
