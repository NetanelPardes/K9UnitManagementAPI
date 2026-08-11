namespace K9UnitManagementAPI.DTO
{
    public class DogsWithTheHandlerTDO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Specialization { get; set; }
        public string Status { get; set; }
        public int HandlerId { get; set; }
        public string HandlerName { get; set; }
    }
}
