

using EFTest;
using Microsoft.EntityFrameworkCore;

string conStr = @"Server=.\sqlexpress;Database=BlaDb;Trusted_Connection=True;";
DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
bld.UseSqlServer(conStr);
PeopleDbContext ctx = new PeopleDbContext(bld.Options);

ctx.Database.EnsureCreated();

System.Console.WriteLine("Success");


