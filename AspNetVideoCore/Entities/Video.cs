﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetVideoCore.ViewModels;

namespace AspNetVideoCore.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string Title { get; set; }

       // public int Genreid { get; set; }

        public Genres Genre { get; set; }
    }
}
