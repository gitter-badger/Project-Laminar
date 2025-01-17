﻿using Laminar_Core.NodeSystem.NodeComponents.Visuals;
using Laminar_Core.Primitives;
using Laminar_PluginFramework.NodeSystem.Nodes;
using Laminar_PluginFramework.Primitives;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Laminar_Core.NodeSystem.Nodes
{
    public interface INodeBase
    {
        public static Dictionary<INode, INodeBase> NodeBases { get; } = new();

        IObservableValue<bool> ErrorState { get; }

        IObservableValue<string> Name { get; }

        INotifyCollectionChanged Fields { get; }

        IPoint Location { get; }

        void MakeLive();

        void Update();

        IVisualNodeComponentContainer FlowOutContainer { get; }

        INodeBase DuplicateNode();
    }
}