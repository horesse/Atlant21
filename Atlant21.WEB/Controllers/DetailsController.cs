using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Atlant21.WEB.Models;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using System;

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

            var DetailsDTO = new DetailsDTO
            {
                Id = Details.Id,
                Name = Details.Name,
                Num = Details.Num,
                Count = Details.Count,
                CreateDate = Details.CreateDate,
                KeepersId = Details.KeepersId,
                DeleteDate = null
            };

            db.AddDetail(DetailsDTO);
            return Ok(DetailsDTO);
        }
        
        [HttpPut]
        public IActionResult Put(DetailsViewModel Details)
        {
            if (Details != null)
            {
                var DetailsDTO = new DetailsDTO
                {
                    Id = Details.Id,
                    Name = Details.Name,
                    Num = Details.Num,
                    Count = Details.Count,
                    CreateDate = Details.CreateDate,
                    KeepersId = Details.KeepersId,
                    DeleteDate = DateTime.Now
                };

                db.DeleteDetail(DetailsDTO);
            }
            return Ok(Details);
        } 
    }
}
