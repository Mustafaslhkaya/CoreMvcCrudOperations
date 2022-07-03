using System.ComponentModel.DataAnnotations;

namespace CoreMvcCrudOperations.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string PersonelName { get; set; }
        public string PersonelSurname { get; set; }
        public string City { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
