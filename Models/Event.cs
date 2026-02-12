namespace EventEaseApp.Models;

/// <summary>
/// Representa un evento en el sistema EventEase
/// </summary>
public class Event
{
    /// <summary>
    /// Identificador único del evento
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre del evento
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Fecha del evento
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Ubicación donde se realizará el evento
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Descripción detallada del evento
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Capacidad máxima del evento
    /// </summary>
    public int Capacity { get; set; }
}
