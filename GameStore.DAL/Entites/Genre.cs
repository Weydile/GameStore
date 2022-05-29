using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entites;
/// <summary>
/// Жанр
/// </summary>
public class Genre : DefaultEntity
{
    /// <summary>
    /// Название
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Игры в жанре
    /// </summary>
    public virtual List<Game> Games { get; set; } = new();

}
