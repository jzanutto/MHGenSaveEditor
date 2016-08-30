using System;

namespace MHXSaveEditorOSX.Data
{
    public class Item
    {
        public UInt32 ItemID { get; set; }
        public UInt32 ItemAmount { get; set; }

        public Item(UInt32 ItemID, UInt32 ItemAmount)
        {
            this.ItemID = ItemID;
            this.ItemAmount = ItemAmount;
        }

        public Item()
        {
            this.ItemID = 0;
            this.ItemAmount = 0;
        }

        public Item(Item copy)
        {
            this.ItemID = copy.ItemID;
            this.ItemAmount = copy.ItemAmount;
        }

        public override string ToString()
        {
            if (this.ItemID >= GameConstants.ItemList.Length)
            {
                return string.Format("Unknown Item [{0}]", this.ItemID);
            }
            else
            {
                return GameConstants.ItemList[ItemID];
            }
        }
    }
}
