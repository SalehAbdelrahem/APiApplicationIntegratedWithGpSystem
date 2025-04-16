using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.SalesTransactions
{
    public class DeleteSOPLine
    {
        public short SOPTYPE { get; set; }
        public string SOPNUMBE { get; set; }
        public string ITEMNMBR { get; set; }
        // [JsonProperty("DeleteType")]
        public short DeleteType { get; set; }
        public short UpdateIfExists { get; set; }
        public static implicit operator taSopLineDelete(DeleteSOPLine sOPLine)
        {
            return new taSopLineDelete
            {
                SOPTYPE = sOPLine.SOPTYPE,
                SOPNUMBE = sOPLine.SOPNUMBE,
                ITEMNMBR = sOPLine.ITEMNMBR,
                DeleteType = sOPLine.DeleteType
            };
        }

    }
}
