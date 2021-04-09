﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFlow_Core.Primitives.ObservableCollectionMapper
{
    public interface ITypeMapper<TIn, TOut>
    {
        TOut MapType(TIn input);
    }
}
