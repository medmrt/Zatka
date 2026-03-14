using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xmler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Test_Zatka_Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateZatcaInvoiceWithLines();
            //GenerateZatcaFinalCompliance();
        }

        public void GenerateZatcaInvoiceWithLines()
        {
            var invoice = new Invoice
            {
                ProfileID = "reporting:1.0",
                ID = new ID { Text = "INV-2026-001" },
                UUID = System.Guid.NewGuid().ToString(),
                IssueDate = "2026-03-13",
                IssueTime = "21:30:00",
                InvoiceTypeCode = new InvoiceTypeCode { name = "0100000", Text = "388" },
                // MANDATORY ORDER: Currencies must come before Parties and Lines
                DocumentCurrencyCode = "SAR",
                TaxCurrencyCode = "SAR"
            };

            // 1. AdditionalDocumentReference (ICV/PIH)
            invoice.AdditionalDocumentReference = new List<AdditionalDocumentReference>();
            invoice.AdditionalDocumentReference.Add(new AdditionalDocumentReference { ID = new ID { Text = "ICV" }, UUID = "1" });
            invoice.AdditionalDocumentReference.Add(new AdditionalDocumentReference
            {
                ID = new ID { Text = "PIH" },
                Attachment = new Attachment { EmbeddedDocumentBinaryObject = new EmbeddedDocumentBinaryObject { mimeCode = "text/plain", Text = "NWZlYjY5YjY5YjY5YjY5YjY5YjY5YjY5YjY5YjY5YjY5YjY=" } }
            });

            // 2. AccountingSupplierParty
            // Inside your GenerateZatcaInvoiceWithLines method:

            invoice.AccountingSupplierParty = new AccountingSupplierParty
            {
                Party = new Party
                {
                    // Optional: Commercial Registration (CRN)
                    PartyIdentification = new PartyIdentification
                    {
                        ID = new ID { schemeID = "CRN", Text = "1010000000" }
                    },

                    PartyLegalEntity = new PartyLegalEntity { RegistrationName = "Seller Company Name" },

                    PostalAddress = new PostalAddress
                    {
                        StreetName = "Main St",
                        BuildingNumber = "1234",
                        CitySubdivisionName = "District",
                        CityName = "Riyadh",
                        PostalZone = "12345",
                        Country = new Country { IdentificationCode = "SA" }
                    },

                    // FIX for BR-KSA-39: This block provides the VAT Registration Number (BT-31)
                    PartyTaxScheme = new PartyTaxScheme
                    {
                        // This MUST be the 15-digit VAT number
                        CompanyID = "300012345600003",
                        TaxScheme = new TaxScheme { ID = new ID { Text = "VAT" } }
                    }
                }
            };


            // 3. AccountingCustomerParty
            invoice.AccountingCustomerParty = new AccountingCustomerParty
            {
                Party = new Party
                {
                    // Optional: Buyer's Identification (e.g., CRN, National ID, or 700 number)
                    PartyIdentification = new PartyIdentification
                    {
                        ID = new ID { schemeID = "CRN", Text = "1010101010" }
                    },

                    // Mandatory: Buyer's Legal Name (BT-44)
                    PartyLegalEntity = new PartyLegalEntity
                    {
                        RegistrationName = "Buyer Company Name"
                    },

                    // Mandatory: Buyer's Postal Address (BG-8)
                    PostalAddress = new PostalAddress
                    {
                        StreetName = "King Fahd Road",
                        BuildingNumber = "5678",
                        CitySubdivisionName = "Al-Olaya", // District
                        CityName = "Riyadh",
                        PostalZone = "12222",
                        Country = new Country { IdentificationCode = "SA" }
                    },

                    // Mandatory for Tax Invoices: Buyer's VAT Registration (BT-48)
                    PartyTaxScheme = new PartyTaxScheme
                    {
                        // Must be the 15-digit VAT number of the buyer
                        CompanyID = "300099999900003",
                        TaxScheme = new TaxScheme { ID = new ID { Text = "VAT" } }
                    }
                }
            };

            // 4. Delivery (Supply Date)
            invoice.Delivery = new Delivery { ActualDeliveryDate = "2026-03-13" };

            // 5. TaxTotal (Invoice Level Breakdown)
            var vatBreakdown = new TaxTotal
            {
                TaxAmount = new TaxAmount { currencyID = "SAR", Text = "15.00" },
                TaxSubtotal = new TaxSubtotal
                {
                    TaxableAmount = new TaxableAmount { currencyID = "SAR", Text = "100.00" },
                    TaxAmount = new TaxAmount { currencyID = "SAR", Text = "15.00" },
                    TaxCategory = new TaxCategory
                    {
                        ID = new ID { Text = "S" },
                        Percent = "15.00",
                        TaxScheme = new TaxScheme { ID = new ID { Text = "VAT" } }
                    }
                }
            };
            invoice.TaxTotal = new List<TaxTotal> { vatBreakdown };

            // 6. LegalMonetaryTotal
            invoice.LegalMonetaryTotal = new LegalMonetaryTotal
            {
                LineExtensionAmount = new LineExtensionAmount { currencyID = "SAR", Text = "100.00" },
                TaxExclusiveAmount = new TaxExclusiveAmount { currencyID = "SAR", Text = "100.00" },
                TaxInclusiveAmount = new TaxInclusiveAmount { currencyID = "SAR", Text = "115.00" },
                PayableAmount = new PayableAmount { currencyID = "SAR", Text = "115.00" }
            };

            // 7. Invoice Lines (ALWAYS LAST)
            invoice.InvoiceLine = new List<InvoiceLine>();
            invoice.InvoiceLine.Add(new InvoiceLine
            {
                ID = new ID { Text = "1" },
                InvoicedQuantity = new InvoicedQuantity { unitCode = "PCE", Text = "1.00" },
                LineExtensionAmount = new LineExtensionAmount { currencyID = "SAR", Text = "100.00" },

                // FIX for BR-KSA-53: Added RoundingAmount (KSA-12)
                TaxTotal = new TaxTotal
                {
                    TaxAmount = new TaxAmount { currencyID = "SAR", Text = "15.00" },
                    RoundingAmount = new RoundingAmount { currencyID = "SAR", Text = "115.00" } // Line Total Inc. VAT
                },

                Item = new Item
                {
                    Name = "Product Name",
                    ClassifiedTaxCategory = new ClassifiedTaxCategory
                    {
                        ID = new ID { Text = "S" },
                        Percent = "15.00",
                        TaxScheme = new TaxScheme { ID = new ID { Text = "VAT" } }
                    }
                },
                Price = new Price { PriceAmount = new PriceAmount { currencyID = "SAR", Text = "100.00" } }
            });

            Utilities.Serialize(invoice, "D:\\InvoiceWithLines.xml");
        }
    }
}
