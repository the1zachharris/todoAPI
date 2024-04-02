using Microsoft.AspNetCore.Mvc;
using todoAPI.models;
using todoAPI.Services;

namespace todoAPI.Controllers
{
    [Route("api/list")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListInfoRepository _listInfoRepository;

        public ListController(IListInfoRepository listInfoRepository) 
        {
            _listInfoRepository = listInfoRepository ?? throw new ArgumentNullException(nameof(listInfoRepository));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListDto>>> GetList() 
        {
            var listEntities = await _listInfoRepository.GetListsAsync();
            var results = new List<ListDto>();
            foreach (var listEntity in listEntities)
            {
                results.Add(new ListDto
                {
                    Id = listEntity.Id,
                    Name = listEntity.Name
                });
            }
            return Ok(results);
            //return Ok(ListData.Current.List );
        }

        //[HttpGet("{id}", Name = "GetList")]
        //public ActionResult<ListDto> GetList(int id) 
        //{
        //    var ListToReturn = ListData.Current.List
        //        .FirstOrDefault(c => c.Id == id);

        //    if (ListToReturn == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(ListToReturn);
        //}

        //[HttpPost]
        //public ActionResult<ListDto> CreateList(ListForCreationDto list)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    var maxListId = ListData.Current.List.Max(p => p.Id);

        //    var finalList = new ListDto()
        //    {
        //        Id = ++maxListId,
        //        Name = list.Name
        //    };

        //    ListData.Current.List.Add(finalList);

        //    return CreatedAtRoute("GetList", 
        //        new
        //        {
        //            Id = finalList.Id
        //        },
        //        finalList
        //    );
        //}

        //[HttpPut("{listId}")]

        //public ActionResult UpdateList(int listId, ListForUpdateDto list) 
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    var ListToUpdate = ListData.Current.List
        //        .FirstOrDefault(c => c.Id == listId);
        //    if (ListToUpdate == null)
        //    {
        //        return NotFound();
        //    }

        //    ListToUpdate.Name = list.Name;
        //    return NoContent();
        //}

        //[HttpDelete("{listId}")] 
        //public ActionResult DeleteList(int listId)
        //{
        //    var ListToDelete = ListData.Current.List
        //        .FirstOrDefault(c => c.Id == listId);
        //    if (ListToDelete == null)
        //    {
        //        return NotFound();
        //    }
        //    ListData.Current.List.Remove(ListToDelete);
        //    return NoContent();
        //}
    }
}
