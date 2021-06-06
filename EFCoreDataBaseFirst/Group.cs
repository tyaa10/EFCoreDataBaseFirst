using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDataBaseFirst
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
