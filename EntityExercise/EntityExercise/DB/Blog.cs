using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityExercise.DB
{
    internal class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        
        public List<Post> Posts { get; set; } = new();
    }
}
