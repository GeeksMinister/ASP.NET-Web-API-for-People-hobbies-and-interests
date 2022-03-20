[Route("api/[controller]")]
[ApiController]
public class Labb4_API_Controller : ControllerBase
{
    private readonly ILabb4_API_Repository _repository;
    public Labb4_API_Controller(ILabb4_API_Repository repository)
    {
        _repository = repository;
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
}