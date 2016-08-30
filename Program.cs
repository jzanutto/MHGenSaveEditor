using System;

using MHXSaveEditorOSX.Util;

namespace MHXSaveEditorOSX
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.Write("Please enter a file path: ");
            var filepath = Console.ReadLine();
            var dataExtractor = new DataExtractor(filepath);
            var saveFile = dataExtractor.GetSaveFile();
            var player = saveFile.Players[0];
            for (var i = 0; i < player.TalismanList.Length; i++)
            {
                // Console.WriteLine(saveFile.Players[0].ItemBox[i]);
                if (player.TalismanList[i] != null)
                {
                    Console.WriteLine(player.TalismanList[i]);
                }
            }
        }
    }
}
