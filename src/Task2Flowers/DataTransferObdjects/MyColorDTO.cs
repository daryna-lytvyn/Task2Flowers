﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.DataTransferObdjects
{
    public class MyColorDTO
    {
        [Required(ErrorMessage = "Title not defined")]
        public String Title { get; set; }

        public Byte R { get; set; }
        public Byte G { get; set; }
        public Byte B { get; set; }
    }
}
