using System;
using System.IO;

namespace MHXSaveEditorOSX.Data
{
    public class Equipment
    {
        public byte[] EquipmentBytes { get; set; }
        public UInt32 EquipmentID { get; set; }
        public string Type { get; set; }
        public UInt32 TypeID { get; set; }
        public UInt16 EquipmentLevel { get; set; }
        public UInt32 Decoration1 { get; set; }
        public UInt32 Decoration2 { get; set; }
        public UInt32 Decoration3 { get; set; }
        public byte[] DataExcess { get; set; }

        protected Equipment()
        {
        }

        public Equipment(byte[] bytes)
        {
            this.EquipmentBytes = bytes;
            var binWriter = new BinaryWriter(new MemoryStream());
            binWriter.Write(this.EquipmentBytes);
            var binReader = new BinaryReader(binWriter.BaseStream);
            binReader.BaseStream.Position = 0;
            this.TypeID = (uint) binReader.ReadByte();
            this.Type = GameConstants.EquipmentTypes[TypeID];
            this.EquipmentID = (uint) binReader.ReadUInt16();
            this.EquipmentLevel = (ushort) binReader.ReadByte();
            binReader.ReadUInt16(); // skip buffer
            this.Decoration1 = (uint) binReader.ReadUInt16();
            this.Decoration2 = (uint) binReader.ReadUInt16();
            this.Decoration3 = (uint) binReader.ReadUInt16();
            this.DataExcess = binReader.ReadBytes(24);
        }

        public Equipment GetClone()
        {
            if (this.EquipmentBytes == null)
                return null;

            int length = this.EquipmentBytes.Length;

            byte[] temp = new byte[length];
            for (int i = 0; i < temp.Length; i++)
            {
                byte b = this.EquipmentBytes[i];
                temp[i] = b;
            }

            return new Equipment(temp);
        }

        public Equipment(Equipment equip)
        {
            byte[] temp = new byte[equip.EquipmentBytes.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                byte b = equip.EquipmentBytes[i];
                temp[i] = b;
            }

            EquipmentBytes = temp;
        }

        public override string ToString()
        {
            //TODO
            return string.Format("Type: {0} ID: {1} Level: {2} Decorations: ({3})({4})({5})",
                this.Type,this.EquipmentID,this.EquipmentLevel,this.Decoration1,this.Decoration2,this.Decoration3);
        }
    }
}
