using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface IProvinceProvider
    {
        List<Province> GetAllProvince();
        Province GetProvinceById(string id);
        List<Province> GetListProvinceByRegion(int region);
        int GetRegionOfProvince(string provinceName);
    }
}
