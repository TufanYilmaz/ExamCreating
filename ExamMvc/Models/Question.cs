using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ExamMvc.Models
{
    [Table("Questions")]
    public class Question : BaseModel
    {
        //[Key]
        //public int Id { get; set; }
        [Display(Name ="Soru")]
        public string QuestionContent { get; set; }
        public Quiz Quiz { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        [NotMapped]
        public char RightAnswerLetter { get; set; }
        [NotMapped]
        public char SelectedAnswerLetter { get; set; }
        public Question()
        {

        }
        readonly static string AnswerLetters = "ABCDEFGHIJKLMNO";
        public IEnumerable<char> GetAnswerLetters(int count)
        {
            return AnswerLetters.Take(count);
        }
        public Question(int answerCount)
        {
            for (int i = 0; i < answerCount; i++)
            {
                var temp = new Answer();
                temp.AnswerLetter = AnswerLetters[i];
                Answers.Add(temp);
            }
        }

    }
}
