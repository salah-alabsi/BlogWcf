using System;
using System.ComponentModel.DataAnnotations;

namespace BlogLib
{
    public class BlogPost
    {
        [Key] 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedAt { get; set; }
    }
}
