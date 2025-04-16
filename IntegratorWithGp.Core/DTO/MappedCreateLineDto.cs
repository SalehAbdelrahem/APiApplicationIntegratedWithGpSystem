using System.Collections.Generic;

namespace IntegratorWithGp.Core.DTO
{

    public class MappedCreateLineDto
    {
        public string SOPNumber { get; set; }
        public List<MappedPartNumbersWithSerials> Serials;
    }
    public class MappedPartNumbersWithSerials
    {
        public string PartNumber { get; set; }
        public string LOCNCODE { get; set; }
        public List<string> SerialNumbers { get; set; }
    }

}
