using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundTouch
{
    public class SoundPlayer : IDisposable
    {
        private IWavePlayer wavePlayer;
        private VarispeedSampleProvider speedControl;
        private AudioFileReader reader;

        public SoundPlayer() { }

        public TimeSpan CurrentTime
        {
            get { return reader.CurrentTime; }
            set
            {
                reader.CurrentTime = value;
                speedControl.Reposition();
            }
        }

        public float Rate
        {
            get { return speedControl.PlaybackRate; }
            set { speedControl.PlaybackRate = value; }
        }

        public void Load(string path)
        {
            reader?.Dispose();
            speedControl?.Dispose();
            reader = null;
            speedControl = null;
            reader = new AudioFileReader(path);
            speedControl = new VarispeedSampleProvider(reader, 100, new SoundTouchProfile(true, false));
        }

        public void Play()
        {
            if (wavePlayer == null)
                wavePlayer = new WaveOutEvent();
            if (speedControl == null)
                return;
            wavePlayer.Init(speedControl);
            wavePlayer.Play();
        }

        public void Pause()
        {
            wavePlayer?.Stop();
        }

        public void Dispose()
        {
            wavePlayer?.Dispose();
            speedControl?.Dispose();
            reader?.Dispose();
        }
    }
}
