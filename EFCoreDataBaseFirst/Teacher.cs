using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDataBaseFirst
{
    public partial class Teacher
    {
        public Teacher()
        {
            Groups = new HashSet<Group>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}