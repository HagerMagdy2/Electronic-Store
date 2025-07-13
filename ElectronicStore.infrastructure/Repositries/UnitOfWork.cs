using ElectronicStore.Core.Interfaces;
using ElectronicStore.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.infrastructure.Repositries
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepositry CategoryRepositry { get; }

        public IPhotoRepositry PhotoRepositry { get; }

        public IProductRepositry ProductRepositry { get; }
        public UnitOfWork(AppDbContext _context)
        {
            context=_context
        }
    }
}
