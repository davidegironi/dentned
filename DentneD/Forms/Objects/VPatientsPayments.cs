#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
namespace DG.DentneD.Forms.Objects
{
    public class VPatientsPayments
    {
        public int payments_id { get; set; }
        public DateTime date { get; set; }
        public double amount { get; set; }
        public string note { get; set; }
    }
}
