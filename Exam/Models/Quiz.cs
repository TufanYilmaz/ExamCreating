﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    [Table("Quizs")]
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public string Caption { get; set; }
        public string RefUrl { get; set; }
        public string RefTitle { get; set; }
        public List<Question> Questions { get; set; }
    }
}