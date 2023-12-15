using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    //https://localhost:port/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepositaory _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepositaory regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }


        // get All Regions
        //GET: https://localhost:port/apt/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();
            return Ok(_mapper.Map<List<RegionDTO>>(regions));
        }

        // Get single Region
        //Link: https://localhost:post/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = _DbContext.Regions.Find(id);
            var regions = await _regionRepository.GetByIdAsync(id);

            if (regions == null)
                return NotFound();
            // Convert to DTO
            return Ok(_mapper.Map<RegionDTO>(regions));
        }


        // Create new Region
        //Post: https://localhost:port/api/regions

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionDTO)
        {

            //map or convert DTO to Domain Model
            var RegionDm = _mapper.Map<Region>(addRegionDTO);
            //Use Domain Model to Create Region
            var regionDm = await _regionRepository.CreateAsync(RegionDm);

            // map Dm to DTO

            var RegionDto = _mapper.Map<RegionDTO>(regionDm);
            return CreatedAtAction(nameof(GetById), new { id = RegionDto.Code }, RegionDto);
        }

        // Update An existing region
        // PUT: Https://localhost:port/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateNewRegionDTO updatedRegionDto)
        {
            // mapp DTO to DM
            var UpdatedRegion = _mapper.Map<Region>(updatedRegionDto);
            var regionDM = await _regionRepository.UpdateAsync(id, UpdatedRegion);

            if (regionDM == null)
            {
                return NotFound();
            }

            // Convert Domain Model to DTO

            var regionDto = _mapper.Map<RegionDTO>(regionDM);
            return Ok(regionDto);
        }


        //Delete an existing region
        //DELETE; https://localhost:port/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var RegionDm = await _regionRepository.DeleteAsync(id);
            //map Dm to Dto
            if (RegionDm == null)
                return NotFound();
            // return Deleted Object (region) back
            return Ok(_mapper.Map<RegionDTO>(RegionDm));
        }

    }
}

