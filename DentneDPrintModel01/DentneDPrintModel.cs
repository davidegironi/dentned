#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Model;
using DG.DentneD.Model.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace DG.DentneD
{

    public class DentneDPrintModel : IDentneDPrintModel
    {
        /// <summary>
        /// DentneDPrintModel language dictionary
        /// </summary>
        private class DentneDPrintModelLanguage
        {
            public string estimatesTemplateName = "Treatments View";
            public string estimatesTitle = "Treatments";
            public string estimatesNumber = "Number";
            public string estimatesDate = "Date";
            public string estimatesInvoiceReference = "Invoice reference";
            public string estimatesPatienttext = "Bill to";
            public string estimatesItemsCodeTH = "Code";
            public string estimatesItemsDescriptionTH = "Description";
            public string estimatesItemsQuantityTH = "Qty";
            public string estimatesItemsPriceTH = "Price";
            public string estimatesItemsTaxrateTH = "Tax";
            public string estimatesPaymentext = "Payment";
            public string estimatesTotals = "Totals";
            public string estimatesTotalsTotalnotax = "Net total";
            public string estimatesTotalsTotaltax = "Gross total";
            public string estimatesTotalsTotaldocument = "Document total";
            public string estimatesTotalsTotaldeductiontax = "Deduction tax total";
            public string estimatesTotalsTotalamountdue = "Total";
            public string invoicesTemplateName = "Treatments View";
            public string invoicesTitle = "Treatments";
            public string invoicesNumber = "Number";
            public string invoicesDate = "Date";
            public string invoicesPatienttext = "Bill to";
            public string invoicesItemsCodeTH = "Code";
            public string invoicesItemsDescriptionTH = "Description";
            public string invoicesItemsQuantityTH = "Qty";
            public string invoicesItemsPriceTH = "Price";
            public string invoicesItemsTaxrateTH = "Tax";
            public string invoicesPaymentext = "Payment";
            public string invoicesTotals = "Totals";
            public string invoicesTotalsTotalnotax = "Net total";
            public string invoicesTotalsTotaltax = "Gross total";
            public string invoicesTotalsTotaldocument = "Document total";
            public string invoicesTotalsTotaldeductiontax = "Deduction tax total";
            public string invoicesTotalsTotalamountdue = "Total";
            public string buildfileerrorMessage = "Errors happened building the file.";
        }

        /// <summary>
        /// Settings model
        /// </summary>
        private class DentneDPrintModelSettings
        {
            /// <summary>
            /// Check if estimates is enabled
            /// </summary>
            public bool estimatesEnabled = true;

            /// <summary>
            /// Print code on estimates items lines
            /// </summary>
            public bool estimatesPrintCode = true;

            /// <summary>
            /// Print number on estimates items lines
            /// </summary>
            public bool estimatesPrintNumber = true;

            /// <summary>
            /// Print date on estimates items lines
            /// </summary>
            public bool estimatesPrintDate = true;

            /// <summary>
            /// Print invoice reference on estimates items lines
            /// </summary>
            public bool estimatesPrintInvoiceReference = true;

            /// <summary>
            /// Check if invoices is enabled
            /// </summary>
            public bool invoicesEnabled = true;

            /// <summary>
            /// Print code on invoices items lines
            /// </summary>
            public bool invoicesPrintCode = true;

            /// <summary>
            /// Print number on invoices items lines
            /// </summary>
            public bool invoicesPrintNumber = true;

            /// <summary>
            /// Print date on invoices items lines
            /// </summary>
            public bool invoicesPrintDate = true;
        }

        /// <summary>
        /// DentneDPrintModel language
        /// </summary>
        private DentneDPrintModelLanguage _language = new DentneDPrintModelLanguage();

        /// <summary>
        /// Default language folder
        /// </summary>
        private const string languageFolder = "lang";

        /// <summary>
        /// Default language prefix
        /// </summary>
        private const string languageFilenamePrefix = "DentneDPrintModel01-";

        /// <summary>
        /// Default settings file
        /// </summary>
        private const string settingsFilename = "DentneDPrintModel01.json";

        /// <summary>
        /// Settings
        /// </summary>
        private DentneDPrintModelSettings _settings = new DentneDPrintModelSettings();

        public DentneDPrintModel()
        {
            //load settings
            try
            {
                string jsontext = File.ReadAllText(settingsFilename);
                _settings = new JavaScriptSerializer().Deserialize<DentneDPrintModelSettings>(jsontext);
            }
            catch { }
        }

        /// <summary>
        /// Load language from a file
        /// </summary>
        /// <param name="filename"></param>
        private void LoadLanguageFromFile(string filename)
        {
            if (!String.IsNullOrEmpty(filename))
            {
                //deserialize the file
                try
                {
                    string jsontext = File.ReadAllText(filename);
                    _language = new JavaScriptSerializer().Deserialize<DentneDPrintModelLanguage>(jsontext);
                }
                catch { }
            }
        }

        /// <summary>
        /// Build a file for an estimate
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="estimates_id"></param>
        /// <param name="language"></param>
        /// <param name="filename"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public bool BuildEstimate(DentneDModel dentnedModel, int estimates_id, string language, string filename, ref string[] errors)
        {
            bool ret = false;

            //load language
            LoadLanguageFromFile(languageFolder + "\\" + languageFilenamePrefix + language + ".json");

            try
            {
                //get estimates
                estimates estimate = dentnedModel.Estimates.Find(estimates_id);
                if (estimate == null)
                    return false;
                List<estimateslines> estimatelines = dentnedModel.EstimatesLines.List(r => r.estimates_id == estimate.estimates_id).ToList();

                //get invoices
                invoices invoice = null;
                if (estimate.invoices_id != null)
                    invoice = dentnedModel.Invoices.Find((int)estimate.invoices_id);

                //fill infos
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                writer.ViewerPreferences = PdfWriter.PageModeUseOutlines;
                PrintPageN printPageN = new PrintPageN();
                writer.PageEvent = printPageN;
                document.Open();

                iTextSharp.text.Font b10Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font b12Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font n10Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font n8Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL);

                PdfPTable titleTable = null;
                PdfPTable preheaderTable = null;
                PdfPTable preheaderrefTable = null;
                PdfPTable headerTable = null;
                PdfPTable itemsTable = null;
                PdfPTable paymentTable = null;
                PdfPTable footerTable = null;

                PdfPTable bTable = null;
                PdfPCell aCell = null;
                Phrase phrase = null;

                //titleTable
                titleTable = new PdfPTable(new float[] { 1 });
                titleTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                titleTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                titleTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.estimatesTitle, b12Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aCell.PaddingBottom = 10;
                aCell.HorizontalAlignment = Element.ALIGN_CENTER;
                titleTable.AddCell(aCell);

                //preheaderTable
                preheaderTable = new PdfPTable(new float[] { 1, 1 });
                preheaderTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                preheaderTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                preheaderTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                preheaderTable.SetTotalWidth(new float[] { preheaderTable.TotalWidth / 2, preheaderTable.TotalWidth / 2 });
                phrase = new Phrase();
                if (_settings.estimatesPrintNumber)
                {
                    phrase.Add(new Chunk(_language.estimatesNumber + ": ", b10Font));
                    phrase.Add(new Chunk(estimate.estimates_number, n10Font));
                    phrase.Add(new Chunk("/", n10Font));
                    phrase.Add(new Chunk(estimate.estimates_date.Year.ToString(), n10Font));
                }
                preheaderTable.AddCell(phrase);
                phrase = new Phrase();
                if (_settings.estimatesPrintDate)
                {
                    phrase.Add(new Chunk(_language.estimatesDate + ": ", b10Font));
                    phrase.Add(new Chunk(estimate.estimates_date.ToShortDateString(), n10Font));
                }
                preheaderTable.AddCell(phrase);

                //preheaderrefTable
                preheaderrefTable = new PdfPTable(new float[] { 1 });
                preheaderrefTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                preheaderrefTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                preheaderrefTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                preheaderrefTable.SetTotalWidth(new float[] { preheaderrefTable.TotalWidth });
                if (_settings.estimatesPrintInvoiceReference && invoice != null)
                {
                    phrase = new Phrase();
                    phrase.Add(new Chunk(_language.estimatesInvoiceReference + ": ", b10Font));
                    phrase.Add(new Chunk(invoice.invoices_number, n10Font));
                    phrase.Add(new Chunk("/", n10Font));
                    phrase.Add(new Chunk(invoice.invoices_date.Year.ToString(), n10Font));
                    preheaderrefTable.AddCell(phrase);
                }

                //headerTable
                headerTable = new PdfPTable(new float[] { 1, 1 });
                headerTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                headerTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                headerTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                headerTable.SetTotalWidth(new float[] { headerTable.TotalWidth / 2, headerTable.TotalWidth / 2 });
                bTable = new PdfPTable(new float[] { 1 });
                bTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                bTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                bTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                phrase = new Phrase();
                phrase.Add(new Chunk(" ", b10Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aCell.PaddingBottom = 5;
                bTable.AddCell(aCell);
                bTable.AddCell(new Paragraph(""));
                phrase = new Phrase();
                phrase.Add(new Chunk(estimate.estimates_doctor, n10Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER + iTextSharp.text.Rectangle.TOP_BORDER + iTextSharp.text.Rectangle.LEFT_BORDER + iTextSharp.text.Rectangle.RIGHT_BORDER;
                aCell.PaddingBottom = 5;
                bTable.AddCell(aCell);
                headerTable.AddCell(bTable);
                bTable = new PdfPTable(new float[] { 1 });
                bTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                bTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                bTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.estimatesPatienttext + ":", b10Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.PaddingBottom = 5;
                bTable.AddCell(aCell);
                bTable.AddCell(new Paragraph(""));
                phrase = new Phrase();
                phrase.Add(new Chunk(estimate.estimates_patient, n10Font));
                bTable.AddCell(phrase);
                headerTable.AddCell(bTable);

                bool hastax = false;
                foreach (estimateslines estimateline in estimatelines)
                {
                    if (estimateline.estimateslines_taxrate != 0)
                    {
                        hastax = true;
                        break;
                    }
                }

                //itemsTable
                if (hastax)
                {
                    if (_settings.estimatesPrintCode)
                        itemsTable = new PdfPTable(new float[] { 1, 1, 1, 1, 1 });
                    else
                        itemsTable = new PdfPTable(new float[] { 1, 1, 1, 1 });
                }
                else
                {
                    if (_settings.estimatesPrintCode)
                        itemsTable = new PdfPTable(new float[] { 1, 1, 1, 1 });
                    else
                        itemsTable = new PdfPTable(new float[] { 1, 1, 1 });
                }
                itemsTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                itemsTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                itemsTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                if (hastax)
                {
                    if (_settings.estimatesPrintCode)
                        itemsTable.SetTotalWidth(new float[] { 70, itemsTable.TotalWidth - 170, 40, 70, 70 });
                    else
                        itemsTable.SetTotalWidth(new float[] { itemsTable.TotalWidth - 100, 40, 70, 70 });
                }
                else
                {
                    if (_settings.estimatesPrintCode)
                        itemsTable.SetTotalWidth(new float[] { 70, itemsTable.TotalWidth - 100, 40, 70 });
                    else
                        itemsTable.SetTotalWidth(new float[] { itemsTable.TotalWidth - 30, 40, 70 });
                }

                if (_settings.estimatesPrintCode)
                {
                    aCell = new PdfPCell(new Paragraph(_language.estimatesItemsCodeTH, b10Font));
                    aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    aCell.PaddingBottom = 5;
                    itemsTable.AddCell(aCell);
                }
                aCell = new PdfPCell(new Paragraph(_language.estimatesItemsDescriptionTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                aCell.PaddingBottom = 5;
                itemsTable.AddCell(aCell);
                aCell = new PdfPCell(new Paragraph(_language.estimatesItemsQuantityTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                aCell.PaddingBottom = 5;
                itemsTable.AddCell(aCell);
                aCell = new PdfPCell(new Paragraph(_language.estimatesItemsPriceTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                aCell.PaddingBottom = 5;
                itemsTable.AddCell(aCell);
                if (hastax)
                {
                    aCell = new PdfPCell(new Paragraph(_language.estimatesItemsTaxrateTH, b10Font));
                    aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    aCell.PaddingBottom = 5;
                    itemsTable.AddCell(aCell);
                }
                foreach (estimateslines estimateline in estimatelines)
                {
                    if (_settings.estimatesPrintCode)
                    {
                        if (!String.IsNullOrEmpty(estimateline.estimateslines_code))
                        {
                            if (estimateline.estimateslines_code.Trim() != "")
                            {
                                aCell = new PdfPCell(new Paragraph(estimateline.estimateslines_code, n10Font));
                                aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                itemsTable.AddCell(aCell);
                            }
                            else
                            {
                                aCell = new PdfPCell(new Paragraph("/", n10Font));
                                aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                itemsTable.AddCell(aCell);
                            }
                        }
                        else
                        {
                            aCell = new PdfPCell(new Paragraph("/", n10Font));
                            aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            itemsTable.AddCell(aCell);
                        }
                    }
                    aCell = new PdfPCell(new Paragraph(estimateline.estimateslines_description, n10Font));
                    aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    itemsTable.AddCell(aCell);
                    aCell = new PdfPCell(new Paragraph(estimateline.estimateslines_quantity.ToString(), n10Font));
                    aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    itemsTable.AddCell(aCell);
                    aCell = new PdfPCell(new Paragraph(Math.Round(estimateline.estimateslines_unitprice, 2).ToString(), n10Font));
                    aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    itemsTable.AddCell(aCell);
                    if (hastax)
                    {
                        if (estimateline.estimateslines_taxrate != 0)
                        {
                            aCell = new PdfPCell(new Paragraph(Math.Round(estimateline.estimateslines_taxrate, 2) + "%", n10Font));
                            aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            itemsTable.AddCell(aCell);
                        }
                        else
                        {
                            aCell = new PdfPCell(new Paragraph("/", n10Font));
                            aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            itemsTable.AddCell(aCell);
                        }
                    }
                }

                decimal totalnotax = 0;
                decimal totaltax = 0;
                decimal totaldeductiontax = 0;
                dentnedModel.Estimates.CalculateTotal(estimate, ref totaltax, ref totaldeductiontax, ref totalnotax);

                //paymentTable
                paymentTable = new PdfPTable(new float[] { 1, 1 });
                paymentTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                paymentTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                paymentTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                paymentTable.SetTotalWidth(new float[] { paymentTable.TotalWidth / 2, paymentTable.TotalWidth / 2 });

                bTable = new PdfPTable(new float[] { 1 });
                bTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                bTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                bTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

                if (!String.IsNullOrEmpty(estimate.estimates_payment))
                {
                    if (estimate.estimates_payment.Trim() != "")
                    {
                        phrase = new Phrase();
                        phrase.Add(new Chunk(_language.estimatesPaymentext + ":", b10Font));
                        aCell = new PdfPCell(phrase);
                        aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                        aCell.PaddingBottom = 5;
                        bTable.AddCell(aCell);
                        bTable.AddCell(new Paragraph(""));
                        phrase = new Phrase();
                        phrase.Add(new Chunk(estimate.estimates_payment, n10Font));
                        bTable.AddCell(phrase);
                    }
                }

                paymentTable.AddCell(bTable);

                bTable = new PdfPTable(new float[] { 1 });
                bTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                bTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                bTable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.estimatesTotals + ":", b10Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.PaddingBottom = 5;
                bTable.AddCell(aCell);
                bTable.AddCell(new Paragraph(""));

                List<decimal> taxvaluel = new List<decimal>();
                foreach (estimateslines estimateline in estimatelines.OrderByDescending(r => r.estimateslines_taxrate))
                {
                    if (!taxvaluel.Contains(estimateline.estimateslines_taxrate))
                        taxvaluel.Add(estimateline.estimateslines_taxrate);
                }

                if (taxvaluel.Count > 0 && !taxvaluel.All(r => r == 0))
                {
                    phrase = new Phrase();

                    phrase.Add(new Chunk(_language.estimatesTotalsTotalnotax + ": ", b10Font));
                    foreach (decimal taxvalue in taxvaluel)
                    {
                        string valuestring = "";
                        decimal valuetotal = 0;
                        foreach (estimateslines estimateline in estimatelines.Where(r => r.estimateslines_taxrate == taxvalue))
                        {
                            valuetotal += estimateline.estimateslines_quantity * estimateline.estimateslines_unitprice;
                        }
                        if (valuetotal != 0)
                        {
                            valuestring += "(" + Math.Round(taxvalue, 2) + "%) " + Math.Round(valuetotal, 2);
                            phrase.Add(new Chunk(valuestring + "\n", n10Font));
                        }
                    }
                    if (taxvaluel.Count > 1)
                        phrase.Add(new Chunk(Math.Round(totalnotax, 2) + "\n", n10Font));

                    phrase.Add(new Chunk(_language.estimatesTotalsTotaltax + ": ", b10Font));
                    foreach (decimal taxvalue in taxvaluel)
                    {
                        string taxvaluestring = "";
                        decimal taxvaluetotal = 0;
                        foreach (estimateslines estimateline in estimatelines.Where(r => r.estimateslines_taxrate == taxvalue))
                        {
                            taxvaluetotal += estimateline.estimateslines_quantity * (estimateline.estimateslines_unitprice * estimateline.estimateslines_taxrate / 100);
                        }
                        if (taxvaluetotal != 0)
                        {
                            taxvaluestring += "(" + Math.Round(taxvalue, 2) + "%) " + Math.Round(taxvaluetotal, 2);
                            phrase.Add(new Chunk(taxvaluestring + "\n", n10Font));
                        }
                    }
                    if (taxvaluel.Count > 1)
                        phrase.Add(new Chunk(Math.Round(totaltax, 2) + "\n", n10Font));

                    bTable.AddCell(phrase);
                }

                if (totaldeductiontax != 0)
                {
                    phrase = new Phrase();
                    phrase.Add(new Chunk(_language.estimatesTotalsTotaldocument + ": ", b10Font));
                    phrase.Add(new Chunk(Math.Round(totalnotax + totaltax, 2) + "\n", n10Font));
                    phrase.Add(new Chunk(_language.estimatesTotalsTotaldeductiontax + ": ", b10Font));
                    phrase.Add(new Chunk("(" + Math.Round(estimate.estimates_deductiontaxrate, 2) + "%) " + Math.Round(totaldeductiontax, 2) + "\n", n10Font));
                    aCell = new PdfPCell(phrase);
                    aCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    aCell.PaddingTop = 4;
                    aCell.PaddingBottom = 4;
                    bTable.AddCell(aCell);
                }

                phrase = new Phrase();
                phrase.Add(new Chunk(_language.estimatesTotalsTotalamountdue + ": ", b10Font));
                phrase.Add(new Chunk(Math.Round(totalnotax + totaltax - totaldeductiontax, 2) + "\n", b10Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                aCell.PaddingTop = 4;
                aCell.PaddingBottom = 4;
                bTable.AddCell(aCell);
                paymentTable.AddCell(bTable);

                //footerTable
                footerTable = new PdfPTable(new float[] { 1 });
                footerTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                footerTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                footerTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                if (!String.IsNullOrEmpty(estimate.estimates_footer))
                {
                    if (estimate.estimates_footer.Trim() != "")
                    {
                        phrase = new Phrase();
                        phrase.Add(new Chunk(estimate.estimates_footer, n8Font));
                        aCell = new PdfPCell(phrase);
                        aCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                        aCell.PaddingTop = 5;
                        footerTable.AddCell(aCell);
                    }
                }

                //add tables
                document.Add(titleTable);
                document.Add(preheaderrefTable);
                document.Add(preheaderTable);
                document.Add(headerTable);
                document.Add(new Paragraph(" "));
                document.Add(itemsTable);
                if (writer.GetVerticalPosition(false) < paymentTable.TotalHeight + footerTable.TotalHeight + (float)80)
                {
                    float currentvert = writer.GetVerticalPosition(false);
                    document.Add(new Paragraph(" "));
                    while (writer.GetVerticalPosition(false) < currentvert)
                        document.Add(new Paragraph(" "));
                }
                while (writer.GetVerticalPosition(false) > paymentTable.TotalHeight + footerTable.TotalHeight + (float)80)
                    document.Add(new Paragraph(" "));
                document.Add(paymentTable);
                if (footerTable != null)
                    document.Add(footerTable);

                document.Close();

                ret = true;
            }
            catch
            {
                errors = errors.Concat(new string[] { _language.buildfileerrorMessage }).ToArray();
                return false;
            }

            return ret;
        }

        /// <summary>
        /// Check if estimate builder is enabled
        /// </summary>
        /// <returns></returns>
        public bool IsBuildEstimateEnabled()
        {
            return _settings.estimatesEnabled;
        }

        /// <summary>
        /// Get the estimate builder template name
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public string BuildEstimateTemplateName(string language)
        {
            //load language
            LoadLanguageFromFile(languageFolder + "\\" + languageFilenamePrefix + language + ".json");

            return _language.estimatesTemplateName;
        }

        /// <summary>
        /// Get the estimate filename
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="estimates_id"></param>
        /// <param name="filefolder"></param>
        /// <returns></returns>
        public string BuildEstimateGetFilename(DentneDModel dentnedModel, int estimates_id, string filefolder)
        {
            return FindRandomFileName(filefolder, "E", "pdf");
        }

        /// <summary>
        /// Build a file for an invoice
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="invoices_id"></param>
        /// <param name="language"></param>
        /// <param name="filename"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public bool BuildInvoice(DentneDModel dentnedModel, int invoices_id, string language, string filename, ref string[] errors)
        {
            bool ret = false;

            //load language
            LoadLanguageFromFile(languageFolder + "\\" + languageFilenamePrefix + language + ".json");

            try
            {
                //get invoices
                invoices invoice = dentnedModel.Invoices.Find(invoices_id);
                if (invoice == null)
                    return false;
                List<invoiceslines> invoicelines = dentnedModel.InvoicesLines.List(r => r.invoices_id == invoice.invoices_id).ToList();

                //fill infos
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                writer.ViewerPreferences = PdfWriter.PageModeUseOutlines;
                PrintPageN printPageN = new PrintPageN();
                writer.PageEvent = printPageN;
                document.Open();

                iTextSharp.text.Font b10Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font b12Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font n10Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font n8Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL);

                PdfPTable titleTable = null;
                PdfPTable preheaderTable = null;
                PdfPTable headerTable = null;
                PdfPTable itemsTable = null;
                PdfPTable paymentTable = null;
                PdfPTable footerTable = null;

                PdfPTable bTable = null;
                PdfPCell aCell = null;
                Phrase phrase = null;

                //titleTable
                titleTable = new PdfPTable(new float[] { 1 });
                titleTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                titleTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                titleTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.invoicesTitle, b12Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aCell.PaddingBottom = 10;
                aCell.HorizontalAlignment = Element.ALIGN_CENTER;
                titleTable.AddCell(aCell);

                //preheaderTable
                preheaderTable = new PdfPTable(new float[] { 1, 1 });
                preheaderTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                preheaderTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                preheaderTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                preheaderTable.SetTotalWidth(new float[] { preheaderTable.TotalWidth / 2, preheaderTable.TotalWidth / 2 });
                phrase = new Phrase();
                if (_settings.invoicesPrintNumber)
                {
                    phrase.Add(new Chunk(_language.invoicesNumber + ": ", b10Font));
                    phrase.Add(new Chunk(invoice.invoices_number, n10Font));
                    phrase.Add(new Chunk("/", n10Font));
                    phrase.Add(new Chunk(invoice.invoices_date.Year.ToString(), n10Font));
                }
                preheaderTable.AddCell(phrase);
                if (_settings.invoicesPrintDate)
                {
                    phrase = new Phrase();
                    phrase.Add(new Chunk(_language.invoicesDate + ": ", b10Font));
                    phrase.Add(new Chunk(invoice.invoices_date.ToShortDateString(), n10Font));
                }
                preheaderTable.AddCell(phrase);

                //headerTable
                headerTable = new PdfPTable(new float[] { 1, 1 });
                headerTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                headerTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                headerTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                headerTable.SetTotalWidth(new float[] { headerTable.TotalWidth / 2, headerTable.TotalWidth / 2 });
                bTable = new PdfPTable(new float[] { 1 });
                bTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                bTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                bTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                phrase = new Phrase();
                phrase.Add(new Chunk(" ", b10Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aCell.PaddingBottom = 5;
                bTable.AddCell(aCell);
                bTable.AddCell(new Paragraph(""));
                phrase = new Phrase();
                phrase.Add(new Chunk(invoice.invoices_doctor, n10Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER + iTextSharp.text.Rectangle.TOP_BORDER + iTextSharp.text.Rectangle.LEFT_BORDER + iTextSharp.text.Rectangle.RIGHT_BORDER;
                aCell.PaddingBottom = 5;
                bTable.AddCell(aCell);
                headerTable.AddCell(bTable);
                bTable = new PdfPTable(new float[] { 1 });
                bTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                bTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                bTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.invoicesPatienttext + ":", b10Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.PaddingBottom = 5;
                bTable.AddCell(aCell);
                bTable.AddCell(new Paragraph(""));
                phrase = new Phrase();
                phrase.Add(new Chunk(invoice.invoices_patient, n10Font));
                bTable.AddCell(phrase);
                headerTable.AddCell(bTable);

                bool hastax = false;
                foreach (invoiceslines invoiceline in invoicelines)
                {
                    if (invoiceline.invoiceslines_taxrate != 0)
                    {
                        hastax = true;
                        break;
                    }
                }

                //itemsTable
                if (hastax)
                {
                    if (_settings.invoicesPrintCode)
                        itemsTable = new PdfPTable(new float[] { 1, 1, 1, 1, 1 });
                    else
                        itemsTable = new PdfPTable(new float[] { 1, 1, 1, 1 });
                }
                else
                {
                    if (_settings.invoicesPrintCode)
                        itemsTable = new PdfPTable(new float[] { 1, 1, 1, 1 });
                    else
                        itemsTable = new PdfPTable(new float[] { 1, 1, 1 });
                }
                itemsTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                itemsTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                itemsTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                if (hastax)
                {
                    if (_settings.invoicesPrintCode)
                        itemsTable.SetTotalWidth(new float[] { 70, itemsTable.TotalWidth - 170, 40, 70, 70 });
                    else
                        itemsTable.SetTotalWidth(new float[] { itemsTable.TotalWidth - 100, 40, 70, 70 });
                }
                else
                {
                    if (_settings.invoicesPrintCode)
                        itemsTable.SetTotalWidth(new float[] { 70, itemsTable.TotalWidth - 100, 40, 70 });
                    else
                        itemsTable.SetTotalWidth(new float[] { itemsTable.TotalWidth - 30, 40, 70 });
                }

                if (_settings.invoicesPrintCode)
                {
                    aCell = new PdfPCell(new Paragraph(_language.invoicesItemsCodeTH, b10Font));
                    aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    aCell.PaddingBottom = 5;
                    itemsTable.AddCell(aCell);
                }
                aCell = new PdfPCell(new Paragraph(_language.invoicesItemsDescriptionTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                aCell.PaddingBottom = 5;
                itemsTable.AddCell(aCell);
                aCell = new PdfPCell(new Paragraph(_language.invoicesItemsQuantityTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                aCell.PaddingBottom = 5;
                itemsTable.AddCell(aCell);
                aCell = new PdfPCell(new Paragraph(_language.invoicesItemsPriceTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                aCell.PaddingBottom = 5;
                itemsTable.AddCell(aCell);
                if (hastax)
                {
                    aCell = new PdfPCell(new Paragraph(_language.invoicesItemsTaxrateTH, b10Font));
                    aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    aCell.PaddingBottom = 5;
                    itemsTable.AddCell(aCell);
                }
                foreach (invoiceslines invoiceline in invoicelines)
                {
                    if (_settings.invoicesPrintCode)
                    {
                        if (!String.IsNullOrEmpty(invoiceline.invoiceslines_code))
                        {
                            if (invoiceline.invoiceslines_code.Trim() != "")
                            {
                                aCell = new PdfPCell(new Paragraph(invoiceline.invoiceslines_code, n10Font));
                                aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                itemsTable.AddCell(aCell);
                            }
                            else
                            {
                                aCell = new PdfPCell(new Paragraph("/", n10Font));
                                aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                itemsTable.AddCell(aCell);
                            }
                        }
                        else
                        {
                            aCell = new PdfPCell(new Paragraph("/", n10Font));
                            aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            itemsTable.AddCell(aCell);
                        }
                    }
                    aCell = new PdfPCell(new Paragraph(invoiceline.invoiceslines_description, n10Font));
                    aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    itemsTable.AddCell(aCell);
                    aCell = new PdfPCell(new Paragraph(invoiceline.invoiceslines_quantity.ToString(), n10Font));
                    aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    itemsTable.AddCell(aCell);
                    aCell = new PdfPCell(new Paragraph(Math.Round(invoiceline.invoiceslines_unitprice, 2).ToString(), n10Font));
                    aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    itemsTable.AddCell(aCell);
                    if (hastax)
                    {
                        if (invoiceline.invoiceslines_taxrate != 0)
                        {
                            aCell = new PdfPCell(new Paragraph(Math.Round(invoiceline.invoiceslines_taxrate, 2) + "%", n10Font));
                            aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            itemsTable.AddCell(aCell);
                        }
                        else
                        {
                            aCell = new PdfPCell(new Paragraph("/", n10Font));
                            aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            itemsTable.AddCell(aCell);
                        }
                    }
                }

                decimal totalnotax = 0;
                decimal totaltax = 0;
                decimal totaldeductiontax = 0;
                dentnedModel.Invoices.CalculateTotal(invoice, ref totaltax, ref totaldeductiontax, ref totalnotax);

                //paymentTable
                paymentTable = new PdfPTable(new float[] { 1, 1 });
                paymentTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                paymentTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                paymentTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                paymentTable.SetTotalWidth(new float[] { paymentTable.TotalWidth / 2, paymentTable.TotalWidth / 2 });

                bTable = new PdfPTable(new float[] { 1 });
                bTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                bTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                bTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

                if (!String.IsNullOrEmpty(invoice.invoices_payment))
                {
                    if (invoice.invoices_payment.Trim() != "")
                    {
                        phrase = new Phrase();
                        phrase.Add(new Chunk(_language.invoicesPaymentext + ":", b10Font));
                        aCell = new PdfPCell(phrase);
                        aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                        aCell.PaddingBottom = 5;
                        bTable.AddCell(aCell);
                        bTable.AddCell(new Paragraph(""));
                        phrase = new Phrase();
                        phrase.Add(new Chunk(invoice.invoices_payment, n10Font));
                        bTable.AddCell(phrase);
                    }
                }

                paymentTable.AddCell(bTable);

                bTable = new PdfPTable(new float[] { 1 });
                bTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                bTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                bTable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.invoicesTotals + ":", b10Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.PaddingBottom = 5;
                bTable.AddCell(aCell);
                bTable.AddCell(new Paragraph(""));

                List<decimal> taxvaluel = new List<decimal>();
                foreach (invoiceslines invoiceline in invoicelines.OrderByDescending(r => r.invoiceslines_taxrate))
                {
                    if (!taxvaluel.Contains(invoiceline.invoiceslines_taxrate))
                        taxvaluel.Add(invoiceline.invoiceslines_taxrate);
                }

                if (taxvaluel.Count > 0 && !taxvaluel.All(r => r == 0))
                {
                    phrase = new Phrase();

                    phrase.Add(new Chunk(_language.invoicesTotalsTotalnotax + ": ", b10Font));
                    foreach (decimal taxvalue in taxvaluel)
                    {
                        string valuestring = "";
                        decimal valuetotal = 0;
                        foreach (invoiceslines invoiceline in invoicelines.Where(r => r.invoiceslines_taxrate == taxvalue))
                        {
                            valuetotal += invoiceline.invoiceslines_quantity * invoiceline.invoiceslines_unitprice;
                        }
                        if (valuetotal != 0)
                        {
                            valuestring += "(" + Math.Round(taxvalue, 2) + "%) " + Math.Round(valuetotal, 2);
                            phrase.Add(new Chunk(valuestring + "\n", n10Font));
                        }
                    }
                    if (taxvaluel.Count > 1)
                        phrase.Add(new Chunk(Math.Round(totalnotax, 2) + "\n", n10Font));

                    phrase.Add(new Chunk(_language.invoicesTotalsTotaltax + ": ", b10Font));
                    foreach (decimal taxvalue in taxvaluel)
                    {
                        string taxvaluestring = "";
                        decimal taxvaluetotal = 0;
                        foreach (invoiceslines invoiceline in invoicelines.Where(r => r.invoiceslines_taxrate == taxvalue))
                        {
                            taxvaluetotal += invoiceline.invoiceslines_quantity * (invoiceline.invoiceslines_unitprice * invoiceline.invoiceslines_taxrate / 100);
                        }
                        if (taxvaluetotal != 0)
                        {
                            taxvaluestring += "(" + Math.Round(taxvalue, 2) + "%) " + Math.Round(taxvaluetotal, 2);
                            phrase.Add(new Chunk(taxvaluestring + "\n", n10Font));
                        }
                    }
                    if (taxvaluel.Count > 1)
                        phrase.Add(new Chunk(Math.Round(totaltax, 2) + "\n", n10Font));

                    bTable.AddCell(phrase);
                }

                if (totaldeductiontax != 0)
                {
                    phrase = new Phrase();
                    phrase.Add(new Chunk(_language.invoicesTotalsTotaldocument + ": ", b10Font));
                    phrase.Add(new Chunk(Math.Round(totalnotax + totaltax, 2) + "\n", n10Font));
                    phrase.Add(new Chunk(_language.invoicesTotalsTotaldeductiontax + ": ", b10Font));
                    phrase.Add(new Chunk("(" + Math.Round(invoice.invoices_deductiontaxrate, 2) + "%) " + Math.Round(totaldeductiontax, 2) + "\n", n10Font));
                    aCell = new PdfPCell(phrase);
                    aCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    aCell.PaddingTop = 4;
                    aCell.PaddingBottom = 4;
                    bTable.AddCell(aCell);
                }

                phrase = new Phrase();
                phrase.Add(new Chunk(_language.invoicesTotalsTotalamountdue + ": ", b10Font));
                phrase.Add(new Chunk(Math.Round(totalnotax + totaltax - totaldeductiontax, 2) + "\n", b10Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                aCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                aCell.PaddingTop = 4;
                aCell.PaddingBottom = 4;
                bTable.AddCell(aCell);
                paymentTable.AddCell(bTable);

                //footerTable
                footerTable = new PdfPTable(new float[] { 1 });
                footerTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                footerTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                footerTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                if (!String.IsNullOrEmpty(invoice.invoices_footer))
                {
                    if (invoice.invoices_footer.Trim() != "")
                    {
                        phrase = new Phrase();
                        phrase.Add(new Chunk(invoice.invoices_footer, n8Font));
                        aCell = new PdfPCell(phrase);
                        aCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                        aCell.PaddingTop = 5;
                        footerTable.AddCell(aCell);
                    }
                }

                //add tables
                document.Add(titleTable);
                document.Add(preheaderTable);
                document.Add(headerTable);
                document.Add(new Paragraph(" "));
                document.Add(itemsTable);
                if (writer.GetVerticalPosition(false) < paymentTable.TotalHeight + footerTable.TotalHeight + (float)80)
                {
                    float currentvert = writer.GetVerticalPosition(false);
                    document.Add(new Paragraph(" "));
                    while (writer.GetVerticalPosition(false) < currentvert)
                        document.Add(new Paragraph(" "));
                }
                while (writer.GetVerticalPosition(false) > paymentTable.TotalHeight + footerTable.TotalHeight + (float)80)
                    document.Add(new Paragraph(" "));
                document.Add(paymentTable);
                if (footerTable != null)
                    document.Add(footerTable);

                document.Close();

                ret = true;
            }
            catch
            {
                errors = errors.Concat(new string[] { _language.buildfileerrorMessage }).ToArray();
                return false;
            }

            return ret;
        }

        /// <summary>
        /// Check if invoice builder is enabled
        /// </summary>
        /// <returns></returns>
        public bool IsBuildInvoiceEnabled()
        {
            return _settings.invoicesEnabled;
        }

        /// <summary>
        /// Get the invoice builder template name
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public string BuildInvoiceTemplateName(string language)
        {
            //load language
            LoadLanguageFromFile(languageFolder + "\\" + languageFilenamePrefix + language + ".json");

            return _language.invoicesTemplateName;
        }

        /// <summary>
        /// Get the invoice filename
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="invoices_id"></param>
        /// <param name="filefolder"></param>
        /// <returns></returns>
        public string BuildInvoiceGetFilename(DentneDModel dentnedModel, int invoices_id, string filefolder)
        {
            invoices invoice = dentnedModel.Invoices.Find(invoices_id);
            return filefolder + "\\" + (invoice.doctors_id != null ? ((int)invoice.doctors_id).ToString() + "_" : null) + invoice.invoices_date.Year.ToString() + "-" + invoice.invoices_number + ".pdf";
        }

        /// <summary>
        /// Build a file for patient treatments
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="patients_id"></param>
        /// <param name="patientstreatmentsl"></param>
        /// <param name="language"></param>
        /// <param name="filename"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public bool BuildPatientTreatments(DentneDModel dentnedModel, int patients_id, patientstreatments[] patientstreatmentsl, string language, string filename, ref string[] errors)
        {
            return false;
        }

        /// <summary>
        /// Check if patient treatments builder is enabled
        /// </summary>
        /// <returns></returns>
        public bool IsBuildPatientTreatmentsTemplateEnabled()
        {
            return false;
        }

        /// <summary>
        /// Get the patient treatments builder template name
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public string BuildPatientTreatmentsTemplateName(string language)
        {
            return null;
        }

        /// <summary>
        /// Get the patient treatments filename
        /// </summary>
        /// <param name="filefolder"></param>
        /// <returns></returns>
        public string BuildPatientTreatmentsGetFilename(string filefolder)
        {
            return null;
        }

        /// <summary>
        /// PDF pager class
        /// </summary>
        private class PrintPageN : PdfPageEventHelper
        {
            public override void OnOpenDocument(PdfWriter writer, Document document)
            { }

            public override void OnStartPage(PdfWriter writer, Document document)
            { }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                try
                {
                    PdfContentByte contentunder = writer.DirectContentUnder;
                    contentunder.SetRGBColorFill(100, 100, 100);

                    base.OnEndPage(writer, document);

                    contentunder.BeginText();
                    contentunder.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 8);
                    contentunder.SetTextMatrix(document.PageSize.GetLeft(40), document.PageSize.GetBottom(30));
                    contentunder.ShowText("Page " + writer.PageNumber);
                    contentunder.EndText();
                }
                catch { }
            }

            public override void OnCloseDocument(PdfWriter writer, Document document)
            { }
        }

        /// <summary>
        /// Find a random filename that does not exists on a folder
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="prefix"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        private static string FindRandomFileName(string folder, string prefix, string extension)
        {
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 12; i++)
            {
                //26 letters in the alfabet, ascii + 65 for the capital letters
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65))));
            }
            string randomtext = builder.ToString();
            string filename = null;
            int tries = 0;
            do
            {
                filename = folder + "\\" + (!String.IsNullOrEmpty(prefix) ? prefix + "_" : "") + String.Format("{0:yyyyMMddHHmm}", DateTime.Now) + "-" + randomtext + "." + extension;
                tries++;
            } while (File.Exists(filename) || tries < 100);
            return filename;
        }

    }
}
