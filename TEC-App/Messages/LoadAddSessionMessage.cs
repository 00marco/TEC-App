﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Messages
{
    public class LoadAddSessionMessage
    {
        public Course Course { get; set; }
    }
}
