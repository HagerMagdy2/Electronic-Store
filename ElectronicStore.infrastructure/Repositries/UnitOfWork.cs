﻿using AutoMapper;
using ElectronicStore.Core.Interfaces;
using ElectronicStore.Core.Services;
using ElectronicStore.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.infrastructure.Repositries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly  AppDbContext _context;
        private readonly IMapper mapper;
        private readonly IImageManagementService imageManagementService;

        public ICategoryRepositry CategoryRepositry { get; }

        public IPhotoRepositry PhotoRepositry { get; }

        public IProductRepositry ProductRepositry { get; }


        public UnitOfWork(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService)
        {
            _context = context;
            this.mapper = mapper;
            this.imageManagementService = imageManagementService;
            CategoryRepositry = new CategoryRepositry(_context);
            PhotoRepositry = new PhotoRepositry(_context);
            ProductRepositry = new ProductRepositry(_context, mapper, imageManagementService);
           
        }
    }
}
