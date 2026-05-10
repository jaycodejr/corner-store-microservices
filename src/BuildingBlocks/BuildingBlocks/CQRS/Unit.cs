using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS;

public readonly struct Unit
{
    public static readonly Unit Value = new();
}
