﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Libraries
{
    public class Player : User
    {

        private double InitialWorth = 0;

        public Player()
        {
            this.Name = Name;
            this.TotalWorth = InitialWorth;
        }

    }
}
