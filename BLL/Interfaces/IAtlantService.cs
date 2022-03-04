using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAtlantService
    {
        IEnumerable<KeepersDTO> GetKeepers();
        IEnumerable<DetailsDTO> GetDetails();
        void AddKeeper(KeepersDTO KeepersDTO);
        void AddDetail(DetailsDTO DetailsDTO);
        void DeleteDetail(DetailsDTO DetailsDTO);
        void DeleteKeeper(int id);
        void Dispose();
    }
}
