using CQRS.AppCore.Entities.Publication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.AppCore.Entities.User
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }

        public ApplicationUser(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            Articles = new List<Article>();
        }
    }
}
