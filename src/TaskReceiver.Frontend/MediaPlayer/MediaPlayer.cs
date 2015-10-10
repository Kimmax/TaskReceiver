using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskServ_Frontend.MediaPlayer
{
    abstract class MediaPlayer
    {
        public abstract void PlayPause();
        public abstract void Stop();
        public abstract void IncreaseVolume();
        public abstract void DecreaseVolume();
        public abstract void SetVolume(int volume);
        public abstract void NextTitle();
        public abstract void PreviouseTitle();
    }
}
