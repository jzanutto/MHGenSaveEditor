using System;
using System.IO;


namespace MHXSaveEditorOSX.Data
{
    public class Talisman
    {
        public Equipment EquipmentData { get; set; }
        public Int32 Index { get; }
        public UInt32 Skill1ID { get; set; }
        public UInt32 Skill2ID { get; set; }
        public Int32 Skill1Level { get; set; }
        public Int32 Skill2Level { get; set; }
        public UInt32 Slots { get; set; }
        public byte[] DataExcess { get; set; }
        public Talisman(Equipment eq, Int32 equipmentBoxIndex)
        {
            Index = equipmentBoxIndex;
            EquipmentData = eq;
            var binWriter = new BinaryWriter(new MemoryStream());
            binWriter.Write(this.EquipmentData.DataExcess);
            var binReader = new BinaryReader(binWriter.BaseStream);
            binReader.BaseStream.Position = 0;
            this.Skill1ID = (uint) binReader.ReadByte();
            this.Skill2ID = (uint) binReader.ReadByte();
            this.Skill1Level = (int)binReader.ReadSByte();
            this.Skill2Level = (int)binReader.ReadSByte();
            this.Slots = (uint) binReader.ReadByte();
            this.DataExcess = binReader.ReadBytes(19);
        }
        public override string ToString()
        {

            return string.Format("Skill 1: {0} {1}|Skill 2: {2} {3}| Slots: {4}", 
                        GameConstants.EquipmentSkills[this.Skill1ID],
                        this.Skill1Level,
                        GameConstants.EquipmentSkills[this.Skill2ID],
                        this.Skill2Level,
                        this.Slots
                    ) + "\n" + EquipmentData.ToString();
        }
    }
}