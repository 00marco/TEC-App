﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Models.ViewDTO
{
    public class CandidateWithCheckBoxDTO
    {
        public Candidate Candidate { get; set; }
        public bool IsSelected { get; set; }
    }
}
