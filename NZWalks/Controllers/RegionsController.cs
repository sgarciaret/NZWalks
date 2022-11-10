using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = regionRepository.GetAllAsync();

            // return DTO regions

            //var regionsDTO = new List<Models.DTO.RegionDTO>();

            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.DTO.RegionDTO() { 
            //        Id = region.Id,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //    };

            //    regionsDTO.Add(regionDTO);
            //});

            var regionsDTO = mapper.Map<List<Models.DTO.RegionDTO>>(regions);

            return Ok(regionsDTO);
        }
    }
}
