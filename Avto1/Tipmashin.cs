using System;
using System.Collections.Generic;

namespace Avto1;

public partial class Tipmashin
{
    public int Idtipmashin { get; set; }

    public string Nazvanie { get; set; } = null!;

    public virtual ICollection<Avtopark> Avtoparks { get; set; } = new List<Avtopark>();
}
