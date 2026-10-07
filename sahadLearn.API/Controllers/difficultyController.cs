using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using sahadLearn.API.Data;
using sahadLearn.API.models.domains;
using sahadLearn.API.models.DTO;

namespace sahadLearn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class difficultyController : ControllerBase
    {
        private readonly sahadLearnDbContext dbContext;

        public difficultyController(sahadLearnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var defficulties = await dbContext.Difficulties.ToListAsync();

            var DifficultiesDTO = new List<difficultyDTO>();

            foreach (var def in defficulties)
            {
                DifficultiesDTO.Add(new difficultyDTO
                {
                    id = def.id,
                    name = def.name,
                  

                });
            }

            return Ok(new
            {
                result = DifficultiesDTO
            });
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var difficulty = await dbContext.Difficulties
                .FirstOrDefaultAsync(x => x.id == id);

            if (difficulty == null)
            {
                return NotFound(new
                {
                    result = "Region not found"
                });
            }

            var defficultyDTO = new difficultyDTO
            {
                id = difficulty.id,
                name = difficulty.name,
           
            };

            return Ok(new
            {
                result = defficultyDTO
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] difficultyDTOCreateAndUpdate difficultyBody)
        {
            var dif = new Difficulty
            {
                id = Guid.NewGuid(),
                name = difficultyBody.name,
             
            };

            await dbContext.Difficulties.AddAsync(dif);
            await dbContext.SaveChangesAsync();

            var difficultyRTO = new difficultyDTO
            {
                id = dif.id,
                name = dif.name,
             
            };

            return Ok(new
            {
                result = CreatedAtAction(nameof(GetById), new { id = difficultyRTO.id }, difficultyRTO)
            });
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] difficultyDTOCreateAndUpdate difficultyBody)
        {
            var difficulty = await dbContext.Difficulties
                .FirstOrDefaultAsync(x => x.id == id);

            if (difficulty == null)
            {
                return NotFound(new
                {
                    result = "Region not found"
                });
            }

            difficulty.name = difficultyBody.name;
          

            await dbContext.SaveChangesAsync();

            var difficultyRTO = new difficultyDTO
            {
                id = difficulty.id,
                name = difficulty.name,
               
            };

            return Ok(new
            {
                result = difficultyRTO
            });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var difficulty = await dbContext.Difficulties
                .FirstOrDefaultAsync(x => x.id == id);

            if (difficulty == null)
            {
                return NotFound(new
                {
                    result = "Difficulty not found"
                });
            }

            dbContext.Difficulties.Remove(difficulty);

            await dbContext.SaveChangesAsync();

            return Ok(new
            {
                result = "Item deleted successfully"
            });
        }


    }
}
