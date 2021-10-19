﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public Quiz Quiz { get; set; }
        public List<Answer> Answers { get; set; }
    }
}