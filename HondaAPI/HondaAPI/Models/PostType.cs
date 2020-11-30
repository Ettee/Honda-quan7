using System;
using System.Collections.Generic;

#nullable disable

namespace HondaAPI.Models
{
    public partial class PostType
    {
        public PostType()
        {
            Posts = new HashSet<Post>();
        }

        public int PostTypeId { get; set; }
        public string PostTypeName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public short? SortOrder { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
