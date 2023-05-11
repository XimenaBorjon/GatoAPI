using System;
using System.Collections.Generic;

namespace GatoAPI.Models;

public partial class Jugador
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int PartidasGanadas { get; set; }
}
