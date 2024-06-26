﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Models
{
    public class Book
    {
        public Book()
        {

        }

        public Book(string author, string language, string title)
        {
            Author = author;
            Language = language;
            Title = title;
        }

        public int BookId { get; set; }

        public string Author { get; set; } = "";

        public string Language { get; set; } = "";

        public string Title { get; set; } = "";

        public bool? LoanedOut { get; set; } = false;


    }
}
