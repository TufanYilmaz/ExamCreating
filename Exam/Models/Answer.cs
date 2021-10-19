﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string AnswerContent { get; set; }
        public char AnswerLetter { get; set; }
        public bool IsRight { get; set; }
        public Question Question { get; set; }
    }
}
