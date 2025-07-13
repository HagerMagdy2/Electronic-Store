using ElectronicStore.Core.Entities.Product;
using ElectronicStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.infrastructure.Repositries
{
    public class PhotoRepositry:GenericRepositry<Photo>, IPhotoRepositry
    {
    }
}
