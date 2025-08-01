﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepositry CategoryRepositry { get;  }
        public IPhotoRepositry  PhotoRepositry { get;  }
        public IProductRepositry ProductRepositry { get;  }
    }
}
