﻿
using Microsoft.EntityFrameworkCore;
using PageApp.Infrastracture.Models;

namespace PageApp.Infrastracture;

public partial class PageAppDbContext : DbContext
{

    public PageAppDbContext(DbContextOptions options)
        : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }
    public DbSet<StudentStatus> StudentStatuses { get; set; }
}