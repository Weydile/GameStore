namespace GameStore.DAL.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


/// <summary>
/// Игра
/// </summary>
public class Game : DefaultEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Студия разработчик игры
    /// </summary>
    [Required]
    public virtual Studio Studio { get; set; }

    /// <summary>
    /// Жанры к которым относится игра
    /// </summary>
    [Required]
    public virtual List<Genre> Genres { get; set; } = new();

}
