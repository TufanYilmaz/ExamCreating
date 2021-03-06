using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    [Table("Quizs")]
    public class Quiz :BaseModel
    {
        //[Key]
        //public int Id { get; set; }
        [Display(Name ="Başlık")]
        public string Caption { get; set; }
        public string RefUrl { get; set; }
        public string RefTitle { get; set; }
        [Display(Name = "Tarih")]
        public string CreatedDate { get; set; }
        [NotMapped]
        public QuizReferance QuizReferance{ get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
