using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDataBaseFirst
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
