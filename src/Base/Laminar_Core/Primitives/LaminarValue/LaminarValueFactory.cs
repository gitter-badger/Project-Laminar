﻿using Laminar_PluginFramework;
using Laminar_PluginFramework.Primitives;
using Laminar_PluginFramework.Primitives.TypeDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laminar_Core.Primitives.LaminarValue
{
    public class LaminarValueFactory : ILaminarValueFactory
    {
        public ILaminarValue Get(object value, bool isUserEditable)
        {
            ILaminarValue output = new LaminarValue(GetProvider(value), Instance.Factory.GetImplementation <IObservableValue<bool>>());
            output.IsUserEditable.Value = isUserEditable;
            return output;
        }

        public ILaminarValue Get<T>(bool isUserEditable)
            => Get(Instance.Current.GetTypeInfo(typeof(T)).DefaultValue, isUserEditable);

        private static ITypeDefinitionProvider GetProvider(object value)
        {
            if (value is ITypeDefinitionProvider typeDefinitionProvider)
            {
                return typeDefinitionProvider;
            }

            if (value is ITypeDefinition typeDefinition)
            {
                IManualTypeDefinitionProvider manager = Instance.Factory.GetImplementation<IManualTypeDefinitionProvider>();
                manager.RegisterTypeDefinition(typeDefinition);
                return manager;
            }

            IRigidTypeDefinitionManager rigidTypeDefinitionManager = Instance.Factory.GetImplementation<IRigidTypeDefinitionManager>();
            rigidTypeDefinitionManager.RegisterTypeDefinition(value, null, null);
            return rigidTypeDefinitionManager;
        }
    }
}
