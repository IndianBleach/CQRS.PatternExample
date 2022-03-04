using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.AppCore.Entities.Publication
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public Article(string title, string description)
        {
            Title = title;
            Description = description;
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }
}
