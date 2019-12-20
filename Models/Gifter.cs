using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Models
{
    public class Gifter : BaseEntity
    {
        public User User { get; set; }
        public User GiftsTo { get; set; }
    }
}
