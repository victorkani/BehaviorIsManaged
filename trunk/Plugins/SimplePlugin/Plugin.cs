﻿#region License GNU GPL
// Plugin.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion
using System;
using BiM.Host.Plugins;
using SimplePlugin.Handlers;

namespace SimplePlugin
{
    public class Plugin : PluginBase
    {
        public Plugin(PluginContext context)
            : base(context)
        {
            if (CurrentPlugin != null)
                throw new Exception("Can be instancied only once");

            CurrentPlugin = this;
        }

        public static Plugin CurrentPlugin
        {
            get;
            private set;
        }

        public override string Name
        {
            get { return "Simple Plugin"; }
        }

        public override string Description
        {
            get { return "Just an example"; }
        }

        public override string Author
        {
            get { return "timorem"; }
        }

        public override Version Version
        {
            get { return new Version(1, 0); }
        }

        public override bool UseConfig
        {
            get { return true; }
        }

        public override void Initialize()
        {
            base.Initialize();
            GameCommands.CreateTchatCommand("Seek", "Seek <NomDuMonstre>", MonsterSeeker.HandleSeekCommand);
            GameCommands.CreateTchatCommand("Stop", "Stop <NomDuMonstre>", MonsterSeeker.HandleStopCommand);
            GameCommands.CreateTchatCommand("List", "List", MonsterSeeker.HandleListCommand);
        }

        public override void Dispose()
        {
        }
    }
}