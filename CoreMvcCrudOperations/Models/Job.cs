using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreMvcCrudOperations.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string JobName { get; set; }
        public IList<Personel> Personels { get; set; }

    }
}
