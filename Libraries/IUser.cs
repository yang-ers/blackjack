﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public interface IUser
    {
        double TotalWorth { get; set; }
        string Name { get; set; }

    }
}
