using System;
using System.IO;
using System.Media;


namespace Part1
{
    public class AudioPlayer
    {
        public void PlayWelcomeAudio()
        {
            try
            {

                //Accessing the file
                string path = AppDomain.CurrentDomain.BaseDirectory;

                using (SoundPlayer player = new SoundPlayer(path.Replace(@"\bin\Debug\",@"\welcome.wav")))
                {
                    // waits until audio finishes
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio Error: " + ex.Message);
            }
        }
    }
}



