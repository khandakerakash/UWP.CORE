using System;
using System.Collections.Generic;
using OBS.API.Model.Interfaces;

namespace OBS.API.Model
{
    public class Author: ITrackable, ISoftDeletable
    {
        public long AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public long ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        public ICollection<Book> Books { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}