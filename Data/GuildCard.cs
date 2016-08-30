using System;

namespace MHXSaveEditorOSX.Data
{
    public class GuildCard
    {
        public byte[] GuildCardData { get; set; }
        public UInt16[] MonsterKills { get; set; }
        public UInt16[] MonsterCaptures { get; set; }

        public GuildCard(byte[] guildCardData)
        {
            this.GuildCardData = guildCardData;
        }
    }
}
