using AutoMapper;
using HotelListings.IRepository;
using HotelListings.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelListings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger, IMapper mapper)
        {
            _unitofWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _unitofWork.Hotels.GetAll();
                var result = _mapper.Map<IList<HotelDTO>>(hotels);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(GetHotels)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpGet("GetHotelById")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            try
            {
                var hotel = await _unitofWork.Hotels.Get(x => x.Id == id, new List<string> { "Countries" });
                var result = _mapper.Map<HotelDTO>(hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the {nameof(GetHotelById)}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

    }
}
