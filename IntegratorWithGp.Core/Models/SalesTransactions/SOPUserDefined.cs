using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.SalesTransactions
{
    public class SOPUserDefined
    {
        public short SOPTYPE { get; set; }
        public string SOPNUMBE { get; set; }
        public string USERDEF1 { get; set; }
        public string USERDEF2 { get; set; }
        public string USRDEF03 { get; set; }
        public string USRDEF04 { get; set; }
        public string USRDEF05 { get; set; }

        public static implicit operator taSopUserDefined(SOPUserDefined sOPUserDefined) => new taSopUserDefined
        {
            SOPTYPE = sOPUserDefined.SOPTYPE,
            SOPNUMBE = sOPUserDefined.SOPNUMBE,
            USERDEF1 = sOPUserDefined.USERDEF1,
            USERDEF2 = sOPUserDefined.USERDEF2,
            USRDEF03 = sOPUserDefined.USRDEF03,
            USRDEF04 = sOPUserDefined.USRDEF04,
            USRDEF05 = sOPUserDefined.USRDEF05
        };
    }
}
