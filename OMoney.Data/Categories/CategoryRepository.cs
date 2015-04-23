﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OMoney.Data.Context;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DomainDbContext _domainDbContext;

        public CategoryRepository(DomainDbContext domainDbContext)
        {
            _domainDbContext = domainDbContext;
        }

        public void Create(Category category)
        {
            _domainDbContext.Categories.Add(category);
            _domainDbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            _domainDbContext.SaveChanges();
        }

        public void Delete(Category category)
        {
            _domainDbContext.Categories.Remove(category);
        }

        public List<Category> GetCategories(Plan plan)
        {
            var categories = _domainDbContext.Categories.Where(x => x.PlanId == plan.Id);
            if (categories.Any())
            {
                return categories.ToList();
            }
            return null;
        }
    }
}
