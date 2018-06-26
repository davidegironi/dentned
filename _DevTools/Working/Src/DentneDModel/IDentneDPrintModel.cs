#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Model;
using DG.DentneD.Model.Entity;

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
        /// Check if PDF for an estimate builder is enabled
        /// </summary>
        /// <returns></returns>
        bool IsBuildEstimatePDFEnabled();

        /// <summary>
        /// Get the PDF for an estimate builder template name
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        string BuildEstimatePDFName(string language);

        /// <summary>
        /// Build a PDF for an invoice
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="invoices_id"></param>
        /// <param name="filename"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        bool BuildInvoicePDF(DentneDModel dentnedModel, int invoices_id, string filename, string language);

        /// <summary>
        /// Check if PDF for an invoice builder is enabled
        /// </summary>
        /// <returns></returns>
        bool IsBuildInvoicePDFEnabled();

        /// <summary>
        /// Get the PDF for an invoice builder template name
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        string BuildInvoicePDFName(string language);

        /// <summary>
        /// Build a PDF for patients treatments
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="patients_id"></param>
        /// <param name="patientstreatmentsl"></param>
        /// <param name="filename"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        bool BuildPatientsTreatmentsPDF(DentneDModel dentnedModel, int patients_id, patientstreatments[] patientstreatmentsl, string filename, string language);

        /// <summary>
        /// Check if PDF for patients treatments builder is enabled
        /// </summary>
        /// <returns></returns>
        bool IsBuildPatientsTreatmentsPDFEnabled();

        /// <summary>
        /// Get the PDF for patients treatments builder template name
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        string BuildPatientsTreatmentsPDFName(string language);
    }
}
