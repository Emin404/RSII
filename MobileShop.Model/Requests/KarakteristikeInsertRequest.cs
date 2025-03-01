﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobileShop.Model.Requests
{
    public class KarakteristikeInsertRequest
    {
        [Required]
        public bool Novo { get; set; }
        [Required]
        public string OperativniSistem { get; set; }
        [Required]
        public decimal Kamera { get; set; }
        [Required]
        public decimal Ram { get; set; }
        public decimal Memorija { get; set; }
        public decimal Procesor { get; set; }
    }
}
