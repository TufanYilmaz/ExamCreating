using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamMvc.Models
{
    [Table("Questions")]
    public class Question : BaseModel
    {
        //[Key]
        //public int Id { get; set; }
        public string QuestionContent { get; set; }
        public Quiz Quiz { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
