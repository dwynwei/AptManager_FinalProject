﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.CommandResponse
{
    /*
     * CommandResponse Model for Returning and controlling Requests/Responses
     */
    public class CommandResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
