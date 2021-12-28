using System;
using System.ComponentModel.DataAnnotations;

namespace BookManagementApi.Model
{
    public class BookItems
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }

    }
}