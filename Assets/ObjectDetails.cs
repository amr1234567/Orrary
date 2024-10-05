using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class ObjectDetails
    {
        public Sprite RealImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double OrbitPeriod { get; set; }
        public double PeriodOfDay { get; set; }
        public double radius { get; set; }
    }
}
