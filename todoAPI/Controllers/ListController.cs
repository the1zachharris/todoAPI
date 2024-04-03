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

        [HttpPost]
        public async Task<ActionResult<ListDto>> CreateList(ListForCreationDto list)
        {
            var finalList = _mapper.Map<Entities.List>(list);

            await _listInfoRepository.CreateListAsync(finalList);
            await _listInfoRepository.SaveChangesAsync();

            var createdListToReturn = _mapper.Map<models.ListDto>(finalList);

            return CreatedAtRoute("GetList",
                new
                {
                    Id = createdListToReturn.Id
                },
                createdListToReturn
            );
        }

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

        [HttpDelete("{listId}")]
        public async Task<ActionResult> DeleteList(int listId)
        {
            var listEntity = await _listInfoRepository.GetListAsync(listId);
            if (listEntity == null)
            {
                return NotFound();
            }
            _listInfoRepository.DeleteList(listEntity);
            await _listInfoRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
