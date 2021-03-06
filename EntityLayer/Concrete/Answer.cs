using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    [Table("Answers")]
    public class Answer : BaseModel
    {
        //[Key]
        //public int Id { get; set; }
        [Display(Name="Soru")]
        public string AnswerContent { get; set; }
        public char AnswerLetter { get; set; }
        public bool IsRight { get; set; }
        public Question Question { get; set; }
    }
}
