using BlazorContactos.Server.Model.Entities;
using BlazorContactos.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorContactos.Shared.DTOs.MediosContactos;


namespace BlazorContactos.Server.Controllers
{
    public class MediosContactosController
    {
        [ApiController, Route("api/medioscontactos")]

        public class MedioContactosController : ControllerBase
        {
            private readonly ApplicationDbContext context;

            public MedioContactosController(ApplicationDbContext context)
            {
                this.context = context;
            }

            [HttpGet]
            public async Task<ActionResult<List<MedioContactoDTO>>> GetMediosContactos()
            {
                var medioscontactos = await context.MediosContactos.ToListAsync();

                var medioscontactosDto = new List<MedioContactoDTO>();

                foreach (var mediocontacto in medioscontactos)
                {
                    var mediocontactoDto = new MedioContactoDTO();
                    mediocontactoDto.Id = mediocontacto.Id;
                    mediocontactoDto.Email = mediocontacto.Email;
                    mediocontactoDto.Telefono = mediocontacto.Telefono;
                    mediocontactoDto.Celular = mediocontacto.Celular;
                    mediocontactoDto.ContactoId = mediocontacto.ContactoId;

                    medioscontactosDto.Add(mediocontactoDto);
                }
                return medioscontactosDto;
            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult<MedioContactoDTO>> GetMediosContacto(int id)
            {
                var mediocontacto = await context.MediosContactos
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (mediocontacto == null)
                {
                    return NotFound();
                }

                var mediocontactoDto = new MedioContactoDTO();
                mediocontactoDto.Id = mediocontacto.Id;
                mediocontactoDto.Email = mediocontacto.Email;
                mediocontactoDto.Telefono = mediocontacto.Telefono;
                mediocontactoDto.Celular = mediocontacto.Celular;
                mediocontactoDto.ContactoId = mediocontacto.ContactoId;


                return mediocontactoDto;
            }

            [HttpPost]
            public async Task<ActionResult> Add([FromBody] MedioContactoDTO mediocontactoDto)
            {
                var mediocontacto = new MedioContacto();
                mediocontacto.Email = mediocontactoDto.Email;

                context.MediosContactos.Add(mediocontacto);
                await context.SaveChangesAsync();
                return Ok();
            }

            [HttpPut]
            public async Task<ActionResult> Edit([FromBody] MedioContactoDTO mediocontactoDto)
            {
                var mediocontactoDb = await context.MediosContactos
                    .FirstOrDefaultAsync(x => x.Id == mediocontactoDto.Id);

                if (mediocontactoDb == null)
                {
                    return NotFound();
                }

                mediocontactoDb.Email = mediocontactoDto.Email;

                context.MediosContactos.Update(mediocontactoDb);
                await context.SaveChangesAsync();
                return Ok();
            }

            [HttpDelete("{id:int}")]
            public async Task<ActionResult> Delete(int id)
            {
                var mediocontactoDb = await context.MediosContactos
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (mediocontactoDb == null)
                {
                    return NotFound();
                }

                context.MediosContactos.Remove(mediocontactoDb);
                await context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
