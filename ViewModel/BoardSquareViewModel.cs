using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Model.Reversi;
using Cells;
using DataStructures;

namespace ViewModel
{
    public class BoardSquareViewModel
    {
        public Player Owner { get; set; }

        public BoardSquareViewModel(Player owner)
        {
            this.Owner = owner;
        }
    }
}
