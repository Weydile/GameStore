using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entites;

/// <summary>
/// Студия разработчик
/// </summary>
public class Studio : DefaultEntity
{
    /// <summary>
    /// Название
    /// </summary>
    [Required]
    public string Name { get; set; }


    /// <summary>
    /// Игры компании
    /// </summary>
    public virtual List<Game> Games { get; set; } = new();
}
