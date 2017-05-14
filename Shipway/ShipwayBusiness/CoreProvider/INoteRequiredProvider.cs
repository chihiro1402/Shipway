using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface INoteRequiredProvider
    {
        NoteRequired GetNoteRequiredById(int id);
        List<NoteRequired> GetAllNoteRequired();
    }
}
