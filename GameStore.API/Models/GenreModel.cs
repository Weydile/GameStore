using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Models;
public class GenreModel : IModel
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

}
