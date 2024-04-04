using System;
using System.Collections.Generic;

namespace Avto1;

public partial class Avtopark
{
    public int Idmashini { get; set; }

    public int Idtipmashin { get; set; }

    public string Status { get; set; } = null!;

    public virtual Tipmashin IdtipmashinNavigation { get; set; } = null!;

    public virtual ICollection<Zanyatiya> Zanyatiyas { get; set; } = new List<Zanyatiya>();
}
