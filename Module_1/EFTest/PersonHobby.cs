using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTest
{
    public class PersonHobby
    {
        public int PersonId { get; set; }
        public int HobbyId { get; set; }

        public Person Person { get; set; }
        public Hobby Hobby { get; set; }
    }
}