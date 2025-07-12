using ElectronicStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.infrastructure.Repositries
{
    public class GenericRepositry<T>:IGenericRepositry<T> where T : class
    {
    }
}
