using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients.Models
{
    public class Client
    {
        public Client()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; private set; }
        public string Name { get; set; }
    }
}
