using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTest
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PersonHobby> People { get; set; } = new HashSet<PersonHobby>();
    }
}