using System.Collections.Generic;
using WebStore.Domain.Entities;

namespace WebStore.Repositories.Interfaces
{
    public interface IProductDataRepository
    {
        IEnumerable<Section> Sections { get; }
        IEnumerable<Brand> Brands { get; }
    }
}
