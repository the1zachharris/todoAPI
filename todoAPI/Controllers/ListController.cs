using Microsoft.AspNetCore.Mvc;
using todoAPI.models;

namespace todoAPI.Controllers
{
    [Route("api/list")]
    [ApiController]
    public class ListController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ListDto>> GetList() {
            
            return Ok(ListData.Current.List );
        }

        [HttpGet("{id}", Name = "GetList")]
        public ActionResult<ListDto> GetList(int id) 
        {
            var ListToReturn = ListData.Current.List
                .FirstOrDefault(c => c.Id == id);

            if (ListToReturn == null)
            {
                return NotFound();
            }

            return Ok(ListToReturn);
        }

        [HttpPost]
        public ActionResult<ListDto> CreateList(ListForCreationDto list)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var maxListId = ListData.Current.List.Max(p => p.Id);

            var finalList = new ListDto()
            {
                Id = ++maxListId,
                Name = list.Name
            };

            ListData.Current.List.Add(finalList);

            return CreatedAtRoute("GetList", 
                new
                {
                    Id = finalList.Id
                },
                finalList
            );
        }

        [HttpPut("{listId}")]

        public ActionResult UpdateList(int listId, ListForUpdateDto list) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var ListToUpdate = ListData.Current.List
                .FirstOrDefault(c => c.Id == listId);
            if (ListToUpdate == null)
            {
                return NotFound();
            }

            ListToUpdate.Name = list.Name;
            return NoContent();
        }
    }
}
