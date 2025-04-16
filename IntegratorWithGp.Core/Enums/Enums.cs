namespace IntegratorWithGp.Core.Enums
{
    public enum DOCTYPE
    {
        Sales_Transaction,
        PO_Receiving_Transaction,
        Customer,
        Vendor,
        Item,
        Employee,
        RM_SalesPerson,
        Cash_Receipt

    }
    public enum SOPTYPE
    {
        Quote = 1,
        Order,
        Invoice,
        Return,
        BackOrder,
        FulfillmentOrder
    }
    public enum POPTYPE
    {
        Shipment = 1,

        Shipment_invoice = 3

    }

    public enum ItemTaxOptions
    {
        Taxable = 1,
        Nontaxable,
        BasedOnVendor
    }
}
