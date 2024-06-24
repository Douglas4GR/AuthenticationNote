using Microsoft.AspNetCore.Mvc;

using AuthenticationNote.Data;
using AuthenticationNote.Models.DTO;

namespace AuthenticationNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly AuthDbContext dbContext;

        public NotaController(AuthDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetNotas()
        {
            var todasNotas = dbContext.Notas.ToList();
            return Ok(todasNotas);
        }

        [HttpPost]
        public IActionResult PostNota(AddNotaDto addNotaDto)
        {
            var nota = new Models.Entidades.Nota
            {
                Descricao = addNotaDto.Descricao,
                DataNote = DateTime.Now
            };

            dbContext.Notas.Add(nota);
            dbContext.SaveChanges();
            return Ok(nota);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteNota(Guid id)
        {
            var nota = dbContext.Notas.Find(id);
            if (nota == null)
            {
                return NotFound();
            }

            dbContext.Notas.Remove(nota);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
