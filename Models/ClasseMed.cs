using System;
using System.Collections.Generic;

namespace apisaude.Models;

public partial class ClasseMed
{
    public int CodClasse { get; set; }

    public string NomeClasse { get; set; } = null!;

    public virtual ICollection<Matmed> Matmeds { get; } = new List<Matmed>();
}
