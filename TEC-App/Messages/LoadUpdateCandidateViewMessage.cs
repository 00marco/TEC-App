﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using TEC_App.Models.Db;

namespace TEC_App.Messages
{
    public class LoadUpdateCandidateViewMessage
    {
        public Candidate Candidate { get; set; }
    }
}
