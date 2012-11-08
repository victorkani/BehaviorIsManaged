﻿#region License GNU GPL
// CharactersListEntry.cs
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
using System.ComponentModel;
using BiM.Protocol.Enums;
using BiM.Protocol.Types;

namespace BiM.Behaviors.Authentification
{
    public class CharactersListEntry : INotifyPropertyChanged
    {
        public CharactersListEntry(CharacterBaseInformations entry)
        {
            Id = entry.id;
            Name = entry.name;
            Level = entry.level;
            Look = entry.entityLook;
            Breed = (PlayableBreedEnum)entry.breed;
            Sex = entry.sex;
        }

        public int Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Level
        {
            get;
            private set;
        }

        public EntityLook Look
        {
            get;
            private set;
        }

        public PlayableBreedEnum Breed
        {
            get;
            private set;
        }

        public bool Sex
        {
            get;
            private set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}