﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laminar_PluginFramework.NodeSystem.Nodes
{
    public interface ITriggerNode : INode
    {
        event EventHandler Trigger;

        void HookupTriggers();
    }
}
