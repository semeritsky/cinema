using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cinema.Models
{
    public class Row
    {
        public int RowNumber { get; set; }
        public List<Col> Cols { get; set; } = new List<Col>();
    }
}