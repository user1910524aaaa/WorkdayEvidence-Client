﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data
{
    public class ToastInstance
    {
        public Guid Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public ToastSettings ToastSettings { get; set; }
    }
}
