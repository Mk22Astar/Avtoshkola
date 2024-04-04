using System;
using System.Collections.Generic;

namespace Avto1;

public partial class Tipzanyatiya
{
    public int Idtipzanyatiya { get; set; }

    public string Nazvanie { get; set; } = null!;

    public TimeOnly Prodolgitelnost { get; set; }

    public virtual ICollection<Zanyatiya> Zanyatiyas { get; set; } = new List<Zanyatiya>();
}
