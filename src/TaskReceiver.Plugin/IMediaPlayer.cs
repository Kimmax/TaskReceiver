using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskReceiver.Plugin
{
    public interface IMediaPlayer : ITaskReciverPlugin
    {
        void PlayPause();
        void Stop();
        void IncreaseVolume();
        void DecreaseVolume();
        void SetVolume(int volume);
        void NextTitle();
        void PreviouseTitle();
    }
}
