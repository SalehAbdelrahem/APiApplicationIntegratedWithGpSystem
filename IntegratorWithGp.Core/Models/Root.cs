using System.Xml.Serialization;

namespace IntegratorWithGp.Core.Models
{
    [XmlRoot("root")]
    public class Root
    {
        [XmlElement("eConnect")]
        public EConnect EConnect { get; set; }
    }

    public class EConnect
    {
        [XmlAttribute("ACTION")]
        public int Action { get; set; }

        [XmlAttribute("Requester_DOCTYPE")]
        public string RequesterDocType { get; set; }
        [XmlAttribute("DBNAME")]
        public string DBNAME { get; set; }

        [XmlAttribute("TABLENAME")]
        public string TABLENAME { get; set; }

        // Add other attributes as needed

        [XmlElement("SO_Trans")]
        public SOTrans SOTrans { get; set; }
    }

    public class SOTrans
    {
        [XmlElement("SOPNUMBE")]
        public string SOPNUMBE { get; set; }

        [XmlElement("DOCID")]
        public string DOCID { get; set; }

        [XmlElement("CUSTNMBR")]
        public string CUSTNMBR { get; set; }

        [XmlElement("BACHNUMB")]
        public string BACHNUMB { get; set; }

        [XmlElement("DOCDATE")]
        public string DOCDATE { get; set; }

        [XmlElement("SOPTYPE")]
        public short SOPTYPE { get; set; }

        [XmlElement("CURNCYID")]
        public string CURNCYID { get; set; }

        // Add other elements as needed
        [XmlElement("Line")]
        public Line[] Lines { get; set; }
        // public taSopLineIvcInsert_ItemsTaSopLineIvcInsert[] Lines { get; set; }
    }

    public class Line
    {

        [XmlElement("SOPNUMBE")]
        public string SOPNUMBE { get; set; }

        [XmlElement("ITEMNMBR")]
        public string ITEMNMBR { get; set; }

        [XmlElement("SOPTYPE")]
        public short SOPTYPE { get; set; }

        [XmlElement("ITEMDESC")]
        public string ITEMDESC { get; set; }

        [XmlElement("QUANTITY")]
        public decimal QUANTITY { get; set; }


        [XmlElement("QTYFULFI")]
        public decimal QTYFULFI { get; set; }
        [XmlElement("QTYTOINV")]
        public decimal QTYTOINV { get; set; }

        [XmlElement("LNITMSEQ")]
        public int LNITMSEQ { get; set; }

        [XmlElement("SHIPMTHD")]
        public string SHIPMTHD { get; set; }

        [XmlElement("QTYTBAOR")]
        public decimal QTYTBAOR { get; set; }
        [XmlElement("QTYONHND")]
        public decimal QTYONHND { get; set; }


        [XmlElement("LOCNCODE")]
        public string LOCNCODE { get; set; }

        // Add other elements as needed

        //[XmlElement("DOCDATE")]
        //public string DOCDATE { get; set; }

    }

}
