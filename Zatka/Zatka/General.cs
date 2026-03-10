using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[XmlRoot("Invoice", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")]
public class UblInvoice
{
    [XmlElement("ID")]
    public string ID { get; set; }

    [XmlElement("UUID")]
    public string UUID { get; set; }

    [XmlElement("IssueDate")]
    public string IssueDate { get; set; }

    [XmlElement("IssueTime")]
    public string IssueTime { get; set; }

    [XmlElement("InvoiceTypeCode")]
    public InvoiceTypeCode InvoiceTypeCode { get; set; }

    [XmlElement("DocumentCurrencyCode")]
    public string CurrencyCode { get; set; }

    [XmlElement("AccountingSupplierParty")]
    public SupplierParty Supplier { get; set; }

    [XmlElement("AccountingCustomerParty")]
    public CustomerParty Customer { get; set; }

    [XmlElement("TaxTotal")]
    public TaxTotal TaxTotal { get; set; }

    [XmlElement("LegalMonetaryTotal")]
    public MonetaryTotal MonetaryTotal { get; set; }

    [XmlElement("InvoiceLine")]
    public List<InvoiceLine> Lines { get; set; }
}


public class InvoiceTypeCode
{
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlText]
    public string Value { get; set; }
}

public class SupplierParty
{
    [XmlElement("Party")]
    public Party Party { get; set; }
}

public class CustomerParty
{
    [XmlElement("Party")]
    public Party Party { get; set; }
}

public class Party
{
    [XmlElement("PartyIdentification")]
    public PartyIdentification Identification { get; set; }

    [XmlElement("PartyName")]
    public PartyName Name { get; set; }

    [XmlElement("PostalAddress")]
    public Address Address { get; set; }

    [XmlElement("PartyTaxScheme")]
    public PartyTaxScheme TaxScheme { get; set; }
}

public class PartyIdentification
{
    [XmlElement("ID")]
    public string ID { get; set; }
}

public class PartyName
{
    [XmlElement("Name")]
    public string Name { get; set; }
}

public class Address
{
    [XmlElement("StreetName")]
    public string StreetName { get; set; }

    [XmlElement("BuildingNumber")]
    public string BuildingNumber { get; set; }

    [XmlElement("CityName")]
    public string CityName { get; set; }

    [XmlElement("PostalZone")]
    public string PostalCode { get; set; }

    [XmlElement("Country")]
    public Country Country { get; set; }
}

public class Country
{
    [XmlElement("IdentificationCode")]
    public string Code { get; set; }
}

public class PartyTaxScheme
{
    [XmlElement("CompanyID")]
    public string VatNumber { get; set; }

    [XmlElement("TaxScheme")]
    public TaxScheme TaxScheme { get; set; }
}

public class TaxScheme
{
    [XmlElement("ID")]
    public string ID { get; set; }
}

public class InvoiceLine
{
    [XmlElement("ID")]
    public int ID { get; set; }

    [XmlElement("InvoicedQuantity")]
    public decimal Quantity { get; set; }

    [XmlElement("LineExtensionAmount")]
    public Amount LineAmount { get; set; }

    [XmlElement("Item")]
    public Item Item { get; set; }

    [XmlElement("Price")]
    public Price Price { get; set; }
}

public class Item
{
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("ClassifiedTaxCategory")]
    public TaxCategory TaxCategory { get; set; }
}

public class TaxCategory
{
    [XmlElement("ID")]
    public string ID { get; set; }

    [XmlElement("Percent")]
    public decimal Percent { get; set; }

    [XmlElement("TaxScheme")]
    public TaxScheme TaxScheme { get; set; }
}

public class Price
{
    [XmlElement("PriceAmount")]
    public Amount PriceAmount { get; set; }
}



public class Amount
{
    [XmlAttribute("currencyID")]
    public string CurrencyID { get; set; }

    [XmlText]
    public decimal Value { get; set; }
}

public class TaxTotal
{
    [XmlElement("TaxAmount")]
    public Amount TaxAmount { get; set; }
}

public class MonetaryTotal
{
    [XmlElement("LineExtensionAmount")]
    public Amount LineExtensionAmount { get; set; }

    [XmlElement("TaxExclusiveAmount")]
    public Amount TaxExclusiveAmount { get; set; }

    [XmlElement("TaxInclusiveAmount")]
    public Amount TaxInclusiveAmount { get; set; }

    [XmlElement("PayableAmount")]
    public Amount PayableAmount { get; set; }
}

public static class UblSerializer
{
    public static string Serialize(UblInvoice invoice)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(UblInvoice));

        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");

        using (StringWriter sw = new StringWriter())
        {
            serializer.Serialize(sw, invoice, ns);
            return sw.ToString();
        }
    }
}