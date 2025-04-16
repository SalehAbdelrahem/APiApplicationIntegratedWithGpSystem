using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Core.Models.ReceivingTransactions
{
    public class POPUserDefined
    {
        public string POPRCTNM { get; set; }
        public string User_Defined_Text01 { get; set; }
        public string User_Defined_Text02 { get; set; }
        public string User_Defined_Text03 { get; set; }
        public static implicit operator taPopRctUserDefined(POPUserDefined pOPUserDefined) => new taPopRctUserDefined
        {
            POPRCTNM = pOPUserDefined.POPRCTNM,
            User_Defined_Text01 = pOPUserDefined.User_Defined_Text01,
            User_Defined_Text02 = pOPUserDefined.User_Defined_Text02,
            User_Defined_Text03 = pOPUserDefined.User_Defined_Text03
        };

    }
}
