using System;
using System.Collections.Generic;

namespace Avto1;

public partial class Avtorizaciya
{
    public int Id { get; set; }

    public int Idpolzovateli { get; set; }

    public string Login { get; set; } = null!;

    public string Parol { get; set; } = null!;

    public virtual Polzovateli IdpolzovateliNavigation { get; set; } = null!;
}
