// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'ExchangeItemAutoCraftStopedMessage.xml' the '27/06/2012 15:55:09'
using System;
using BiM.Core.IO;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class ExchangeItemAutoCraftStopedMessage : NetworkMessage
	{
		public const uint Id = 5810;
		public override uint MessageId
		{
			get
			{
				return 5810;
			}
		}
		
		public sbyte reason;
		
		public ExchangeItemAutoCraftStopedMessage()
		{
		}
		
		public ExchangeItemAutoCraftStopedMessage(sbyte reason)
		{
			this.reason = reason;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(reason);
		}
		
		public override void Deserialize(IDataReader reader)
		{
			reason = reader.ReadSByte();
		}
	}
}