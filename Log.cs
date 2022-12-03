using System.ComponentModel.DataAnnotations;
using System;

namespace DevopsCase4
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public string? Action { get; set; }
        public string? Timestamp { get; set; }
    }   
}