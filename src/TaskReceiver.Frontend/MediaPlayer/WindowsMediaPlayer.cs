using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskReceiver.Frontend.MediaPlayer
{
    class WindowsMediaPlayer : MediaPlayer
    {
        public Int32 iHandle { get; set; }

        public WindowsMediaPlayer()
        {
            iHandle = Win32.FindWindow("WMPlayerApp", "Windows Media Player");
        }

        public override void PlayPause()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004978, 0x00000000);
        }

        public override void Stop()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004979, 0x00000000);
        }

        public override void IncreaseVolume()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x0001497F, 0x00000000);
        }

        public override void DecreaseVolume()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00014980, 0x00000000);
        }

        public override void SetVolume(int volume)
        {
            throw new NotImplementedException();
        }

        public override void NextTitle()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x0001497B, 0x00000000);
        }

        public override void PreviouseTitle()
        {
            Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x0001497A, 0x00000000);
        }
    }
}
