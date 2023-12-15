using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IWalksRepository _WalksRepository;
        public WalksController(IMapper mapper, IWalksRepository walksRepository)
        {
            _Mapper = mapper;
            _WalksRepository = walksRepository;
        }


        // create new walk
        //Post: /api/wlaks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody] AddWalksDTO addwalksdto)
        {
            // mapp this DTO to DM 
            var walks = _Mapper.Map<Walk>(addwalksdto);
            await _WalksRepository.CreateAsync(walks);
            var returnedWalk = _Mapper.Map<WalkDTO>(walks);
            return Ok(returnedWalk);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Walks = await _WalksRepository.GetAllAsync();
            var WalkDTO = _Mapper.Map<List<WalkDTO>>(Walks);
            return Ok(WalkDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var walk = await _WalksRepository.GetByIdAsync(id);
            if (walk == null)
                return NotFound();
            var walkDto = _Mapper.Map<WalkDTO>(walk);
            return Ok(walkDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateWalkDTO updateWalkDTO)
        {
            var walkDM = _Mapper.Map<Walk>(updateWalkDTO);
            walkDM = await _WalksRepository.PutAsync(id, walkDM);
            if (walkDM == null)
                return NotFound();
            return Ok(_Mapper.Map<WalkDTO>(walkDM));
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deletedWalk = await _WalksRepository.DeleteAsync(id);
            if (deletedWalk == null)
                return NotFound();

            return Ok(_Mapper.Map<WalkDTO>(deletedWalk));
        }
    }
}

