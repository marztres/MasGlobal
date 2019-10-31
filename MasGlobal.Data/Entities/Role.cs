using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Data.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Role(int id, string name, string description) {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
