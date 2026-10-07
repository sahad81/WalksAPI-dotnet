using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sahadLearn.API.Data;
using sahadLearn.API.mapping;
using sahadLearn.API.models.domains;
using sahadLearn.API.models.DTO;
using sahadLearn.API.Repository;

namespace sahadLearn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : Controller
    {


        private readonly IMapper mapper;
        private readonly IwalkRepository repo;
        public WalkController(IMapper mappper, IwalkRepository repo
            )
        {
            this.repo = repo;
            this.mapper = mappper;


        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] WalksCreateDTO createWalkDTO)
        {
            try
            {
                var walk = mapper.Map<Walk>(createWalkDTO);

                walk = await repo.Create(walk);

                // fetch the single walk again, with Region and Difficulty included
                var createdWalk = await repo.GetSingle(walk.id);

                if (createdWalk == null)
                    return NotFound("Walk was created but could not be found.");

                var walkDTO = mapper.Map<WalksSingleDTO>(createdWalk);

                return CreatedAtAction(nameof(GetById), new { id = walkDTO.id }, walkDTO);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Could not save the walk. {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong while creating the walk. {ex.Message}");
            }
        }



        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] String? searchKey ,Guid? regionID)
        {
            var walk = await repo.GetAll(searchKey , regionID);



            var walkDTO = mapper.Map<List<WalksDTO>>(walk);

            return Ok(new
            {
                result = walkDTO
            });

        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walk = await repo.GetSingle(id);

            if (walk == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<WalksSingleDTO>(walk);

            return Ok(new
            {
                result = walkDTO
            });
        }
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] WalksCreateDTO updateWalkDTO)
        {
            try
            {
                var walk = mapper.Map<Walk>(updateWalkDTO);

                var updated = await repo.Update(walk, id);

                if (updated == null)
                    return NotFound();

                var walkDTO = mapper.Map<WalksSingleDTO>(updated);

                return Ok(new { result = walkDTO });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Could not update the walk. {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong while updating the walk. {ex.Message}");
            }
        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var region = await repo.Delete(id);

            if (region == null)
            {
                return NotFound(new
                {
                    result = "Walk not found"
                });
            }



            return Ok(new
            {
                result = "Item deleted successfully"
            });
        }



    }
}

