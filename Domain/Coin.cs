﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Coin
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
    }
}
