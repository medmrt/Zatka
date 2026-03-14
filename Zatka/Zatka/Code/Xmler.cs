using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xmler
{
    public static class Utilities
    {
        public static Invoice DeSerialize(string filePath)
        {
            var ser = new XmlSerializer(typeof(Invoice));
            using (var x = XmlReader.Create(filePath))
            {
                return (Invoice)ser.Deserialize(x);
            }
        }
        public static void Serialize(Invoice obj, string filePath)
        {
            var serializer = new XmlSerializer(typeof(Invoice));
            var ns = new XmlSerializerNamespaces();
            ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            ns.Add("ds", "http://www.w3.org/2000/09/xmldsig#");
            ns.Add("sig", "urn:oasis:names:specification:ubl:schema:xsd:CommonSignatureComponents-2");
            ns.Add("sac", "urn:oasis:names:specification:ubl:schema:xsd:SignatureAggregateComponents-2");
            ns.Add("sbc", "urn:oasis:names:specification:ubl:schema:xsd:SignatureBasicComponents-2");
            ns.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            using (var sw = new StreamWriter(filePath))
            {
                serializer.Serialize(sw, obj, ns);
            }
        }
    }
    [XmlRoot("Invoice", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")]
    public class Invoice
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlArray(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        [XmlArrayItem(typeof(UBLExtension))]
        public List<object> UBLExtensions { get; set; } = null;//new List<object>();
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ProfileID { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string UUID { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueDate { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IssueTime { get; set; } = null;
        [XmlElement("InvoiceTypeCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public InvoiceTypeCode InvoiceTypeCode { get; set; }
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string DocumentCurrencyCode { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string TaxCurrencyCode { get; set; } = null;
        [XmlElement("AdditionalDocumentReference" , Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public List<AdditionalDocumentReference> AdditionalDocumentReference { get; set; } = null;//new List<AdditionalDocumentReference>();
        [XmlElement("AccountingSupplierParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AccountingSupplierParty AccountingSupplierParty { get; set; }
        [XmlElement("AccountingCustomerParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AccountingCustomerParty AccountingCustomerParty { get; set; }
        [XmlElement("Delivery", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Delivery Delivery { get; set; }
        [XmlElement("TaxTotal" , Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public List<TaxTotal> TaxTotal { get; set; } = null;//new List<TaxTotal>();
        [XmlElement("LegalMonetaryTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public LegalMonetaryTotal LegalMonetaryTotal { get; set; }
        [XmlElement("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public Note Note { get; set; }
        [XmlElement("BillingReference" , Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public List<BillingReference> BillingReference { get; set; } = null;//new List<BillingReference>();
        [XmlElement("Signature", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public SignatureCAC SignatureCAC { get; set; }
        [XmlElement("PaymentMeans", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PaymentMeans PaymentMeans { get; set; }
        [XmlElement("AllowanceCharge", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public AllowanceCharge AllowanceCharge { get; set; }
        [XmlElement("InvoiceLine" , Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public List<InvoiceLine> InvoiceLine { get; set; } = null;//new List<InvoiceLine>();
    }
    [XmlType("BillingReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class BillingReference
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("InvoiceDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public InvoiceDocumentReference InvoiceDocumentReference { get; set; }
    }
    [XmlType("InvoiceDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class InvoiceDocumentReference
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
    }
    [XmlType("Delivery", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public class Delivery
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ActualDeliveryDate { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string LatestDeliveryDate { get; set; } = null;
    }
    [XmlType("ID")]
    public class ID
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string schemeID { get; set; } = null;
        public bool ShouldSerializeschemeID() => !string.IsNullOrEmpty(schemeID);
        [XmlAttribute]
        public string schemeAgencyID { get; set; } = null;
        public bool ShouldSerializeschemeAgencyID() => !string.IsNullOrEmpty(schemeAgencyID);
    }
    [XmlType("InvoiceLine")]
    public class InvoiceLine
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement("InvoicedQuantity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public InvoicedQuantity InvoicedQuantity { get; set; }
        [XmlElement("LineExtensionAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public LineExtensionAmount LineExtensionAmount { get; set; }
        [XmlElement("TaxTotal")]
        public TaxTotal TaxTotal { get; set; }
        [XmlElement("Item")]
        public Item Item { get; set; }
        [XmlElement("Price")]
        public Price Price { get; set; }
    }
    [XmlType("Price")]
    public class Price
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("PriceAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PriceAmount PriceAmount { get; set; }
        [XmlElement("AllowanceCharge")]
        public AllowanceCharge AllowanceCharge { get; set; }
    }
    [XmlType("PriceAmount")]
    public class PriceAmount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("Item")]
    public class Item
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Name { get; set; } = null;
        [XmlElement("ClassifiedTaxCategory")]
        public ClassifiedTaxCategory ClassifiedTaxCategory { get; set; }
    }
    [XmlType("ClassifiedTaxCategory")]
    public class ClassifiedTaxCategory
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Percent { get; set; } = null;
        [XmlElement("TaxScheme")]
        public TaxScheme TaxScheme { get; set; }
    }
    [XmlType("TaxTotal")]
    public class TaxTotal
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
        [XmlElement("TaxAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxAmount TaxAmount { get; set; }
        [XmlElement("RoundingAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public RoundingAmount RoundingAmount { get; set; }
        [XmlElement("TaxSubtotal")]
        public TaxSubtotal TaxSubtotal { get; set; }
    }
    [XmlType("TaxSubtotal")]
    public class TaxSubtotal
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("TaxableAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxableAmount TaxableAmount { get; set; }
        [XmlElement("TaxAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxAmount TaxAmount { get; set; }
        [XmlElement("TaxCategory")]
        public TaxCategory TaxCategory { get; set; }
    }
    [XmlType("TaxableAmount")]
    public class TaxableAmount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("TaxAmount")]
    public class TaxAmount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("RoundingAmount")]
    public class RoundingAmount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("InvoicedQuantity")]
    public class InvoicedQuantity
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string unitCode { get; set; } = null;
        public bool ShouldSerializeunitCode() => !string.IsNullOrEmpty(unitCode);
    }
    [XmlType("LegalMonetaryTotal")]
    public class LegalMonetaryTotal
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("LineExtensionAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public LineExtensionAmount LineExtensionAmount { get; set; }
        [XmlElement("TaxExclusiveAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxExclusiveAmount TaxExclusiveAmount { get; set; }
        [XmlElement("TaxInclusiveAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public TaxInclusiveAmount TaxInclusiveAmount { get; set; }
        [XmlElement("AllowanceTotalAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public AllowanceTotalAmount AllowanceTotalAmount { get; set; }
        [XmlElement("PrepaidAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PrepaidAmount PrepaidAmount { get; set; }
        [XmlElement("PayableAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public PayableAmount PayableAmount { get; set; }
    }
    [XmlType("LineExtensionAmount")]
    public class LineExtensionAmount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("TaxExclusiveAmount")]
    public class TaxExclusiveAmount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("TaxInclusiveAmount")]
    public class TaxInclusiveAmount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("AllowanceTotalAmount")]
    public class AllowanceTotalAmount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("PrepaidAmount")]
    public class PrepaidAmount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("PayableAmount")]
    public class PayableAmount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("AllowanceCharge")]
    public class AllowanceCharge
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string ChargeIndicator { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string AllowanceChargeReason { get; set; } = null;
        [XmlElement("Amount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public Amount Amount { get; set; }
        [XmlElement("TaxCategory" )]
        public List<TaxCategory> TaxCategory { get; set; } = null;//new List<TaxCategory>();
    }
    [XmlType("Amount")]
    public class Amount
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string currencyID { get; set; } = null;
        public bool ShouldSerializecurrencyID() => !string.IsNullOrEmpty(currencyID);
    }
    [XmlType("TaxCategory")]
    public class TaxCategory
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string Percent { get; set; } = null;
        [XmlElement("TaxScheme")]
        public TaxScheme TaxScheme { get; set; }
    }
    [XmlType("PaymentMeans")]
    public class PaymentMeans
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string Repeat { get; set; } = null;
        public bool ShouldSerializeRepeat() => !string.IsNullOrEmpty(Repeat);
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PaymentMeansCode { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string InstructionNote { get; set; } = null;
    }
    [XmlType("AccountingSupplierParty")]
    public class AccountingSupplierParty
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("Party", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Party Party { get; set; }
    }
    [XmlType("AccountingCustomerParty")]
    public class AccountingCustomerParty
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("Party", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Party Party { get; set; }
    }
    [XmlType("Party")]
    public class Party
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("PartyIdentification", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyIdentification PartyIdentification { get; set; }
        [XmlElement("PostalAddress", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PostalAddress PostalAddress { get; set; }
        [XmlElement("PartyTaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyTaxScheme PartyTaxScheme { get; set; }
        [XmlElement("PartyLegalEntity", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public PartyLegalEntity PartyLegalEntity { get; set; }
    }
    [XmlType("PartyIdentification")]
    public class PartyIdentification
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
    }
    [XmlType("PostalAddress")]
    public class PostalAddress
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string StreetName { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string BuildingNumber { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CitySubdivisionName { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CityName { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string PostalZone { get; set; } = null;
        [XmlElement("Country", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Country Country { get; set; }
    }
    [XmlType("Country")]
    public class Country
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string IdentificationCode { get; set; } = null;
    }
    [XmlType("PartyTaxScheme")]
    public class PartyTaxScheme
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string CompanyID { get; set; } = null;
        [XmlElement("TaxScheme", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public TaxScheme TaxScheme { get; set; }
    }
    [XmlType("TaxScheme")]
    public class TaxScheme
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
    }
    [XmlType("PartyLegalEntity")]
    public class PartyLegalEntity
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string RegistrationName { get; set; } = null;
    }
    [XmlType("Signature")]
    public class SignatureCAC
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string SignatureMethod { get; set; } = null;
    }
    [XmlType("InvoiceTypeCode")]
    public class InvoiceTypeCode
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string name { get; set; } = null;
        public bool ShouldSerializename() => !string.IsNullOrEmpty(name);
    }
    [XmlType("Note")]
    public class Note
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string languageID { get; set; } = null;
        public bool ShouldSerializelanguageID() => !string.IsNullOrEmpty(languageID);
    }
    [XmlType("AdditionalDocumentReference")]
    public class AdditionalDocumentReference
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public string UUID { get; set; } = null;
        [XmlElement("Attachment", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        public Attachment Attachment { get; set; }
    }
    [XmlType("Attachment")]
    public class Attachment
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("EmbeddedDocumentBinaryObject", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public EmbeddedDocumentBinaryObject EmbeddedDocumentBinaryObject { get; set; }
    }
    [XmlType("EmbeddedDocumentBinaryObject")]
    public class EmbeddedDocumentBinaryObject
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string mimeCode { get; set; } = null;
        public bool ShouldSerializemimeCode() => !string.IsNullOrEmpty(mimeCode);
    }
    [XmlType("UBLExtension", Namespace = "ext")]
    public class UBLExtension
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        public string ExtensionURI { get; set; } = null;
        [XmlElement("ExtensionContent", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
        public ExtensionContent ExtensionContent { get; set; }
    }
    [XmlType("ExtensionContent", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    public class ExtensionContent
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlArray(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonSignatureComponents-2")]
        [XmlArrayItem(typeof(SignatureInformation), Namespace = "urn:oasis:names:specification:ubl:schema:xsd:SignatureAggregateComponents-2")]
        public List<object> UBLDocumentSignatures { get; set; } = null;//new List<object>();
    }
    [XmlType("SignatureInformation", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:SignatureAggregateComponents-2")]
    public class SignatureInformation
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public ID ID { get; set; }
        [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:SignatureBasicComponents-2")]
        public string ReferencedSignatureID { get; set; } = null;
        [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }
    }
    [XmlType("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class Signature
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string Id { get; set; } = null;
        public bool ShouldSerializeId() => !string.IsNullOrEmpty(Id);
        [XmlArray(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        [XmlArrayItem(typeof(CanonicalizationMethod))][XmlArrayItem(typeof(SignatureMethod))][XmlArrayItem(typeof(Reference))]
        public List<object> SignedInfo { get; set; } = null;//new List<object>();
        [XmlElement()]
        public string SignatureValue { get; set; } = null;
        [XmlElement("KeyInfo")]
        public KeyInfo KeyInfo { get; set; }
        [XmlElement("Object")]
        public ObjectItem ObjectItem { get; set; }
    }
    [XmlType("CanonicalizationMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class CanonicalizationMethod
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string Algorithm { get; set; } = null;
        public bool ShouldSerializeAlgorithm() => !string.IsNullOrEmpty(Algorithm);
    }
    [XmlType("SignatureMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class SignatureMethod
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string Algorithm { get; set; } = null;
        public bool ShouldSerializeAlgorithm() => !string.IsNullOrEmpty(Algorithm);
    }
    [XmlType("Reference", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class Reference
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string Id { get; set; } = null;
        public bool ShouldSerializeId() => !string.IsNullOrEmpty(Id);
        [XmlAttribute]
        public string URI { get; set; } = null;
        public bool ShouldSerializeURI() => !string.IsNullOrEmpty(URI);
        [XmlAttribute]
        public string Type { get; set; } = null;
        public bool ShouldSerializeType() => !string.IsNullOrEmpty(Type);
        [XmlArray(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        [XmlArrayItem(typeof(Transform))]
        public List<object> Transforms { get; set; } = null;//new List<object>();
        [XmlElement("DigestMethod")]
        public DigestMethod DigestMethod { get; set; }
        [XmlElement()]
        public string DigestValue { get; set; } = null;
    }
    [XmlType("Transform", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class Transform
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string Algorithm { get; set; } = null;
        public bool ShouldSerializeAlgorithm() => !string.IsNullOrEmpty(Algorithm);
        [XmlElement("XPath", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public XPath XPath { get; set; }
    }
    [XmlType("XPath", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class XPath
    {
        [XmlText]
        public string Text { get; set; } = null;
    }
    [XmlType("DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class DigestMethod
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string Algorithm { get; set; } = null;
        public bool ShouldSerializeAlgorithm() => !string.IsNullOrEmpty(Algorithm);
    }
    [XmlType("KeyInfo", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class KeyInfo
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("X509Data")]
        public X509Data X509Data { get; set; }
    }
    [XmlType("X509Data", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class X509Data
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("X509Certificate")]
        public X509Certificate X509Certificate { get; set; }
    }
    [XmlType("X509Certificate", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class X509Certificate
    {
        [XmlText]
        public string Text { get; set; } = null;
    }
    [XmlType("Object")]
    public class ObjectItem
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("QualifyingProperties", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
        public QualifyingProperties QualifyingProperties { get; set; }
    }
    [XmlType("QualifyingProperties", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class QualifyingProperties
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string Target { get; set; } = null;
        public bool ShouldSerializeTarget() => !string.IsNullOrEmpty(Target);
        [XmlElement("SignedProperties")]
        public SignedProperties SignedProperties { get; set; }
    }
    [XmlType("SignedProperties")]
    public class SignedProperties
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlAttribute]
        public string Id { get; set; } = null;
        public bool ShouldSerializeId() => !string.IsNullOrEmpty(Id);
        [XmlArray()]
        [XmlArrayItem(typeof(SigningTime))][XmlArrayItem(typeof(SigningCertificate))]
        public List<object> SignedSignatureProperties { get; set; } = null;//new List<object>();
    }
    [XmlType("SigningTime")]
    public class SigningTime
    {
        [XmlText]
        public string Text { get; set; } = null;
    }
    [XmlType("SigningCertificate")]
    public class SigningCertificate
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("Cert")]
        public Cert Cert { get; set; }
    }
    [XmlType("Cert")]
    public class Cert
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("CertDigest")]
        public CertDigest CertDigest { get; set; }
        [XmlElement("IssuerSerial")]
        public IssuerSerial IssuerSerial { get; set; }
    }
    [XmlType("CertDigest")]
    public class CertDigest
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("DigestMethod", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public DigestMethod DigestMethod { get; set; }
        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public string DigestValue { get; set; } = null;
    }
    [XmlType("IssuerSerial", Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public class IssuerSerial
    {
        [XmlText]
        public string Text { get; set; } = null;
        [XmlElement("X509IssuerName", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public X509IssuerName X509IssuerName { get; set; }
        [XmlElement("X509SerialNumber", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public X509SerialNumber X509SerialNumber { get; set; }
    }
    [XmlType("X509IssuerName", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class X509IssuerName
    {
        [XmlText]
        public string Text { get; set; } = null;
    }
    [XmlType("X509SerialNumber", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class X509SerialNumber
    {
        [XmlText]
        public string Text { get; set; } = null;
    }
}
