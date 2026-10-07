using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sahadLearn.API.Data;
using sahadLearn.API.mapping;
using sahadLearn.API.models.domains;
using sahadLearn.API.models.DTO;
using sahadLearn.API.Repository;

using sahadLearn.API.helper;
namespace sahadLearn.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : Controller
    {

        private readonly IImageService imageService;
        private readonly IMapper mapper;
        private readonly IwalkRepository repo;
        public WalkController(IMapper mappper, IwalkRepository repo, IImageService imageService
            )
        {
            this.repo = repo;
            this.mapper = mappper;
            this.imageService = imageService;


        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromForm] WalksCreateDTO createWalkDTO)
        {
            var imageError = imageHelper.ValidateImage(createWalkDTO.ImageFile);
            if (imageError != null)
                ModelState.AddModelError("ImageFile", imageError);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var walk = mapper.Map<Walk>(createWalkDTO);

                if (createWalkDTO.ImageFile != null)
                    walk.WalkImageUrl = await imageService.Upload(createWalkDTO.ImageFile);

                walk = await repo.Create(walk);

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
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll9(
         [FromQuery] string? searchKey,
         [FromQuery] Guid? regionID,
         [FromQuery] int pageNo = 1,
         [FromQuery] int pageSize = 10)
        {
            var walks = await repo.GetAll(searchKey, regionID, pageNo, pageSize);

            var walkDTOs = mapper.Map<List<WalksDTO>>(walks.Items);

            return Ok(new PagedResult<WalksDTO>
            {
                Items = walkDTOs,
                TotalCount = walks.TotalCount,
                PageNo = walks.PageNo, 
                PageSize = walks.PageSize
            });
        }
        [Authorize]
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
        [Authorize]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] WalksCreateDTO updateWalkDTO)
        {
            var imageError = imageHelper.ValidateImage(updateWalkDTO.ImageFile);
            if (imageError != null)
                ModelState.AddModelError("ImageFile", imageError);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var walk = mapper.Map<Walk>(updateWalkDTO);

                string? oldImageUrl = null;
                if (updateWalkDTO.ImageFile != null)
                {
                    var existing = await repo.GetSingle(id);
                    oldImageUrl = existing?.WalkImageUrl;
                    walk.WalkImageUrl = await imageService.Upload(updateWalkDTO.ImageFile);
                }

                var updated = await repo.Update(walk, id);

                if (updated == null)
                    return NotFound();

                imageService.Delete(oldImageUrl); // remove old file after a successful update

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

        [Authorize]
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

