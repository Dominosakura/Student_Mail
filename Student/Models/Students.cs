using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student.Models
{
  public class Students
{
    [DisplayName("Mã học viên")]
    public string MaHocVien { get; set; }

    [DisplayName("Họ và tên")]
    public string HovaTen { get; set; }

    [DisplayName("Giới tính")]
    public string GioiTinh { get; set; }

    [DisplayName("Ngày sinh")]
    public DateTime NgaySinh {  get; set; }

    [DisplayName("Học phí")]
    public double HocPhi { get; set; }

    [DisplayName("Hình")]
    public string ImagePath { get; set; }  // Lưu đường dẫn ảnh

    [DisplayName("Ghi chú"), DataType(DataType.MultilineText)]
    public string Notes { get; set; }
}

}