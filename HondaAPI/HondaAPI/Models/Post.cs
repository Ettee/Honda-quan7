using System;
using System.Collections.Generic;

#nullable disable

namespace HondaAPI.Models
{
    public partial class Post
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Content { get; set; }
        public short? Status { get; set; }
        public int? PostTypeId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsHotNews { get; set; }

        public virtual PostType PostType { get; set; }
    }
}
