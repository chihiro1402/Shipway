using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface IExhibitionStatusProvider
    {
        ExhibitionStatus GetExhibitionStatusById(int id);
        List<ExhibitionStatus> GetAllExhibitionStatus();
        int GetIdOfExhibitionStatus(string name);
    }
}
