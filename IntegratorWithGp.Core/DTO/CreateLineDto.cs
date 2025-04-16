using System.Collections.Generic;

namespace IntegratorWithGp.Core.DTO
{
    public class CreateLineDto
    {
        public string SOPNumber { get; set; }
        public List<PartNumbersWithSerials> Serials;
    }
    public class PartNumbersWithSerials
    {
        public string PartNumber { get; set; }
        //public string LOCNCODE { get; set; }
        public List<SerialsWithLocation> SerialWithLocation { get; set; }
    }
    public class SerialsWithLocation
    {
        public string LOCNCODE { get; set; }
        public string Serial { get; set; }
    }
}
