using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options){}


        public DbSet<TodoItem> Todos {get; set;}

        protected override void OnModelCreating(ModelBuilder mb)
        {
           mb.Entity<TodoItem>().ToTable("Todo");
           mb.Entity<TodoItem>().Property(x => x.Id);
           mb.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
           mb.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
           mb.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");
           mb.Entity<TodoItem>().Property(x => x.Date);
           mb.Entity<TodoItem>().HasIndex(x => x.User);
        }
    }
}