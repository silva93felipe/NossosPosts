using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options): base(options){}
        public DbSet<Post> Post { get; set;}
        public DbSet<User> User { get; set;}
        public DbSet<Curtida> Curtida { get; set;}
        public DbSet<Comentario> Comentario { get; set;}        
    }
}