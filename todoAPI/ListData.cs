using todoAPI.models;
namespace todoAPI
{
    public class ListData
    {
        public List<ListDto> List { get; set; }
        public static ListData Current { get; } = new ListData();

        public ListData() 
        {
            List = new List<ListDto>()
            {
                new ListDto()
                {
                    Id = 1,
                    Name = "Laundry"
                },
                new ListDto()
                {
                    Id = 2,
                    Name = "Dishes"
                }
            };
        }
    }
}
