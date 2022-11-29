using System.ComponentModel.DataAnnotations;

namespace DevopsCase4
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? Province { get; set; } 
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNr { get; set; }
        public int Permission { get; set; }
        public int CompanyId { get; set; }

    }
}