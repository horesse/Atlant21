using System;
using System.Collections.Generic;
using Atlant21.WEB.Models;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atlant21.WEB.Controllers
{
    [ApiController]
    [Route("api/details")]
    public class DetailsController : Controller
    {
        IAtlantService db;
        public DetailsController(IAtlantService serv)
        {
            db = serv;
        }

        [HttpGet]
        public List<DetailsViewModel> Get()
        {
            IEnumerable<DetailsDTO> Dtos = db.GetDetails();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DetailsDTO, DetailsViewModel>()).CreateMapper();
            var Details = mapper.Map<IEnumerable<DetailsDTO>, List<DetailsViewModel>>(Dtos);

            return Details;
        }

        [HttpPost]
        public IActionResult Post(DetailsViewModel Details)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DetailsViewModel, DetailsDTO>()).CreateMapper();
                var DetailsDTO = mapper.Map<DetailsViewModel, DetailsDTO>(Details);
                db.AddDetail(DetailsDTO);
                return Ok(DetailsDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return BadRequest(ModelState);

        }
        
        [HttpPut]
        public IActionResult Put(DetailsViewModel Details)
        {
            if (Details != null)
            {
                Details.DeleteDate = DateTime.Now;

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DetailsViewModel, DetailsDTO>()).CreateMapper();
                var DetailsDTO = mapper.Map<DetailsViewModel, DetailsDTO>(Details);

                db.DeleteDetail(DetailsDTO);
            }
            return Ok(Details);
        } 
    }
}
