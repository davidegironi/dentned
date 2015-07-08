#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

namespace DG.DentneD.Forms.Objects
{
    public class VEstimatesLines
    {
        public int estimateslines_id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public double unitprice { get; set; }
        public double taxrate { get; set; }
        public double totalprice { get; set; }
    }
}
