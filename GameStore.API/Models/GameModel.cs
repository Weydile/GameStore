using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Models;

public class GameModel : IModel
{
   
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int StudioId { get; set; }
    [Required]
    public List<int> GenresIds { get; set; }

}

