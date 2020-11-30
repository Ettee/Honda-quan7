using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HondaAPI.ViewModels
{
    public class PostsViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Content { get; set; }
        public short? Status { get; set; }
        public int? PostTypeId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsHotNews { get; set; }
        public string PostTypeName { get; set; }
    }
}
