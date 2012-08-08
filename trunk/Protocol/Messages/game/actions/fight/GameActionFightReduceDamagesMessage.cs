// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'GameActionFightReduceDamagesMessage.xml' the '27/06/2012 15:54:57'
using System;
using BiM.Core.IO;

namespace BiM.Protocol.Messages
{
	public class GameActionFightReduceDamagesMessage : AbstractGameActionMessage
	{
		public const uint Id = 5526;
		public override uint MessageId
		{
			get
			{
				return 5526;
			}
		}
		
		public int targetId;
		public int amount;
		
		public GameActionFightReduceDamagesMessage()
		{
		}
		
		public GameActionFightReduceDamagesMessage(short actionId, int sourceId, int targetId, int amount)
			 : base(actionId, sourceId)
		{
			this.targetId = targetId;
			this.amount = amount;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(targetId);
			writer.WriteInt(amount);
		}
		
		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadInt();
			amount = reader.ReadInt();
			if ( amount < 0 )
			{
				throw new Exception("Forbidden value on amount = " + amount + ", it doesn't respect the following condition : amount < 0");
			}
		}
	}
}