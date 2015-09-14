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
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace DG.DentneD
{

    public class DentneDPrintModel : IDentneDPrintModel
    {
        /// <summary>
        /// DentneDPrintModel language dictionary
        /// </summary>
        private class DentneDPrintModelLanguage
        {
            public string estimatesTitle = "Estimate";
            public string estimatesNumber = "Number";
            public string estimatesDate = "Date";
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
            public string invoicesTitle = "Invoice";
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
        }

        /// <summary>
        /// Settings model
        /// </summary>
        private class DentneDPrintModelDefaultSettings
        {
            /// <summary>
            /// Print code on items lines
            /// </summary>
            public bool printCode = true;
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
        private const string languageFilenamePrefix = "DentneDPrintModelDefault-";

        /// <summary>
        /// Default settings file
        /// </summary>
        private const string languageSettingsFilename = "DentneDPrintModelDefault.json";
        
        /// <summary>
        /// Settings
        /// </summary>
        private DentneDPrintModelDefaultSettings _settings = new DentneDPrintModelDefaultSettings();

        public DentneDPrintModel()
        {
            //load settings
            try
            {
                string jsontext = File.ReadAllText(languageSettingsFilename);
                _settings = new JavaScriptSerializer().Deserialize<DentneDPrintModelDefaultSettings>(jsontext);
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
        /// Build a PDF for an estimate
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="estimates_id"></param>
        /// <param name="filename"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public bool BuildEstimatePDF(DentneDModel dentnedModel, int estimates_id, string filename, string language)
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

                PdfPTable aTable = null;
                PdfPTable bTable = null;
                PdfPCell aCell = null;
                Phrase phrase = null;

                //title
                aTable = new PdfPTable(new float[] { 1 });
                aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.estimatesTitle, b12Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aCell.PaddingBottom = 10;
                aCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.AddCell(aCell);
                document.Add(aTable);

                //number data
                aTable = new PdfPTable(new float[] { 1, 1 });
                aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.SetTotalWidth(new float[] { aTable.TotalWidth / 2, aTable.TotalWidth / 2 });
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.estimatesNumber + ": ", b10Font));
                phrase.Add(new Chunk(estimate.estimates_number, n10Font));
                phrase.Add(new Chunk("/", n10Font));
                phrase.Add(new Chunk(estimate.estimates_date.Year.ToString(), n10Font));
                aTable.AddCell(phrase);
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.estimatesDate + ": ", b10Font));
                phrase.Add(new Chunk(estimate.estimates_date.ToShortDateString(), n10Font));
                aTable.AddCell(phrase);
                document.Add(aTable);

                //doctor patient
                aTable = new PdfPTable(new float[] { 1, 1 });
                aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                aTable.SetTotalWidth(new float[] { aTable.TotalWidth / 2, aTable.TotalWidth / 2 });
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
                aTable.AddCell(bTable);
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
                aTable.AddCell(bTable);
                document.Add(aTable);

                document.Add(new Paragraph(" "));

                bool hastax = false;
                foreach (estimateslines estimateline in estimatelines)
                {
                    if (estimateline.estimateslines_taxrate != 0)
                    {
                        hastax = true;
                        break;
                    }
                }

                //items
                if (hastax)
                {
                    if(_settings.printCode)
                        aTable = new PdfPTable(new float[] { 1, 1, 1, 1, 1 });
                    else
                        aTable = new PdfPTable(new float[] { 1, 1, 1, 1 });
                }
                else
                {
                    if (_settings.printCode)
                        aTable = new PdfPTable(new float[] { 1, 1, 1, 1 });
                    else
                        aTable = new PdfPTable(new float[] { 1, 1, 1 });
                }
                aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                if (hastax)
                {
                    if (_settings.printCode)
                        aTable.SetTotalWidth(new float[] { 70, aTable.TotalWidth - 170, 40, 70, 70 });
                    else
                        aTable.SetTotalWidth(new float[] { aTable.TotalWidth - 100, 40, 70, 70 });
                }
                else
                {
                    if (_settings.printCode)
                        aTable.SetTotalWidth(new float[] { 70, aTable.TotalWidth - 100, 40, 70 });
                    else
                        aTable.SetTotalWidth(new float[] { aTable.TotalWidth - 30, 40, 70 });
                }

                if (_settings.printCode)
                {
                    aCell = new PdfPCell(new Paragraph(_language.estimatesItemsCodeTH, b10Font));
                    aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    aCell.PaddingBottom = 5;
                    aTable.AddCell(aCell);
                }
                aCell = new PdfPCell(new Paragraph(_language.estimatesItemsDescriptionTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.PaddingBottom = 5;
                aTable.AddCell(aCell);
                aCell = new PdfPCell(new Paragraph(_language.estimatesItemsQuantityTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.PaddingBottom = 5;
                aTable.AddCell(aCell);
                aCell = new PdfPCell(new Paragraph(_language.estimatesItemsPriceTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.PaddingBottom = 5;
                aTable.AddCell(aCell);
                if (hastax)
                {
                    aCell = new PdfPCell(new Paragraph(_language.estimatesItemsTaxrateTH, b10Font));
                    aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    aCell.PaddingBottom = 5;
                    aTable.AddCell(aCell);
                }
                foreach (estimateslines estimateline in estimatelines)
                {
                    if (_settings.printCode)
                    {
                        if (!String.IsNullOrEmpty(estimateline.estimateslines_code))
                            if (estimateline.estimateslines_code.Trim() != "")
                                aTable.AddCell(new Paragraph(estimateline.estimateslines_code, n10Font));
                            else
                                aTable.AddCell(new Paragraph("/"));
                        else
                            aTable.AddCell(new Paragraph("/"));
                    }
                    aTable.AddCell(new Paragraph(estimateline.estimateslines_description, n10Font));
                    aTable.AddCell(new Paragraph(estimateline.estimateslines_quantity.ToString(), n10Font));
                    aTable.AddCell(new Paragraph(Math.Round(estimateline.estimateslines_unitprice, 2).ToString(), n10Font));
                    if (hastax)
                    {
                        if (estimateline.estimateslines_taxrate != 0)
                            aTable.AddCell(new Paragraph(Math.Round(estimateline.estimateslines_taxrate, 2) + "%", n10Font));
                        else
                            aTable.AddCell(new Paragraph("/"));
                    }
                }
                document.Add(aTable);

                if (writer.GetVerticalPosition(false) < 220)
                {
                    float currentvert = writer.GetVerticalPosition(false);
                    document.Add(new Paragraph(" "));
                    while (writer.GetVerticalPosition(false) < currentvert)
                        document.Add(new Paragraph(" "));
                }
                while (writer.GetVerticalPosition(false) > (float)220)
                    document.Add(new Paragraph(" "));


                decimal totalnotax = 0;
                decimal totaltax = 0;
                decimal totaldeductiontax = 0;
                dentnedModel.Estimates.CalculateTotal(estimate, ref totaltax, ref totaldeductiontax, ref totalnotax);
                
                //payment
                aTable = new PdfPTable(new float[] { 1, 1 });
                aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                aTable.SetTotalWidth(new float[] { aTable.TotalWidth / 2, aTable.TotalWidth / 2 });

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

                aTable.AddCell(bTable);

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

                aTable.AddCell(bTable);

                document.Add(aTable);

                //footer
                if (!String.IsNullOrEmpty(estimate.estimates_footer))
                {
                    if (estimate.estimates_footer.Trim() != "")
                    {
                        aTable = new PdfPTable(new float[] { 1 });
                        aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                        aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        phrase = new Phrase();
                        phrase.Add(new Chunk(estimate.estimates_footer, n8Font));
                        aCell = new PdfPCell(phrase);
                        aCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                        aCell.PaddingTop = 5;
                        aTable.AddCell(aCell);
                        document.Add(aTable);
                    }
                }

                document.Close();

                ret = true;
            }
            catch { }
            
            return ret;
        }

        
        /// <summary>
        /// Build a PDF for an invoice
        /// </summary>
        /// <param name="dentnedModel"></param>
        /// <param name="invoices_id"></param>
        /// <param name="filename"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public bool BuildInvoicePDF(DentneDModel dentnedModel, int invoices_id, string filename, string language)
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

                PdfPTable aTable = null;
                PdfPTable bTable = null;
                PdfPCell aCell = null;
                Phrase phrase = null;

                //title
                aTable = new PdfPTable(new float[] { 1 });
                aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.invoicesTitle, b12Font));
                aCell = new PdfPCell(phrase);
                aCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aCell.PaddingBottom = 10;
                aCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.AddCell(aCell);
                document.Add(aTable);

                //number data
                aTable = new PdfPTable(new float[] { 1, 1 });
                aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                aTable.SetTotalWidth(new float[] { aTable.TotalWidth / 2, aTable.TotalWidth / 2 });
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.invoicesNumber + ": ", b10Font));
                phrase.Add(new Chunk(invoice.invoices_number, n10Font));
                phrase.Add(new Chunk("/", n10Font));
                phrase.Add(new Chunk(invoice.invoices_date.Year.ToString(), n10Font));
                aTable.AddCell(phrase);
                phrase = new Phrase();
                phrase.Add(new Chunk(_language.invoicesDate + ": ", b10Font));
                phrase.Add(new Chunk(invoice.invoices_date.ToShortDateString(), n10Font));
                aTable.AddCell(phrase);
                document.Add(aTable);

                //doctor patient
                aTable = new PdfPTable(new float[] { 1, 1 });
                aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                aTable.SetTotalWidth(new float[] { aTable.TotalWidth / 2, aTable.TotalWidth / 2 });
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
                aTable.AddCell(bTable);
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
                aTable.AddCell(bTable);
                document.Add(aTable);

                document.Add(new Paragraph(" "));

                bool hastax = false;
                foreach (invoiceslines invoiceline in invoicelines)
                {
                    if (invoiceline.invoiceslines_taxrate != 0)
                    {
                        hastax = true;
                        break;
                    }
                }

                //items
                if (hastax)
                {
                    if (_settings.printCode)
                        aTable = new PdfPTable(new float[] { 1, 1, 1, 1, 1 });
                    else
                        aTable = new PdfPTable(new float[] { 1, 1, 1, 1 });
                }
                else
                {
                    if (_settings.printCode)
                        aTable = new PdfPTable(new float[] { 1, 1, 1, 1 });
                    else
                        aTable = new PdfPTable(new float[] { 1, 1, 1 });
                }
                aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                if (hastax)
                {
                    if (_settings.printCode)
                        aTable.SetTotalWidth(new float[] { 70, aTable.TotalWidth - 170, 40, 70, 70 });
                    else
                        aTable.SetTotalWidth(new float[] { aTable.TotalWidth - 100, 40, 70, 70 });
                }
                else
                {
                    if (_settings.printCode)
                        aTable.SetTotalWidth(new float[] { 70, aTable.TotalWidth - 100, 40, 70 });
                    else
                        aTable.SetTotalWidth(new float[] { aTable.TotalWidth - 30, 40, 70 });
                }

                if (_settings.printCode)
                {
                    aCell = new PdfPCell(new Paragraph(_language.invoicesItemsCodeTH, b10Font));
                    aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    aCell.PaddingBottom = 5;
                    aTable.AddCell(aCell);
                }                
                aCell = new PdfPCell(new Paragraph(_language.invoicesItemsDescriptionTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.PaddingBottom = 5;
                aTable.AddCell(aCell);
                aCell = new PdfPCell(new Paragraph(_language.invoicesItemsQuantityTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.PaddingBottom = 5;
                aTable.AddCell(aCell);
                aCell = new PdfPCell(new Paragraph(_language.invoicesItemsPriceTH, b10Font));
                aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                aCell.PaddingBottom = 5;
                aTable.AddCell(aCell);
                if (hastax)
                {
                    aCell = new PdfPCell(new Paragraph(_language.invoicesItemsTaxrateTH, b10Font));
                    aCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    aCell.PaddingBottom = 5;
                    aTable.AddCell(aCell);
                }
                foreach (invoiceslines invoiceline in invoicelines)
                {
                    if (_settings.printCode)
                    {
                        if (!String.IsNullOrEmpty(invoiceline.invoiceslines_code))
                            if (invoiceline.invoiceslines_code.Trim() != "")
                                aTable.AddCell(new Paragraph(invoiceline.invoiceslines_code, n10Font));
                            else
                                aTable.AddCell(new Paragraph("/"));
                        else
                            aTable.AddCell(new Paragraph("/"));
                    }
                    aTable.AddCell(new Paragraph(invoiceline.invoiceslines_description, n10Font));
                    aTable.AddCell(new Paragraph(invoiceline.invoiceslines_quantity.ToString(), n10Font));
                    aTable.AddCell(new Paragraph(Math.Round(invoiceline.invoiceslines_unitprice, 2).ToString(), n10Font));
                    if (hastax)
                    {
                        if (invoiceline.invoiceslines_taxrate != 0)
                            aTable.AddCell(new Paragraph(Math.Round(invoiceline.invoiceslines_taxrate, 2) + "%", n10Font));
                        else
                            aTable.AddCell(new Paragraph("/"));
                    }
                }
                document.Add(aTable);

                if (writer.GetVerticalPosition(false) < 230)
                {
                    float currentvert = writer.GetVerticalPosition(false);
                    document.Add(new Paragraph(" "));
                    while (writer.GetVerticalPosition(false) < currentvert)
                        document.Add(new Paragraph(" "));
                }
                while (writer.GetVerticalPosition(false) > (float)230)
                    document.Add(new Paragraph(" "));
                
                decimal totalnotax = 0;
                decimal totaltax = 0;
                decimal totaldeductiontax = 0;
                dentnedModel.Invoices.CalculateTotal(invoice, ref totaltax, ref totaldeductiontax, ref totalnotax);

                //payment
                aTable = new PdfPTable(new float[] { 1, 1 });
                aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                aTable.SetTotalWidth(new float[] { aTable.TotalWidth / 2, aTable.TotalWidth / 2 });

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

                aTable.AddCell(bTable);

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

                aTable.AddCell(bTable);

                document.Add(aTable);

                //footer
                if (!String.IsNullOrEmpty(invoice.invoices_footer))
                {
                    if (invoice.invoices_footer.Trim() != "")
                    {
                        aTable = new PdfPTable(new float[] { 1 });
                        aTable.TotalWidth = PageSize.A4.Width - document.RightMargin - document.LeftMargin;
                        aTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        aTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        phrase = new Phrase();
                        phrase.Add(new Chunk(invoice.invoices_footer, n8Font));
                        aCell = new PdfPCell(phrase);
                        aCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                        aCell.PaddingTop = 5;
                        aTable.AddCell(aCell);
                        document.Add(aTable);
                    }
                }

                document.Close();

                ret = true;
            }
            catch { }

            return ret;
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

    }
}
