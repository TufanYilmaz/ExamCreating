using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamMvc.Models.ViewModels
{
    public class QuestionEvaluate
    {
        public int QuestionNumber { get; set; }
        public int QuestionId { get; set; }
        public char SelectedAnswer { get; set; }
        public bool Right { get; set; }
    }
}
