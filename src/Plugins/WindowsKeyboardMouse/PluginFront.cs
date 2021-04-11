﻿using OpenFlow_PluginFramework.Primitives;
using OpenFlow_PluginFramework.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsKeyboardMouse
{
    public class PluginFront : IPlugin
    {
        public Platforms Platforms => Platforms.Windows;

        public string PluginName { get; } = "Keyboard and Mouse interface";

        public string PluginDescription { get; } = "Allows for interfacing with the keyboard and mouse, including listening for keyboard and mouse events and sending keyboard and mouse input in Windows";

        public void Register(IPluginHost host)
        {
            
        }
    }
}
