﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.Domain.Dto.Product;
using WebStore.Domain.Entities;
using WebStore.Domain.Filters;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Sql
{
    /// <summary>
    /// Layer between CatalogController and Database
    /// Responsible for getting, updating for controller and view data transfer to the database 
    /// </summary>
    public class SqlProductData : IProductData
    {
        private readonly IMapper _mapper;
        private readonly WebStoreContext _context;

        public SqlProductData(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<BrandDto> GetBrands()
        {
            var brands = _mapper.Map<IEnumerable<BrandDto>>(_context.Brands.ToList());

            return brands;
        }

        public PagedProductDto GetProducts(ProductFilter filter)
        {
            var query = _context.Products
                .Include("Brand")
                .Include("Section")
                .AsQueryable();

            if (filter.BrandId.HasValue)
                query = query.Where(p => p.BrandId.HasValue &&
                                         p.BrandId.Value.Equals(filter.BrandId.Value));

            if (filter.SectionId.HasValue)
                query = query.Where(p => p.SectionId.Equals(filter.SectionId));

            if (filter.Ids != null && filter.Ids.Count > 0)
                query = query.Where(p => filter.Ids.Contains(p.Id));

            var model = new PagedProductDto
            {
                TotalCount = query.Count()
            };

            if (filter.PageSize.HasValue)
            {
                model.Products = _mapper.Map<IEnumerable<ProductDto>>(query
                    .OrderBy(c => c.Order)
                    .Skip((filter.Page - 1) * filter.PageSize.Value)
                    .Take(filter.PageSize.Value));
            }
            else
            {
                model.Products = _mapper.Map<IEnumerable<ProductDto>>(query
                    .OrderBy(c => c.Order));
            }

            var products = _mapper.Map<IEnumerable<ProductDto>>(query);

            return model;
        }

        public IEnumerable<SectionDto> GetSections()
        {
            var sections = _mapper.Map<IEnumerable<SectionDto>>(_context.Sections.ToList());

            return sections;
        }

        public int GetBrandProductCount(int id)
            => _context.Products.Count(p => p.BrandId.HasValue && p.BrandId.Value == id);

        public ProductDto GetProductById(int id)
        {
            var product = _mapper.Map<ProductDto>(_context.Products
                .Include("Brand")
                .Include("Section")
                .FirstOrDefault(p => p.Id == id));

            return product;
        }

        public BrandDto GetBrandById(int id)
        {
            var brand = _context.Brands.FirstOrDefault(b => b.Id == id);

            return _mapper.Map<BrandDto>(brand);
        }

        public SectionDto GetSectionById(int id)
        {
            var section = _context.Sections.FirstOrDefault(s => s.Id == id);

            return _mapper.Map<SectionDto>(section);
        }
    }
}
