#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;

namespace DG.DentneD.Forms.Objects
{
    public class VPatientsAttachments
    {
        public int patientsattachments_id { get; set; }
        public string attachmetnstype { get; set; }
        public DateTime date { get; set; }
        public string attachment { get; set; }
    }
}
