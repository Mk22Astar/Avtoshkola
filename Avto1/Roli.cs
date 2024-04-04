using System;
using System.Collections.Generic;

namespace Avto1;

public partial class Roli
{
    public int Idroli { get; set; }

    public string Nazvanieroli { get; set; } = null!;

    public virtual ICollection<Polzovateli> Polzovatelis { get; set; } = new List<Polzovateli>();
}
