using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Models;
public class StudioModel : IModel
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }


}
