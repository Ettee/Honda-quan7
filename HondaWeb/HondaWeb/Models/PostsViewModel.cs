using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HondaWeb.Models
{
    public class PostsViewModel
    {
        public long PostId { get; set; }
        [Display(Name = "Tiêu đề"), Required]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Ngày đăng"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Trạng thái")]
        public short? Status { get; set; }
        public int? PostTypeId { get; set; }
        [Display(Name = "Ngày sửa"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedDate { get; set; }
        [Display(Name = "Tin nổi bật")]
        public bool IsHotNews { get; set; }
        [Display(Name = "Loại bài viết")]
        public string PostTypeName { get; set; }
    }
}
