using System;

namespace api.Models
{   
    public class Posts
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public DateTime Timestamp { get; set; }
    }
}