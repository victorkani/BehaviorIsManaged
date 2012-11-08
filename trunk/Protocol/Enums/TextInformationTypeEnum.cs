#region License GNU GPL
// TextInformationTypeEnum.cs
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
using System.Collections.Generic;

namespace BiM.Protocol.Enums
{
    public enum TextInformationTypeEnum
    {
        TEXT_INFORMATION_MESSAGE = 0,
        TEXT_INFORMATION_ERROR = 1,
        TEXT_INFORMATION_PVP = 2,
        TEXT_INFORMATION_FIGHT_LOG = 3,
        TEXT_INFORMATION_POPUP = 4,
        TEXT_LIVING_OBJECT = 5,
        TEXT_ENTITY_TALK = 6,
        TEXT_INFORMATION_FIGHT = 7,
    }
}