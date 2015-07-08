#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DentneD.Forms.Objects
{
    public class VPatientsEstimates
    {
        public int estimates_id { get; set; }
        public string number { get; set; }
        public DateTime date { get; set; }
        public string doctor { get; set; }
        public double total { get; set; }
        public bool isinvoiced { get; set; }
    }
}
