#region License GNU GPL
// GameRolePlayArenaUpdatePlayerInfosMessage.cs
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
using System.Linq;
using BiM.Protocol.Types;
using BiM.Core.IO;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
    public class GameRolePlayArenaUpdatePlayerInfosMessage : NetworkMessage
    {
        public const uint Id = 6301;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short rank;
        public short bestDailyRank;
        public short bestRank;
        public short victoryCount;
        public short arenaFightcount;
        
        public GameRolePlayArenaUpdatePlayerInfosMessage()
        {
        }
        
        public GameRolePlayArenaUpdatePlayerInfosMessage(short rank, short bestDailyRank, short bestRank, short victoryCount, short arenaFightcount)
        {
            this.rank = rank;
            this.bestDailyRank = bestDailyRank;
            this.bestRank = bestRank;
            this.victoryCount = victoryCount;
            this.arenaFightcount = arenaFightcount;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(rank);
            writer.WriteShort(bestDailyRank);
            writer.WriteShort(bestRank);
            writer.WriteShort(victoryCount);
            writer.WriteShort(arenaFightcount);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            rank = reader.ReadShort();
            if (rank < 0 || rank > 2300)
                throw new Exception("Forbidden value on rank = " + rank + ", it doesn't respect the following condition : rank < 0 || rank > 2300");
            bestDailyRank = reader.ReadShort();
            if (bestDailyRank < 0 || bestDailyRank > 2300)
                throw new Exception("Forbidden value on bestDailyRank = " + bestDailyRank + ", it doesn't respect the following condition : bestDailyRank < 0 || bestDailyRank > 2300");
            bestRank = reader.ReadShort();
            if (bestRank < 0 || bestRank > 2300)
                throw new Exception("Forbidden value on bestRank = " + bestRank + ", it doesn't respect the following condition : bestRank < 0 || bestRank > 2300");
            victoryCount = reader.ReadShort();
            if (victoryCount < 0)
                throw new Exception("Forbidden value on victoryCount = " + victoryCount + ", it doesn't respect the following condition : victoryCount < 0");
            arenaFightcount = reader.ReadShort();
            if (arenaFightcount < 0)
                throw new Exception("Forbidden value on arenaFightcount = " + arenaFightcount + ", it doesn't respect the following condition : arenaFightcount < 0");
        }
        
    }
    
}