using sahadLearn.API.models.domains;

namespace sahadLearn.API.models.DTO
{
    public class WalksDTO
    {

        public Guid id { get; set; }
        public String name { get; set; }
       
        public Guid difficaltyId { get; set; }
        public Guid RegionID { get; set; }

     
    }


    public class WalksCreateDTO
    {

      
        public String name { get; set; }
        public String discription { get; set; }
        public double LegthInKm { get; set; }
        public String? WalkImageUrl { get; set; }
        public Guid difficaltyId { get; set; }
        public Guid RegionID { get; set; }
    }


    public class WalksSingleDTO
    {
        public Guid id { get; set; }
        public String name { get; set; }
        public String discription { get; set; }
        public double LegthInKm { get; set; }
        public String? WalkImageUrl { get; set; }
        public Guid difficaltyId { get; set; }
        public Guid RegionID { get; set; }

        public Difficulty Defficalty { get; set; }
        public Region Rigion { get; set; }
    }
}
