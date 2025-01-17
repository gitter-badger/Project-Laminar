﻿using System;
using System.Collections.Generic;
using System.Threading;
using Laminar_Core.NodeSystem;
using Laminar_Core.Primitives.UserInterface;
using Laminar_PluginFramework;
using Laminar_Core.PluginManagement;
using Laminar_Core.NodeSystem.Nodes;

namespace Laminar_Core
{
    public class Instance
    {
        public Instance(SynchronizationContext uiContext)
        {
            Current = this;
            Laminar.Init(Factory);
            UIContext = uiContext;
            _ = new PluginLoader();
        }

        public static Instance Current { get; private set; }

        public static ObjectFactory Factory { get; } = new();

        public SynchronizationContext UIContext { get; }

        public Dictionary<Type, TypeInfoRecord> TypeInfo { get; } = new ();

        public LoadedNodeManager LoadedNodeManager { get; } = new(Factory.GetImplementation<INodeFactory>());

        public IUserInterfaceRegister RegisteredEditors { get; } = Factory.GetImplementation<IUserInterfaceRegister>();

        public IUserInterfaceRegister RegisteredDisplays { get; } = Factory.GetImplementation<IUserInterfaceRegister>();

        public bool RegisterTypeInfo(Type type, TypeInfoRecord record) => TypeInfo.TryAdd(type, record);

        public TypeInfoRecord GetTypeInfo(Type type)
        {
            if (TypeInfo.TryGetValue(type, out TypeInfoRecord info))
            {
                return info;
            }

            throw new NotSupportedException($"The type {type} is not registered, and cannot be displayed");
        }

        public record TypeInfoRecord(object DefaultValue, string HexColour, string DefaultDisplay, string DefaultEditor, string UserFriendlyName);
    }
}
