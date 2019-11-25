using System;
using System.Collections.Generic;
using OBS.API.Model.Interfaces;

namespace OBS.API.Model
{
    public class Category : ITrackable, ISoftDeletable
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public long ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public ICollection<BookCategory> BookCategories { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}