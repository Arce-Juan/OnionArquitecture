using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class PagedClientsSpecifications : Specification<Client>
    {
        public PagedClientsSpecifications(int pageNumber, int pageSize, string filterByLastName, string filterByName)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(filterByLastName))
            {
                Query.Search(x => x.LastName, "%" + filterByLastName + "%");
            }

            if (!string.IsNullOrEmpty(filterByName))
            {
                Query.Search(x => x.Name, "%" + filterByName + "%");
            }
        }
    }
}
