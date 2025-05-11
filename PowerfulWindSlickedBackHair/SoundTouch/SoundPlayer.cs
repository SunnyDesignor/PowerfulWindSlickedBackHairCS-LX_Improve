using NAudio.Wave;
using System;

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
            get 
            { 
                if(reader == null) { return TimeSpan.Zero; }
                return reader.CurrentTime;
            }
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
            if(reader != null) { reader.Dispose(); }
            if(speedControl != null) { speedControl.Dispose(); }
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
            if(wavePlayer != null) { wavePlayer.Stop(); }
        }

        public void Dispose()
        {
            if(wavePlayer != null) { wavePlayer.Dispose(); }
            if(speedControl != null) { speedControl.Dispose(); }
            if(reader != null) { reader.Dispose(); }
        }
    }
}
