#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Model;

namespace DG.DentneD
{
    /// <summary>
    /// DentneD print model interface
    /// each class implementing this interface must be in namespace "DG.DentneD" with name DentneDPrintModel
    /// i.e. public class DG.DentneD.DentneDPrintModel : IDentneDPrintModel
    /// </summary>
    public interface IDentneDPrintModel
    {
        /// <summary>
        /// Build a PDF for an estimate
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="estimates_id"></param>
        /// <param name="filename"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        bool BuildEstimatePDF(DentneDModel dentnedModel, int estimates_id, string filename, string language);

        /// <summary>
        /// Build a PDF for an invoice
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="invoices_id"></param>
        /// <param name="filename"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        bool BuildInvoicePDF(DentneDModel dentnedModel, int invoices_id, string filename, string language);
    }
}
