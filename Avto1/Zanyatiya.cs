using System;
using System.Collections.Generic;

namespace Avto1;

public partial class Zanyatiya
{
    public int Idzanyatiya { get; set; }

    public DateOnly Datazanyatiya { get; set; }

    public int Idtipzanyatiya { get; set; }

    public string? Ayditoriya { get; set; }

    public int? Ychenik { get; set; }

    public int? Idgruppi { get; set; }

    public int? Idmashini { get; set; }

    public int Instruktor { get; set; }

    public DateTimeOffset Vremya { get; set; }

    public virtual Gruppi? IdgruppiNavigation { get; set; }

    public virtual Avtopark? IdmashiniNavigation { get; set; }

    public virtual Tipzanyatiya IdtipzanyatiyaNavigation { get; set; } = null!;

    public virtual Polzovateli InstruktorNavigation { get; set; } = null!;

    public virtual Polzovateli? YchenikNavigation { get; set; }
}
