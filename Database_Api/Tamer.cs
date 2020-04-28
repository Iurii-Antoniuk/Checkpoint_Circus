using System;
using System.Collections.Generic;
using System.Text;

namespace Database_Api
{
    public class Tamer
    {
        public int TamerId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Quote { get; set; }
        public SpiritAnimal SpiritAnimal { get; set; }
        public KungfuMastery KungfuMastery { get; set; }
    }
}
