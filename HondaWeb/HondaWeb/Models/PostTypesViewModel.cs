using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HondaWeb.Models
{
    public class PostTypesViewModel
    {
        [Display(Name = "Mã loại bài viết")]
        public int PostTypeId { get; set; }

        [Display(Name = "Tên loại bài viết")]
        public string PostTypeName { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Thứ tự sắp xếp")]
        public short? SortOrder { get; set; }
    }
}
