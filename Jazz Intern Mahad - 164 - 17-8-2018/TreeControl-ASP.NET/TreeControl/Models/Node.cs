using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeControl.Models
{
    public class Node
    {
        public string title { get; set; }
        public int key { get; set; }
        public Boolean folder { get; set; }
        public List<Node> children { get; set; }
    }

}