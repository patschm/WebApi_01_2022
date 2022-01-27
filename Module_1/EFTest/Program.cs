

using EFTest;
using Microsoft.EntityFrameworkCore;

string conStr = @"Server=.\sqlexpress;Database=BlaDb;Trusted_Connection=True;MultipleActiveResultSets=true;";
DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
bld.UseSqlServer(conStr);
//bld.LogTo(msg=>System.Console.WriteLine(msg));
PeopleDbContext ctx = new PeopleDbContext(bld.Options);

//ctx.Database.EnsureCreated();

// var px = ctx.People.FirstOrDefault(p=>p.Id == 3);
// System.Console.WriteLine(ctx.Entry(px).OriginalValues.GetValue<string>(nameof(px.LastName)));
// System.Console.WriteLine(ctx.Entry(px).CurrentValues.GetValue<string>(nameof(px.LastName)));
// px.LastName = "Harmsen";
// ctx.Entry(px).CurrentValues.SetValues(px);
// System.Console.WriteLine(ctx.Entry(px).OriginalValues.GetValue<string>(nameof(px.LastName)));
// System.Console.WriteLine(ctx.Entry(px).CurrentValues.GetValue<string>(nameof(px.LastName)));

//Person p = new Person{LastName = "Janssen", FirstName = "Peter", Age = 42};
//Hobby h = new Hobby {Name = "Kanteklossen"};
//Hobby h = ctx.Hobby.FirstOrDefault(h=>h.Id == 2);
//h.Name = "Breien";

// PersonHobby ph = new PersonHobby();
// ph.Person = p;
// ph.Hobby = h;

// p.Hobbies.Add(ph);

// ctx.People.Add(p);

try
{
    ctx.SaveChanges();
}
catch(DbUpdateConcurrencyException oe)
{
    //oe.Entries[0].
}


var query = ctx.People
    .Include(pr=>pr.Hobbies)
        .ThenInclude(phr=>phr.Hobby)
    .AsQueryable();//.OrderBy(p=>p.Id);
query = query.Where(p => p.Id > 1);
query = query.Take(10);
foreach(Person pp in query)
{
    System.Console.WriteLine(pp.LastName);
    //ctx.Entry(pp).Collection(pt=>pt.Hobbies).Load();
    foreach(var ph in pp.Hobbies)
    {
        // ctx.Entry(ph).Reference(ph1=>ph1.Hobby).Load();
        System.Console.WriteLine($"\t{ph.Hobby?.Name}");
    }
}

System.Console.WriteLine("Success");


