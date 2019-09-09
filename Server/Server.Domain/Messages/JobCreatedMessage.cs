﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Domain.Messages
{
    public class JobCreatedMessage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Precision { get; set; }
    }
}
