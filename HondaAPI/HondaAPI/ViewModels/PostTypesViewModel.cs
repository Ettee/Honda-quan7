using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HondaAPI.ViewModels
{
    public class PostTypesViewModel
    {
        public int PostTypeId { get; set; }
        public string PostTypeName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public short? SortOrder { get; set; }
    }
}
