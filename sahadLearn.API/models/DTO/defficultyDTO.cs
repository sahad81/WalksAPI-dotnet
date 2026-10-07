namespace sahadLearn.API.models.DTO
{
    public class difficultyDTO
    {
        public Guid id { get; set; }
        public String name { get; set; }
    }


    public class difficultyDTOCreateAndUpdate
    {
    
        public String name { get; set; }
    }
}
