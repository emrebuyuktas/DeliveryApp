using DeliveryApp.Core.Repositories.Abstract;
using DeliveryApp.Core.UnitOfWorks;
using DeliveryApp.Data.EntityFramework.Context;
using DeliveryApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private ProductRepository _productRepository;
        private ProductBrandRepository _brandRepository;
        private ProductTypeRepository _productTypeRepository;
        

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public IProductBrandRepository Brands => _brandRepository = _brandRepository ?? new BrandRepository(_context);

        public IProductTypeRepository Type => _productTypeRepository = _productTypeRepository ?? new TypeRepository(_context);

        public IProductBrandRepository Brand => throw new NotImplementedException();

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
