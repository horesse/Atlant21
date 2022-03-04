﻿using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class AtlantService : IAtlantService
    {
        IUnitOfWork Database { get; set; }

        public AtlantService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<KeepersDTO> GetKeepers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Keepers, KeepersDTO>()).CreateMapper();
            var Keepers = mapper.Map<IEnumerable<Keepers>, List<KeepersDTO>>(Database.Keepers.GetAll());
            
            List<KeepersDTO> Result = new List<KeepersDTO>();
            foreach (var k in Keepers)
            {
                int id = k.Id;
                string name = k.Name;
                var count = Database.Keepers.MathCount(id);

                Result.Add(new KeepersDTO { 
                    Id = id,
                    Name = name,
                    Count = count
                });
            }
            
            return Result;
        }

        public IEnumerable<DetailsDTO> GetDetails()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Details, DetailsDTO>()).CreateMapper();
            var Details = mapper.Map<IEnumerable<Details>, List<DetailsDTO>>(Database.Details.GetAll());
            return Details;
        }

        public void AddKeeper(KeepersDTO KeepersDTO)
        {
            Keepers Keepers = new Keepers
            {
                Id = KeepersDTO.Id,
                Name = KeepersDTO.Name
            };
            Database.Keepers.Create(Keepers);
            Database.Save();
        }

        public void AddDetail(DetailsDTO DetailsDTO)
        {
            Details Details = new Details
            {
                Id = DetailsDTO.Id,
                Name = DetailsDTO.Name,
                Num = DetailsDTO.Num,
                Count = DetailsDTO.Count,
                CreateDate = DetailsDTO.CreateDate,
                KeepersId = DetailsDTO.KeepersId,
                DeleteDate = DetailsDTO.DeleteDate
            };
            Database.Details.Create(Details);
            Database.Save();
        }

        public void DeleteKeeper(int id)
        {
            Database.Keepers.Delete(id);
        }

        public void DeleteDetail(DetailsDTO DetailsDTO)
        {
            Details Details = new Details
            {
                Id = DetailsDTO.Id,
                Name = DetailsDTO.Name,
                Num = DetailsDTO.Num,
                Count = DetailsDTO.Count,
                CreateDate = DetailsDTO.CreateDate,
                KeepersId = DetailsDTO.KeepersId,
                DeleteDate = DetailsDTO.DeleteDate
            };
            Database.Details.Update(Details);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
