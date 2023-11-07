using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_TEST.Models
{
    public class Employees
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="姓名不可空白")]
        [DisplayName("姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage ="電話必須填寫")]
        [DisplayName("電話")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("地址")]
        public string Adderess { get; set; }

        [Required]
        [DisplayName("性別")]
        public string Gender { get; set; }

        [DisplayName("註銷")]
        public bool Cancel { get; set; }
    }
}