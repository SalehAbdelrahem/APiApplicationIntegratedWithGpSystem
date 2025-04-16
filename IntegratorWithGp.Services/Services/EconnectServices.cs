using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using IntegratorWithGp.Core;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace IntegratorWithGp.Services.services
{
    public class EconnectServices
    {
        public async Task<DataTable> OpenConnectionGp(string sql)
        {
            
            if (!string.IsNullOrEmpty(sql))
            {
                var dataTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(ConstantVariables.connectionStringGPWithOUTIntegrated))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader dataReader = await command.ExecuteReaderAsync();
                        dataTable.Load(dataReader);
                        dataReader.Close();
                        connection.Close();
                    }

                }

                return dataTable;
            }

            return null;
        }

        //public async Task<(bool isSuccess, string message)> CreateLine(CreateLineDto createLineDto)
        //{
        //    // List<GpSerialsDTO> TempOldSerials = new List<GpSerialsDTO>();
        //    var count = 0;
        //    // Transformation
        //    var transformedResult = new MappedCreateLineDto
        //    {
        //        SOPNumber = createLineDto.SOPNumber,
        //        Serials = createLineDto.Serials.SelectMany(p => p.SerialWithLocation
        //                     .GroupBy(s => s.LOCNCODE, (loc, serials) => new MappedPartNumbersWithSerials
        //                     {
        //                         PartNumber = p.PartNumber,
        //                         LOCNCODE = loc,
        //                         SerialNumbers = serials.Select(s => s.Serial).ToList()
        //                     })).ToList()
        //    };

        //    foreach (var item in transformedResult.Serials)
        //    {
        //        try
        //        {
        //            using (eConnectMethods eConnect = new eConnectMethods())
        //            {
        //                int Quantity = item.SerialNumbers.Count;
        //                var root = GetEntityMappedToRootDTO(createLineDto.SOPNumber);
        //                var line = root.EConnect.SOTrans.Lines.FirstOrDefault(l => string.Equals(l.ITEMNMBR, item.PartNumber, StringComparison.OrdinalIgnoreCase) && string.Equals(l.LOCNCODE, item.LOCNCODE, StringComparison.OrdinalIgnoreCase));
        //                taSopLineIvcInsert_ItemsTaSopLineIvcInsert sopLine = new taSopLineIvcInsert_ItemsTaSopLineIvcInsert();
        //                taSopHdrIvcInsert sopHdrIvc = new taSopHdrIvcInsert();

        //                if (line != null)
        //                {
        //                    sopLine.SOPTYPE = line.SOPTYPE;
        //                    sopLine.SOPNUMBE = line.SOPNUMBE;
        //                    //  sopLine.TOTALQTY = line.QUANTITY + Quantity;
        //                    sopLine.QUANTITY = line.QTYTOINV + Quantity;
        //                    sopLine.ITEMNMBR = line.ITEMNMBR;
        //                    sopLine.LOCNCODE = line.LOCNCODE;
        //                    // sopLine.QTYFULFI = line.QTYFULFI;
        //                    sopLine.QTYTBAOR = line.QTYTBAOR;
        //                    sopLine.LNITMSEQ = line.LNITMSEQ;
        //                    sopLine.QTYONHND = line.QTYONHND;
        //                    //  sopLine.ALLOCATE = 1;
        //                    //  sopLine.QTYFULFISpecified = true; // must be ture to choose a specific serial
        //                }
        //                else
        //                {
        //                    sopLine.SOPTYPE = 2; // Example: Sales Order Processing type // sopLine.ITEMNMBR = SerialNumber; // Item number for the new line
        //                    sopLine.SOPNUMBE = createLineDto.SOPNumber; // SOP number
        //                                                                //sopLine.QUANTITY = sopLine.QTYFULFI = Quantity; // New quantity
        //                    sopLine.QUANTITY = Quantity;        //  New quantity
        //                                                        //sopLine.QTYFULFI = Quantity;        
        //                    sopLine.LOCNCODE = item.LOCNCODE;    //Example location code (Site Id), you can modify as needed
        //                                                         //sopLine.UpdateIfExists = 0; 
        //                                                         //sopLine.UpdateIfExists = 1; // 1 update
        //                                                         //  sopLine.QTYFULFISpecified = true;    //must be ture to choose a specific serial

        //                }

        //                //comman sopLine set Properities
        //                sopLine.QTYFULFISpecified = true; //must be ture to choose a specific serial
        //                sopLine.UpdateIfExists = 1; //flag 1 means ==>  if line exists update else insert line

        //                sopLine.CURNCYID = root.EConnect.SOTrans.CURNCYID;
        //                sopLine.CUSTNMBR = root.EConnect.SOTrans.CUSTNMBR;
        //                sopLine.ITEMNMBR = item.PartNumber;

        //                // sopLine.DOCDATE = root.EConnect.SOTrans.DOCDATE;
        //                sopLine.DOCDATE = DateTime.Now.ToString("MM/dd/yyyy");
        //                // sopLine.ReqShipDate = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");

        //                // sopHdrIvc
        //                sopHdrIvc.SOPNUMBE = root.EConnect.SOTrans.SOPNUMBE;
        //                sopHdrIvc.SOPTYPE = root.EConnect.SOTrans.SOPTYPE;
        //                sopHdrIvc.DOCID = root.EConnect.SOTrans.DOCID;
        //                sopHdrIvc.DOCDATE = root.EConnect.SOTrans.DOCDATE;
        //                sopHdrIvc.CUSTNMBR = root.EConnect.SOTrans.CUSTNMBR;
        //                sopHdrIvc.BACHNUMB = root.EConnect.SOTrans.BACHNUMB;
        //                sopHdrIvc.CURNCYID = root.EConnect.SOTrans.CURNCYID;
        //                sopHdrIvc.UpdateExisting = 1;
        //                taSopLineIvcInsert_ItemsTaSopLineIvcInsert[] sopLines = new taSopLineIvcInsert_ItemsTaSopLineIvcInsert[] { sopLine };
        //                eConnectType updateSOPTransactionType = new eConnectType();
        //                taAnalyticsDistribution_ItemsTaAnalyticsDistribution aaDistribution = new taAnalyticsDistribution_ItemsTaAnalyticsDistribution
        //                {
        //                    DOCNMBR = root.EConnect.SOTrans.SOPNUMBE, // Distribution Index
        //                    DOCTYPE = root.EConnect.SOTrans.SOPTYPE, // Distribution Index
        //                                                             //                            UpdateIfExists = 1 // Prevents duplicate key errors
        //                };

        //                updateSOPTransactionType.SOPTransactionType = new SOPTransactionType[]
        //                {
        //                new SOPTransactionType()
        //                {
        //                   taSopHdrIvcInsert = sopHdrIvc,
        //                   taSopLineIvcInsert_Items = sopLines,
        //                   taSopUserDefined=new taSopUserDefined
        //                   {
        //                       SOPNUMBE=root.EConnect.SOTrans.SOPNUMBE,
        //                       SOPTYPE= root.EConnect.SOTrans.SOPTYPE,
        //                   }
        //                   //taAnalyticsDistribution_Items=new taAnalyticsDistribution_ItemsTaAnalyticsDistribution[]
        //                   //{
        //                   //    aaDistribution
        //                   //}
        //                }
        //                };

        //                var updatedXmlString = GeneralOperationObject.SerializeObject(updateSOPTransactionType);
        //                // var updatedXmlString = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<eConnect xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n    <SOPTransactionType>\r\n        <eConnectProcessInfo xsi:nil=\"true\" />\r\n        <taRequesterTrxDisabler_Items xsi:nil=\"true\" />\r\n        <taUpdateCreateItemRcd xsi:nil=\"true\" />\r\n        <taUpdateCreateCustomerRcd xsi:nil=\"true\" />\r\n        <taCreateCustomerAddress_Items xsi:nil=\"true\" />\r\n        <taSopSerial_Items xsi:nil=\"true\" />\r\n        <taSopLotAuto_Items xsi:nil=\"true\" />\r\n        <taSopLineIvcInsert_Items>\r\n            <taSopLineIvcInsert>\r\n                <SOPTYPE>2</SOPTYPE>\r\n                <SOPNUMBE>TSU/CO2400017</SOPNUMBE>\r\n                <CUSTNMBR>C00003</CUSTNMBR>\r\n                <DOCDATE>11/27/2024</DOCDATE>\r\n                <LOCNCODE>SPARE PART</LOCNCODE>\r\n                <ITEMNMBR>0957-2483</ITEMNMBR>\r\n                <QUANTITY>1</QUANTITY>\r\n                <UpdateIfExists>1</UpdateIfExists>\r\n                <CURNCYID>EGP</CURNCYID>\r\n            </taSopLineIvcInsert>\r\n        </taSopLineIvcInsert_Items>\r\n        <taSopLineIvcInsertComponent_Items xsi:nil=\"true\" />\r\n        <taSopTrackingNum_Items xsi:nil=\"true\" />\r\n        <taSopCommissions_Items xsi:nil=\"true\" />\r\n        <taSopLineIvcTaxInsert_Items xsi:nil=\"true\" />\r\n        <taCreateSopPaymentInsertRecord_Items xsi:nil=\"true\" />\r\n        <taSopUserDefined xsi:nil=\"true\" />\r\n        <taSopMultiBin_Items xsi:nil=\"true\" />\r\n        <taSopHdrIvcInsert>\r\n            <SOPTYPE>2</SOPTYPE>\r\n            <DOCID>TEC-CO</DOCID>\r\n            <SOPNUMBE>TSU/CO2400017</SOPNUMBE>\r\n            <DOCDATE>2024-11-27T00:00:00</DOCDATE>\r\n            <CUSTNMBR>C00003</CUSTNMBR>\r\n            <BACHNUMB>TAMER</BACHNUMB>\r\n            <CURNCYID>EGP</CURNCYID>\r\n            <UpdateExisting>1</UpdateExisting>\r\n        </taSopHdrIvcInsert>\r\n        <taSopToPopLink xsi:nil=\"true\" />\r\n        <taSopUpdateCreateProcessHold xsi:nil=\"true\" />\r\n        <taCreateSOPTrackingInfo xsi:nil=\"true\" />\r\n        <taMdaUpdate_Items xsi:nil=\"true\" />\r\n    </SOPTransactionType>\r\n</eConnect>";
        //                string serialsString = string.Join(", ", item.SerialNumbers.Select(s => $"'{s}'"));
        //                var query = $"SELECT SERLNMBR AS SerialNum, ITEMNMBR,LOCNCODE FROM IV00200  WHERE  ITEMNMBR = '{item.PartNumber}' and SERLNMBR in ({serialsString}) and  SERLNSLD=0"; //o is avilabe , 2 is allocate

        //                var data = await OpenConnectionGp(query);
        //                if (data != null)
        //                {
        //                    var seraialAvilable = (from DataRow dr in data.Rows
        //                                           select dr["SerialNum"].ToString()?.Trim()
        //                                          ).ToList();
        //                    bool isSerialAvilable = seraialAvilable.Count == Quantity;

        //                    if (isSerialAvilable)
        //                    {
        //                        var serialsOnItemNumber = GetSerialsFullFilledBasedOnItemNumber(createLineDto.SOPNumber, item.PartNumber).Where(s => string.Equals(s.LOCNCODE, item.LOCNCODE, StringComparison.OrdinalIgnoreCase)).ToList();
        //                        // TempOldSerials.AddRange(serialsOnItemNumber);
        //                        var tempSerialsOnItemNumber = serialsOnItemNumber.Select(x => x.SERLTNUM);
        //                        var diffSerials = item.SerialNumbers.Except(tempSerialsOnItemNumber);
        //                        bool isNewSerials = diffSerials.Count() == Quantity;

        //                        if (((serialsOnItemNumber.Any() && line != null) || (!serialsOnItemNumber.Any() && line == null)) && isNewSerials)
        //                        {
        //                            eConnect.UpdateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, updatedXmlString);
        //                            // eConnect.UpdateEntity(ConstantVariables.connectionStringGPWithIntegrated, updatedXmlString);
        //                        }
        //                        //var updatedResponse = eConnect.CreateTransactionEntity(connectionStringGP, updatedXmlString);
        //                        //Call the GetEntity method to retrieve data

        //                        var root2 = GetEntityMappedToRootDTO(createLineDto.SOPNumber);
        //                        var line2 = root2.EConnect.SOTrans.Lines.FirstOrDefault(l => string.Equals(l.ITEMNMBR, item.PartNumber, StringComparison.OrdinalIgnoreCase) && string.Equals(l.LOCNCODE, item.LOCNCODE, StringComparison.OrdinalIgnoreCase));

        //                        if (line2 != null && isNewSerials)
        //                        {
        //                            foreach (var serial1 in item.SerialNumbers)
        //                            {
        //                                serialsOnItemNumber.Add(new GpSerialsDTO
        //                                {
        //                                    ITEMNMBR = line2.ITEMNMBR,
        //                                    SOPTYPE = line2.SOPTYPE,
        //                                    LNITMSEQ = line2.LNITMSEQ,
        //                                    LOCNCODE = line2.LOCNCODE,
        //                                    SERLTNUM = serial1,
        //                                    SOPNUMBE = line2.SOPNUMBE,
        //                                });
        //                            }
        //                        }
        //                        var isAllocated = FullFilledSerial(serialsOnItemNumber, ConstantVariables.connectionStringGPWithIntegrated);
        //                        if (isAllocated) count++;
        //                    }
        //                }

        //            }
        //        }
        //        catch (eConnectException ex)
        //        {
        //            RolBackSerial(transformedResult);
        //            if (ex.Message.Contains("Error Number = 9539"))
        //                return (false, $"Error Description = The Salesperson is set to inactive in the Salesperson Master Table - RM00301 , Item Number {item.PartNumber}");
        //            else if (ex.Message.Contains("Error Number = 2079") || ex.Message.Contains("Error Number = 2022"))
        //                return (false, $"Error Description = Document is currently being edited by another user , Item Number {item.PartNumber}");

        //            else if (ex.Message.Contains("Error Number = 9370"))
        //                return (false, $"Error Description = You are passing a Currency ID in the header and you did not pass the same one to the line , Item Number {item.PartNumber}");

        //            else if (ex.Message.Contains("Error Number = 3551"))
        //                return (false, $"Error Description =  Serial Number does not exist in Item Serial Number Master -IV00200 , Item Number {item.PartNumber}");

        //            else if (ex.Message.Contains("Error Number = 2902"))
        //                return (false, $"Error Description =  Error Description = Item Number(ITEMNMBR) does not match Item Number on the existing line , Item Number {item.PartNumber}");

        //            else if (ex.Message.Contains("Error Number = 1526"))
        //                return (false, $"Error Description = The Serial Number has already been sold -please choose another Serial Number , Item Number {item.PartNumber}");

        //            else if (ex.Message.Contains("Error Number = 2905"))
        //                return (false, $"Error Description = Qty fulfilled can not exceed qty allocated Node Identifier Parameters: taSopSerial , Item Number {item.PartNumber}");

        //            else
        //                return (false, ex.Message);
        //            break;
        //        }
        //        catch (Exception ex)
        //        {
        //            RolBackSerial(transformedResult);

        //            return (false, $"Error:  {ex.Message}");
        //            break;
        //        }
        //    }
        //    if (count == transformedResult.Serials.Count)
        //    {
        //        return (true, "All Operation Successfully");
        //    }
        //    else
        //    {
        //        var isRoledBack = RolBackSerial(transformedResult);
        //        return (false, $"Ann Error Occured , Please call Software Team to support you isRoledBack={isRoledBack}");

        //    }

        //}

        //private bool FullFilledSerial(IEnumerable<GpSerialsDTO> serials, string connectionString)
        //{
        //    using (eConnectMethods eConnect = new eConnectMethods())
        //    {
        //        List<taSopSerial_ItemsTaSopSerial> SopSerials = new List<taSopSerial_ItemsTaSopSerial>();
        //        foreach (var item in serials)
        //        {
        //            SopSerials.Add(new taSopSerial_ItemsTaSopSerial
        //            {
        //                SOPTYPE = item.SOPTYPE,                  // SOP Type (e.g., 2 = Sales Order)
        //                SOPNUMBE = item.SOPNUMBE,                // SOP Number
        //                ITEMNMBR = item.ITEMNMBR,                // Item Number
        //                SERLNMBR = item.SERLTNUM,                // Serial Number to allocate
        //                LOCNCODE = item.LOCNCODE,                // Location Code
        //                LNITMSEQ = item.LNITMSEQ,                // Line Item Sequence
        //                UpdateIfExists = 1,
        //            });
        //        }
        //        eConnectType eConnectType = new eConnectType
        //        {
        //            SOPTransactionType = new SOPTransactionType[]
        //            {
        //                new SOPTransactionType
        //                {
        //                    taSopSerial_Items = SopSerials.ToArray()
        //                }
        //            }
        //        };

        //        // Serialize the eConnectType to XML
        //        string serializedXml = GeneralOperationObject.SerializeObject(eConnectType);

        //        // Send the XML to eConnect to update the transaction
        //        bool result = eConnect.UpdateTransactionEntity(connectionString, serializedXml);

        //        return result;
        //    }
        //}
        //private bool RolBackSerial(MappedCreateLineDto serials)
        //{
        //    var data = GetEntityMappedToRootDTO(serials.SOPNumber);

        //    List<taSopLineIvcInsert_ItemsTaSopLineIvcInsert> sopLines = new List<taSopLineIvcInsert_ItemsTaSopLineIvcInsert>();
        //    taSopHdrIvcInsert sopHdrIvc = new taSopHdrIvcInsert();

        //    List<taSopSerial_ItemsTaSopSerial> SopSerials = new List<taSopSerial_ItemsTaSopSerial>();

        //    // sopHdrIvc
        //    sopHdrIvc.SOPNUMBE = data.EConnect.SOTrans.SOPNUMBE;
        //    sopHdrIvc.SOPTYPE = data.EConnect.SOTrans.SOPTYPE;
        //    sopHdrIvc.DOCID = data.EConnect.SOTrans.DOCID;
        //    sopHdrIvc.DOCDATE = data.EConnect.SOTrans.DOCDATE;
        //    sopHdrIvc.CUSTNMBR = data.EConnect.SOTrans.CUSTNMBR;
        //    sopHdrIvc.BACHNUMB = data.EConnect.SOTrans.BACHNUMB;
        //    sopHdrIvc.CURNCYID = data.EConnect.SOTrans.CURNCYID;
        //    sopHdrIvc.UpdateExisting = 1;



        //    using (eConnectMethods eConnect = new eConnectMethods())
        //    {
        //        foreach (var item in serials.Serials)
        //        {
        //            var line = data.EConnect.SOTrans.Lines.FirstOrDefault(x => string.Equals(x.ITEMNMBR, item.PartNumber, StringComparison.OrdinalIgnoreCase) && string.Equals(x.LOCNCODE, item.LOCNCODE, StringComparison.OrdinalIgnoreCase));
        //            if (line != null)
        //            {
        //                var quantity = item.SerialNumbers.Count();
        //                sopLines.Add(new taSopLineIvcInsert_ItemsTaSopLineIvcInsert
        //                {
        //                    SOPTYPE = line.SOPTYPE,
        //                    SOPNUMBE = line.SOPNUMBE,
        //                    QUANTITY = line.QTYTOINV == quantity ? 0 : line.QTYTOINV - quantity,
        //                    ITEMNMBR = line.ITEMNMBR,
        //                    LOCNCODE = line.LOCNCODE,
        //                    QTYTBAOR = line.QTYTBAOR,
        //                    LNITMSEQ = line.LNITMSEQ,
        //                    QTYONHND = line.QTYONHND,
        //                    QTYFULFISpecified = true, // must be ture to choose a specific serial
        //                    UpdateIfExists = 1,
        //                    CURNCYID = data.EConnect.SOTrans.CURNCYID,
        //                    CUSTNMBR = data.EConnect.SOTrans.CUSTNMBR,
        //                    // sopLine.DOCDATE = root.EConnect.SOTrans.DOCDATE;
        //                    DOCDATE = DateTime.Now.ToString("MM/dd/yyyy")
        //                });

        //                var sopSerials = GetSerialsFullFilledBasedOnItemNumber(serials.SOPNumber, item.PartNumber).Where(x => string.Equals(x.LOCNCODE, item.LOCNCODE, StringComparison.OrdinalIgnoreCase) && !item.SerialNumbers.Contains(x.SERLTNUM));
        //                foreach (var sopSerial in sopSerials)
        //                {
        //                    SopSerials.Add(new taSopSerial_ItemsTaSopSerial
        //                    {
        //                        SOPTYPE = sopSerial.SOPTYPE,                  // SOP Type (e.g., 2 = Sales Order)
        //                        SOPNUMBE = sopSerial.SOPNUMBE,                // SOP Number
        //                        ITEMNMBR = sopSerial.ITEMNMBR,                // Item Number
        //                        SERLNMBR = sopSerial.SERLTNUM,                // Serial Number to allocate
        //                        LOCNCODE = sopSerial.LOCNCODE,                // Location Code
        //                        LNITMSEQ = sopSerial.LNITMSEQ,                // Line Item Sequence
        //                        UpdateIfExists = 1,
        //                    });
        //                }

        //            }

        //        }
        //        eConnectType updateSOPTransactionType = new eConnectType();

        //        updateSOPTransactionType.SOPTransactionType = new SOPTransactionType[]
        //        {
        //                new SOPTransactionType()
        //                {
        //                   taSopHdrIvcInsert = sopHdrIvc,
        //                   taSopLineIvcInsert_Items = sopLines.ToArray()
        //                }
        //        };
        //        var updatedXmlString = GeneralOperationObject.SerializeObject(updateSOPTransactionType);
        //        eConnect.UpdateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, updatedXmlString);


        //        eConnectType eConnectType = new eConnectType
        //        {
        //            SOPTransactionType = new SOPTransactionType[]
        //            {
        //                new SOPTransactionType
        //                {
        //                    taSopSerial_Items = SopSerials.ToArray()
        //                }
        //            }
        //        };

        //        // Serialize the eConnectType to XML
        //        string serializedXml = GeneralOperationObject.SerializeObject(eConnectType);

        //        // Send the XML to eConnect to update the transaction

        //        bool isUpdated = eConnect.UpdateTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, serializedXml);
        //        bool isDeletedLines = sopLines.Any(x => x.QUANTITY == 0) ? DeleteLine(serials.SOPNumber) : true;
        //        return isUpdated && isDeletedLines;
        //    }
        //}
        //private bool DeleteLine(string SOPNumber)
        //{
        //    using (eConnectMethods eConnect = new eConnectMethods())
        //    {
        //        var root = GetEntityMappedToRootDTO(SOPNumber);
        //        var lines = root.EConnect.SOTrans.Lines.Where(l => !string.IsNullOrEmpty(l.SOPNUMBE) && (l.QUANTITY == 0));
        //        if (lines.Any())
        //        {
        //            List<SOPDeleteLineType> deleteLineTypes = new List<SOPDeleteLineType>();
        //            foreach (var line in lines)
        //            {
        //                deleteLineTypes.Add(new SOPDeleteLineType
        //                {
        //                    taSopLineDelete = new taSopLineDelete()
        //                    {
        //                        ITEMNMBR = line.ITEMNMBR,
        //                        SOPNUMBE = line.SOPNUMBE,
        //                        SOPTYPE = line.SOPTYPE,
        //                        LNITMSEQ = line.LNITMSEQ,
        //                        DeleteType = 2
        //                    }
        //                });

        //            }
        //            eConnectType eConnectType1 = new eConnectType();

        //            eConnectType1.SOPDeleteLineType = deleteLineTypes.ToArray();

        //            var deleteXmlString = GeneralOperationObject.SerializeObject(eConnectType1);

        //            var isDelete = eConnect.DeleteTransactionEntity(ConstantVariables.connectionStringGPWithIntegrated, deleteXmlString);
        //            return isDelete;
        //        }
        //        return false;

        //    }
        //}

        //public Root GetEntityMappedToRootDTO(string sopNumber)
        //{
        //    using (eConnectMethods eConnect = new eConnectMethods())
        //    {
        //        eConnectType eConnectTypeSalesTransaction = new eConnectType();

        //        eConnectOut eConnectOut1 = new eConnectOut()
        //        {
        //            DOCTYPE = "Sales_Transaction", // Specify the type of document you want to retrieve
        //            OUTPUTTYPE = 2, // Specify output type: 2 for XML
        //            INDEX1FROM = sopNumber, // Specify the start index
        //            INDEX1TO = sopNumber, // Specify the end index
        //            FORLIST = 1, // Specify 1 to retrieve a list

        //        };

        //        eConnectTypeSalesTransaction.RQeConnectOutType = new RQeConnectOutType[] { new RQeConnectOutType() { eConnectOut = eConnectOut1 } };
        //        string xmlSopTransaction = GeneralOperationObject.SerializeObject(eConnectTypeSalesTransaction);

        //        var response = eConnect.GetEntity(ConstantVariables.connectionStringGPWithIntegrated, xmlSopTransaction);

        //        // Deserialize the XML string into objects
        //        Root root = GeneralOperationObject.DeserializeFromXml<Root>(response);

        //        return root;
        //    }
        //}
        //public List<GpSerialsDTO> GetSerialsFullFilledBasedOnItemNumber(string sopNumber, string itemNumber)
        //{
        //    var data = ExecuteStoredProcedure(sopNumber, itemNumber);
        //    if (!data.HasErrors)
        //    {
        //        var result = (from DataRow dr in data.Rows
        //                      select new GpSerialsDTO
        //                      {

        //                          SOPTYPE = (short)dr["SOPTYPE"],
        //                          SOPNUMBE = dr["SOPNUMBE"].ToString()?.Trim(),
        //                          ITEMNMBR = dr["ITEMNMBR"].ToString()?.Trim(),
        //                          SERLTNUM = dr["SERLTNUM"].ToString()?.Trim(),
        //                          LOCNCODE = dr["LOCNCODE"].ToString()?.Trim(),
        //                          LNITMSEQ = (int)dr["LNITMSEQ"],
        //                      }).ToList();
        //        return result;
        //    }
        //    return new List<GpSerialsDTO>();
        //}
        //private DataTable ExecuteStoredProcedure(string sopNumber, string itemNumber)
        //{
        //    // string connectionString = "Data Source=192.168.5.33;Persist Security Info=True;Initial Catalog=ITS;Integrated Security=false;User Id=sa;Password=GP@dmin";
        //    var dataTable = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(ConstantVariables.connectionStringGPWithOUTIntegrated))
        //    {
        //        using (SqlCommand command = new SqlCommand("[dbo].[GetSerialsFullFilled]", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;

        //            // Add parameters
        //            command.Parameters.AddWithValue("@SOPNUMBE", sopNumber);
        //            command.Parameters.AddWithValue("@ITEMNMBR", itemNumber);

        //            connection.Open();

        //            using (SqlDataReader dataReader = command.ExecuteReader())
        //            {
        //                dataTable.Load(dataReader);
        //                connection.Close();

        //            }
        //        }
        //    }

        //    return dataTable;
        //}


    }
}
