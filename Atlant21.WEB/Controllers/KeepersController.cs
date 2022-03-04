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
    [Route("api/keepers")]
    public class KeepersController : Controller
    {
        IAtlantService db;
        public KeepersController(IAtlantService serv)
        {
            db = serv;
        }

        [HttpGet]
        public List<KeepersViewModel> Get()
        {
            IEnumerable<KeepersDTO> KeeperDtos = db.GetKeepers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KeepersDTO, KeepersViewModel>()).CreateMapper();
            var Keepers = mapper.Map<IEnumerable<KeepersDTO>, List<KeepersViewModel>>(KeeperDtos);

            return Keepers;
        } 

        [HttpPost]
        public IActionResult Post(KeepersViewModel Keepers)
        {
            try
            {
                var KeepersDTO = new KeepersDTO
                {
                    Id = Keepers.Id,
                    Name = Keepers.Name
                };
                db.AddKeeper(KeepersDTO);
                return Ok(KeepersDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeleteKeeper(id);
        }
    }
}
