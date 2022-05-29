using GameStore.API.BLL;
using GameStore.API.Models;
using GameStore.DAL.Abstract;
using GameStore.DAL.Entites;
using Microsoft.AspNetCore.Mvc;


namespace GameStore.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    public IService<GameModel> _gamesService { get; set; }

    public GamesController(IService<GameModel> gameSerivce)
    {
        _gamesService = gameSerivce;
    }

    // GET: api/<GameController>
    [HttpGet]
    public IEnumerable<GameModel> Get()
    {
        return _gamesService.GetAll();
    }

    // GET api/<GameController>/5
    [HttpGet("{id}")]
    public GameModel Get(int id)
    {
        return _gamesService.Get(id);
    }

    // POST api/<GameController>
    [HttpPost]
    public IActionResult Post([FromBody] GameModel game)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (!_gamesService.Add(game)) return BadRequest();
        return Ok();

    }

    // PUT api/<GameController>
    [HttpPut("{id}")]
    public IActionResult Put([FromBody] GameModel game)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (!_gamesService.Edit(game)) return BadRequest();
        return Ok();
    }

    // DELETE api/<GameController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (!_gamesService.Delete(id)) return BadRequest();
        return Ok();
    }
}
