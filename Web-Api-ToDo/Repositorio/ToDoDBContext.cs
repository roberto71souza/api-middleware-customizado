using Microsoft.EntityFrameworkCore;
using Web_Api_ToDo.Models;

namespace Web_Api_ToDo.Repositorio
{
    public class ToDoDBContext : DbContext
    {
        public DbSet<ToDo> ToDo { get; set; }

        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.Entity<ToDo>().ToTable("tbl_todo");
        }
    }
}
