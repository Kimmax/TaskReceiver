using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskServ_Backend;

namespace TaskServ_Frontend
{
    class CommandMusicStartStop : Command
    {
        private MediaPlayer.MediaPlayer player = new MediaPlayer.WindowsMediaPlayer();

        public CommandMusicStartStop(string trigger) : base(trigger) { }

        public override void Execute(List<Tuple<string, string>> param)
        {
            switch(param[0].Item1)
            {
                case "playpause":
                {
                    player.PlayPause();
                    break;
                }
                case "stop":
                {
                    player.Stop();
                    break;
                }
                case "next":
                {
                    player.NextTitle();
                    break;
                }
                case "prev":
                {
                    player.PreviouseTitle();
                    break;
                }
                case "louder":
                {
                    player.IncreaseVolume();
                    break;
                }
                case "quieter":
                {
                    player.DecreaseVolume();
                    break;
                }
            }
        }
    }
}
