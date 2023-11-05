using UnityEngine;
using UnityEngine.Audio;

namespace Microbiopori
{
    public class AudioMixerController : MonoBehaviour
    {
        public AudioMixer audioMixer; // Reference to your Audio Mixer.
        public MainMenu mainMenu;
        public string volumeParameterName = "MasterVolume"; // Use the correct parameter name.

        private bool isMuted = false;

        // Toggle mute on button click or any other event.
        public void ToggleMute()
        {
            isMuted = !isMuted;
            audioMixer.SetFloat(volumeParameterName, isMuted ? -80f : 0f); // -80f is usually mute (low volume).
            
            if(!isMuted)
            {
                mainMenu.audioImage.sprite = mainMenu.audioSprite[0];
            }
            else
            {
                mainMenu.audioImage.sprite = mainMenu.audioSprite[1];
            }
            // You can also store the mute state in a PlayerPrefs or some other way to remember it between sessions.
        }
    }
}

