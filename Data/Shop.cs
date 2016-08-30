using System;


namespace MHXSaveEditorOSX.Data
{
    public class Shop
    {
        public byte[] ShopData { get; set; }

        public Shop(byte[] ShopData)
        {
            this.ShopData = ShopData;
        }
    }
}
