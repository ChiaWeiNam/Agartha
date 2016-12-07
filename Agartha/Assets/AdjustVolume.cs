using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour 
{
	public Slider volumeSlider;
	public Slider bgmSlider;
	public Slider sfxSlider;
	public bool ignoreListenerVolume;

	public void VolumeControl(float volumeControl)
	{
		AudioListener.volume = volumeControl;
		PlayerPrefs.SetFloat("CurVol", AudioListener.volume);
		PlayerPrefs.Save();
	}

	public void BgmControl(float volumeControl)
	{
		AudioSource audioSrc = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
		audioSrc.volume = volumeControl;
		PlayerPrefs.SetFloat("BGM Vol",volumeControl );
		PlayerPrefs.Save();
	}

	public void SfxControl(float volumeControl)
	{
		AudioSource audioSrc = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
		audioSrc.ignoreListenerVolume = true;
		audioSrc.volume = volumeControl;
		//AudioListener.volume = volumeControl;
		PlayerPrefs.SetFloat("SFX vol",volumeControl);
		PlayerPrefs.Save();
	}
}
