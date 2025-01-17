﻿using Laminar_Core.NodeSystem.NodeComponents.Visuals;
using Laminar_PluginFramework;
using Laminar_PluginFramework.NodeSystem.NodeComponents.Visuals;
using Laminar_PluginFramework.NodeSystem.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Laminar_Core.NodeSystem.Nodes.NodeTypes
{
    public class TriggerNode<T> : NodeBase<T> where T : INode
    {
        private readonly INodeLabel FlowOut = Constructor.NodeLabel("Trigger Flow Out").WithFlowOutput();

        public TriggerNode(NodeDependencyAggregate dependencies) : base(dependencies)
        {
            (BaseNode as ITriggerNode).Trigger += TriggerNode_Trigger;
            FieldList.Insert(0, FlowOut);
            FlowOutContainer = GetContainer(FlowOut);
        }

        public override void MakeLive()
        {
            (BaseNode as ITriggerNode).HookupTriggers();
        }

        private void TriggerNode_Trigger(object sender, EventArgs e)
        {
             FlowOutContainer.OutputConnector?.Activate();
        }
    }
}
