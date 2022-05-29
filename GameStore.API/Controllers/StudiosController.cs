using GameStore.API.BLL;
using GameStore.API.Models;
using GameStore.DAL.Abstract;
using GameStore.DAL.Entites;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudiosController : ControllerBase
{
    public IService<StudioModel> _studiosService { get; set; }

    public StudiosController(IService<StudioModel> studiosService)
    {
        _studiosService = studiosService;
    }

    // GET: api/<GenresController>
    [HttpGet]
    public IEnumerable<StudioModel> Get()
    {
        return _studiosService.GetAll();
    }

    // GET api/<GenresController>/5
    [HttpGet("{id}")]
    public StudioModel Get(int id)
    {
        return _studiosService.Get(id);
    }

    // POST api/<GenresController>
    [HttpPost]
    public IActionResult Post([FromBody] StudioModel studio)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (!_studiosService.Add(studio)) return BadRequest();
        return Ok();

    }

    // PUT api/<GenresController>
    [HttpPut("{id}")]
    public IActionResult Put([FromBody] StudioModel studio)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (!_studiosService.Edit(studio)) return BadRequest();
        return Ok();
    }

    // DELETE api/<GenresController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (!_studiosService.Delete(id)) return BadRequest();
        return Ok();
    }
}
