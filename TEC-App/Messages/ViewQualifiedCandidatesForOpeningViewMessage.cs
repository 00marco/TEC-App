﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Messages
{
    public class ViewQualifiedCandidatesForOpeningViewMessage
    {
        public int RequiredQualificationId { get; set; }
        public Opening Opening { get; set; }
    }
}
