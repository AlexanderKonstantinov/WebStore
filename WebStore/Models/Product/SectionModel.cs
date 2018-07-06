using System.Collections.Generic;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Models.Product
{
    public class SectionModel : IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// Child sections
        /// </summary>
        public List<SectionModel> ChildSections { get; set; }

        /// <summary>
        /// Parent section
        /// </summary>
        public SectionModel ParentSection { get; set; }

        public SectionModel()
        {
            ChildSections = new List<SectionModel>();
        }
    }
}
