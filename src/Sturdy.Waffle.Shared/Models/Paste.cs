using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sturdy.Waffle.Shared.Models
{
    [Table("Pastes")]
    public class Paste
    {
        [Key] public string Id { get; set; }

        [Required] public DateTime Date { get; set; }

        [Required, StringLength(maximumLength: 9)]
        public string Key { get; set; }

        [Required] public int Size { get; set; }

        [Required] public string Syntax { get; set; }

        public DateTime Expire { get; set; }

        public string Title { get; set; }

        public string UserName { get; set; }
    }
}
