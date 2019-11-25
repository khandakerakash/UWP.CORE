using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OBS.API.Model;

namespace OBS.API.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long,
        IdentityUserClaim<long>, ApplicationUserRole, IdentityUserLogin<long>,
        IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<BookCategory> BookCategories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Book and Category Many to Many Relationship
            modelBuilder.Entity<BookCategory>()       // THIS IS FIRST
                .HasOne(u => u.Book).WithMany(u => u.BookCategories).IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookCategory>()       // THIS IS FIRST
                .HasOne(u => u.Category).WithMany(u => u.BookCategories).IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);

            modelBuilder.Entity<Book>()
                .HasOne(e => e.Author)
                .WithMany(e => e.Books)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

        }
        
    }
}