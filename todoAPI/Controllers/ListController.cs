using AutoMapper;
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
        private readonly IMapper _mapper;

        public ListController(IListInfoRepository listInfoRepository, IMapper mapper) 
        {
            _listInfoRepository = listInfoRepository ?? throw new ArgumentNullException(nameof(listInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListDto>>> GetList() 
        {
            var listEntities = await _listInfoRepository.GetListsAsync();
            return Ok(_mapper.Map<IEnumerable<ListDto>>(listEntities));
        }

        [HttpGet("{id}", Name = "getlist")]
        public async Task<IActionResult> GetList(int id)
        {
            var list = await _listInfoRepository.GetListAsync(id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ListDto>(list));
        }

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
