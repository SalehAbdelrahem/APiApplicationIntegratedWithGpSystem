using System;
using IntegratorWithGp.Core.Models.ReceivingTransactions;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.SalesTransactions
{
    public class SOPHeader
    {
        public short SOPTYPE { get; set; }
        public string DOCID  { get; set; }
        public string SOPNUMBE { get; set; }
        public string DOCDATE { get; set; }
        public string CUSTNMBR { get; set; }
        public string CUSTNAME { get; set; }
        public string BACHNUMB { get; set; }
        public string CURNCYID { get; set; }
        public static implicit operator taSopHdrIvcInsert(SOPHeader sOPHeader)
        {
            return new taSopHdrIvcInsert
            {
                SOPTYPE = sOPHeader.SOPTYPE,
                DOCID = sOPHeader.DOCID,
                SOPNUMBE = sOPHeader.SOPNUMBE,
                DOCDATE = sOPHeader.DOCDATE,
                CUSTNMBR = sOPHeader.CUSTNMBR,
                CUSTNAME = sOPHeader.CUSTNAME,
                BACHNUMB = sOPHeader.BACHNUMB??$"IST-{DateTime.Now.Date.ToString("dd/MM/yyyy")}",
                CURNCYID = sOPHeader.CURNCYID,
                CREATETAXES=1,
                DEFPRICING = 1
            };
        }
    }
}
