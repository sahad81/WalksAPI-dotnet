using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sahadLearn.API.customValidate;
using sahadLearn.API.Data;
using sahadLearn.API.models.domains;
using sahadLearn.API.models.DTO;
using sahadLearn.API.Repository;

namespace sahadLearn.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly sahadLearnDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(sahadLearnDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var regi = await regionRepository.GetAllAsync();

            //var regionDTO = new List<RegionDTO>();

            //foreach (var region in regi)
            //{
            //    regionDTO.Add(new RegionDTO
            //    {
            //        id = region.id,
            //        name = region.name,
            //        Code = region.Code

            //    });
            //}

            var regionDTO = mapper.Map<List<RegionDTO>>(regi);

            return Ok(new
            {
                result = regionDTO
            });
        }



        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetById(Guid id)
        {
            var region = await regionRepository.GetById(id);

            if (region == null)
            {
                return NotFound(new
                {
                    result = "Region not found"
                });
            }

            var regionDTO = mapper.Map<RegionDTO>(region);

            return Ok(new
            {
                result = regionDTO
            });
        }
        [HttpPost]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateRegionDTO regionbody)
        {

            var region = mapper.Map<Region>(regionbody);

            region = await regionRepository.Create(region);


            var regionDTO = mapper.Map<SignleRegionDTO>(region);

            return Ok(new
            {
                result = CreatedAtAction(nameof(GetById), new { id = regionDTO.id }, regionDTO)
            });

        
    
           
        }



        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateRegionDTO regionbody)
        {
            var Region = mapper.Map<Region>(regionbody);
            Region = await regionRepository.Update(Region, id);

            if (Region == null)
            {
                return NotFound(new
                {
                    result = "Region not found"
                });
            }

         

            var regionDTO = mapper.Map<SignleRegionDTO>(Region);

            return Ok(new
            {
                result = regionDTO
            });
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var region = await regionRepository.Delete(id);

            if (region == null)
            {
                return NotFound(new
                {
                    result = "Region not found"
                });
            }

           

            return Ok(new
            {
                result = "Item deleted successfully"
            });
        }
    }

    }