using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskServ_Backend;

namespace TaskServ_Frontend
{
    class CommandMusicStartStop : Command
    {
        private WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
        private System.Int32 iHandle;

        public CommandMusicStartStop(string trigger) : base(trigger) { }

        public override void Execute(List<Tuple<string, string>> param)
        {
            iHandle = Win32.FindWindow("WMPlayerApp", "Windows Media Player");
            PlayPause(Convert.ToInt32(param[0].Item2));
        }

        public void PlayPause(int Status)
        {
            switch (Status)
            {
                case 0:
                    //wmp.URL = @"D:\Music\ERB\Barack_Obama_vs_Mitt_Romney_Epic_Rap_Battles_Of_History_Season_2.mp3";
                    break;
                case 1:
                    //wmp.controls.play();
                    Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004978, 0x00000000);
                    break;
                case 2:
                    //wmp.controls.pause();
                    Win32.SendMessage(iHandle, Win32.WM_COMMAND, 0x00004979, 0x00000000);
                    break;
            }
        }

       
    }
}
