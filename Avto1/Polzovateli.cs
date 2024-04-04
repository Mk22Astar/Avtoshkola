using System;
using System.Collections.Generic;

namespace Avto1;

public partial class Polzovateli
{
    public int Idpolzovateli { get; set; }

    public string Familiya { get; set; } = null!;

    public string Imya { get; set; } = null!;

    public string? Otchestvo { get; set; }

    public int Idroli { get; set; }

    public int? Idgruppi { get; set; }

    public virtual ICollection<Avtorizaciya> Avtorizaciyas { get; set; } = new List<Avtorizaciya>();

    public virtual ICollection<Dogovori> Dogovoris { get; set; } = new List<Dogovori>();

    public virtual Gruppi? IdgruppiNavigation { get; set; }

    public virtual Roli IdroliNavigation { get; set; } = null!;

    public virtual ICollection<Zanyatiya> ZanyatiyaInstruktorNavigations { get; set; } = new List<Zanyatiya>();

    public virtual ICollection<Zanyatiya> ZanyatiyaYchenikNavigations { get; set; } = new List<Zanyatiya>();
}
