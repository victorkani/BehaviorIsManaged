// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'ItemNoMoreAvailableMessage.xml' the '27/06/2012 15:55:11'
using System;
using BiM.Core.IO;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class ItemNoMoreAvailableMessage : NetworkMessage
	{
		public const uint Id = 5769;
		public override uint MessageId
		{
			get
			{
				return 5769;
			}
		}
		
		
		public override void Serialize(IDataWriter writer)
		{
		}
		
		public override void Deserialize(IDataReader reader)
		{
		}
	}
}