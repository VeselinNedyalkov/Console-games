﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models.Position.Contract
{
    public interface IPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
