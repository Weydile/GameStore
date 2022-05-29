using GameStore.API.BLL;
using GameStore.API.Models;
using GameStore.DAL.Abstract;
using GameStore.DAL.Entites;
using Microsoft.AspNetCore.Mvc;


namespace GameStore.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    public IService<GenreModel> _genresService { get; set; }

    public GenresController(IService<GenreModel> genresService)
    {
        _genresService = genresService;
    }

    // GET: api/<GenresController>
    [HttpGet]
    public IEnumerable<GenreModel> Get()
    {
        return _genresService.GetAll();
    }

    // GET api/<GenresController>/5
    [HttpGet("{id}")]
    public GenreModel Get(int id)
    {
        return _genresService.Get(id);
    }

    // POST api/<GenresController>
    [HttpPost]
    public IActionResult Post([FromBody] GenreModel genre)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (!_genresService.Add(genre)) return BadRequest();
        return Ok();

    }

    // PUT api/<GenresController>
    [HttpPut("{id}")]
    public IActionResult Put([FromBody] GenreModel genre)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (!_genresService.Edit(genre)) return BadRequest();
        return Ok();
    }

    // DELETE api/<GenresController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (!_genresService.Delete(id)) return BadRequest();
        return Ok();
    }
}
