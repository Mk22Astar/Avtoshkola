using System;
using System.Collections.Generic;

namespace Avto1;

public partial class Gruppi
{
    public int Idgruppi { get; set; }

    public DateOnly Dataformirovaniya { get; set; }

    public virtual ICollection<Polzovateli> Polzovatelis { get; set; } = new List<Polzovateli>();

    public virtual ICollection<Zanyatiya> Zanyatiyas { get; set; } = new List<Zanyatiya>();
}
