using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.Models.Product;

namespace WebStore.ViewComponents
{
    public class SectionsViewComponent : ViewComponent
    {
        private IProductData _productData;

        public SectionsViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public IViewComponentResult Invoke()
        {
            var sections = GetSections();
            return View(sections);
        }

        private List<SectionModel> GetSections()
        {
            var categories = _productData.GetSections();

            var parentCategories = categories.Where(p => !p.ParentId.HasValue).ToList();

            var parentSections = new List<SectionModel>();
            foreach (var parentCategory in parentCategories)
            {
                parentSections.Add(new SectionModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentSection = null
                });
            }
            foreach (var sectionViewModel in parentSections)
            {
                var childCategories = categories.Where(c => c.ParentId.Equals(sectionViewModel.Id));
                foreach (var childCategory in childCategories)
                {
                    sectionViewModel.ChildSections.Add(new SectionModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentSection = sectionViewModel
                    });
                }
                sectionViewModel.ChildSections = sectionViewModel.ChildSections.OrderBy(c =>
                c.Order).ToList();
            }
            parentSections = parentSections.OrderBy(c => c.Order).ToList();
            return parentSections;
        }

    }
}
