using System;
using System.Collections.Generic;

namespace Avto1;

public partial class Dogovori
{
    public int Iddogovora { get; set; }

    public int Idpolzovateli { get; set; }

    public DateOnly Datazaklucheniya { get; set; }

    public DateOnly Dataokonchaniya { get; set; }

    public decimal Vnesennayasumma { get; set; }

    public virtual Polzovateli IdpolzovateliNavigation { get; set; } = null!;
}
