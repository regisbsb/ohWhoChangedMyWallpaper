using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace fuckingHellWhoChangedMyWallpaper
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        
        static void Main()
        {
            const int SPI_SETDESKWALLPAPER = 20;
            const int SPIF_UPDATEINIFILE = 0x01;
            const int SPIF_SENDWININICHANGE = 0x02;
            
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            key.SetValue(@"WallpaperStyle", 2.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());

            SystemParametersInfo(
                SPI_SETDESKWALLPAPER,
                0,
                @"C:\wallpaper.bmp",
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}
