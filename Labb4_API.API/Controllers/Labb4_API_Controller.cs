using AutoMapper;
using Newtonsoft.Json;

[Route("api/[controller]")]
[ApiController]
public class Labb4_API_Controller : ControllerBase
{
    private readonly ILabb4_API_Repository<Person, Interest, Link> _repository;
    private readonly IMapper _mapper;
    public Labb4_API_Controller(ILabb4_API_Repository<Person, Interest, Link> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("AllPeople")]
    public async Task<IActionResult> GetPeople()
    {
        try
        {
            var people = await _repository.GetAllPeople();
            return Ok(people);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                        "Failed to retrive data from server");
        }
    }

    [HttpGet("GetInterestsByPersonId")]
    public async Task<IActionResult> GetInterestsById(int personId)
    {
        try
        {
            bool found = await _repository.CheckPersonExists(personId);
            if (found)
            {
                var interests = await _repository.GetAllRelatedInterests(personId);
                if (interests != null)
                {
                    return Ok(interests);
                }
            }
            return NotFound($"Person with Id {personId} was not found");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                        "Failed to retrieve person");
        }
    }

    [HttpGet("GetLinksByPersonId")]
    public async Task<IActionResult> GetLinkSById(int personId)
    {
        try
        {
            bool found = await _repository.CheckPersonExists(personId);
            if (found)
            {
                var links = await _repository.GetAllRelatedLinks(personId);
                if (links != null)
                {
                    return Ok(links);
                }
            }
            return NotFound($"Person with Id {personId} was not found");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                            "Failed to retrieve person");
        }
    }

    [HttpPost("AddInterest")]
    public async Task<IActionResult> AddInterest(InterestDto interestDto)
    {
        try
        {
            if (interestDto != null)
            {
                Interest interest = _mapper.Map<Interest>(interestDto);
                var newInterest = await _repository.CreateNewInterest(interest);
                if (newInterest != null)
                {
                    return Ok(newInterest);
                }
            }
            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                        $"Failed to create an interest or the entered PersonId" +
                        $" [{interestDto.PersonId}] wasn't found");
        }
    }

    [HttpPost("AddLink")]
    public async Task<IActionResult> AddLink(LinkDto linkDto)
    {
        try
        {
            if (linkDto != null)
            {
                Link link = _mapper.Map<Link>(linkDto);
                var newLink = await _repository.CreateNewLink(link);
                if (newLink != null)
                {
                    return Ok(newLink);
                }
            }
            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                        $"Failed to create a link or the entered (PersonId" +
                        $" [{linkDto.PersonId}] , InterestId [{linkDto.InterestId}]) weren't found");
        }
    }

    [HttpGet("GetAllInfoForPerson")]
    public async Task<IActionResult> GetAllInfo(int personId)
    {
        try
        {
            bool found = await _repository.CheckPersonExists(personId);
            if (found)
            {
                var person = await _repository.GetAllInfoByPersonId(personId);
                if (person != null)
                {
                    return Ok(person);
                }
            }
            return NotFound($"Person with Id {personId} was not found");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                            "Failed to retrieve person");
        }
    }

    [HttpGet("SearchForPerson")]
    public async Task<IActionResult> Search(string search)
    {
        try
        {
            if (!string.IsNullOrEmpty(search))
            {
                var people = await _repository.SearchForPerson(search);
                if (people.Any())
                {
                    return Ok(people);
                }
                return NotFound($"There are NO results for {search}");
            }
            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                        "Failed to retrive data from server");
        }
    }

    [HttpGet("Paging")]
    public async Task<IActionResult> RequestPeopleObject([FromQuery] Objectparameters peopleParameters)
    {
        try
        {
            if (peopleParameters != null)
            {
                var people = await _repository.GetPeople(peopleParameters);
                if (people.Any())
                {
                    return Ok(people);
                }
                return NotFound($"There are NO more results");
            }
            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                        "Failed to retrive data from server");
        }
    }

    //[HttpGet("EnhancedPaging")]
    //public async Task<IActionResult> RequestPeopleObjectEnhanced([FromQuery] Objectparameters peopleParameters)
    //{
    //    var owners = await _repository.GetPeopleEnhanced(peopleParameters);
    //    var metadata = new
    //    {
    //        owners.TotalCount,
    //        owners.PageSize,
    //        owners.CurrentPage,
    //        owners.TotalPages,
    //        owners.HasNext,
    //        owners.HasPrevious
    //    };
    //    Response.Headers.Add("People-Pagination", JsonConvert.SerializeObject(metadata));
    //    return Ok(owners);
    //}

}