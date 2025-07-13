using ElectronicStore.Core.Entities.Product;
using ElectronicStore.Core.Interfaces;
using ElectronicStore.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.infrastructure.Repositries
{
    public class CategoryRepositry : GenericRepositry<Category>, ICategoryRepositry
    {
        private AppDbContext context;

        public CategoryRepositry(AppDbContext context)
        {
            this.context = context;
        }
    }
}
