﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AudioClipID
{
	BGM_MAINMENU = 0,
	BGM_LEVEL00_01 = 1,
	BGM_LEVEL02 = 2,
	BGM_LEVEL03_04 = 3,
	BGM_TEAMNAME = 4,
	
	SFX_HOVER = 100,
	SFX_CLICKING = 101,
	SFX_WINNING = 102,
	SFX_FIRESOUND = 103,
	SFX_ICESOUND = 104,
	SFX_AXESOUND = 105,
	SFX_SPIKESOUND = 106,
	SFX_LOGSOUND = 107,
	SFX_ARROWSOUND = 108,
	SFX_BOOMSOUND = 109,

	TOTAL
}

[System.Serializable]
public class AudioClipInfo
{
	public AudioClipID audioClipID;
	public AudioClip audioClip;
}


public class SoundManagerScript : MonoBehaviour 
{
	private static SoundManagerScript mInstance;
	
	public static SoundManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				if(GameObject.FindWithTag("SoundManager") != null)
				{
					mInstance = GameObject.FindWithTag("SoundManager").GetComponent<SoundManagerScript>();
				}
				else 
				{
					GameObject obj = new GameObject("_SoundManager");
					mInstance = obj.AddComponent<SoundManagerScript>();
				}
				//!DontDestroyOnLoad(obj);
			}
			return mInstance;
		}
	}

	public float bgmVolume = 1.0f;
	public float sfxVolume = 1.0f;

	
	public List<AudioClipInfo> audioClipInfoList = new List<AudioClipInfo>();
	
	public AudioSource bgmAudioSource;
	public AudioSource sfxAudioSource;
	
	public List<AudioSource> sfxAudioSourceList = new List<AudioSource>();
	public List<AudioSource> bgmAudioSourceList = new List<AudioSource>();

	// Use this for initialization
	void Awake () 
	{
		AudioSource[] audioSourceList = this.GetComponentsInChildren<AudioSource>();
		
		if(audioSourceList[0].gameObject.name == "BGMAudioSource")
		{
			bgmAudioSource = audioSourceList[0];
			sfxAudioSource = audioSourceList[1];
		}
		else 
		{
			bgmAudioSource = audioSourceList[1];
			sfxAudioSource = audioSourceList[0];
		}
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
	
	AudioClip FindAudioClip(AudioClipID audioClipID)
	{
		for(int i=0; i<audioClipInfoList.Count; i++)
		{
			if(audioClipInfoList[i].audioClipID == audioClipID)
			{
				return audioClipInfoList[i].audioClip;
			}
		}

		Debug.LogError("Cannot Find Audio Clip : " + audioClipID);

		return null;
	}
	
	//! BACKGROUND MUSIC (BGM)
	public void PlayBGM(AudioClipID audioClipID)
	{
		bgmAudioSource.clip = FindAudioClip(audioClipID);
		Debug.Log (audioClipID);
		bgmAudioSource.volume = bgmVolume;
		bgmAudioSource.loop = true; 
		bgmAudioSource.Play();
	}
	
	public void PauseBGM()
	{
		if(bgmAudioSource.isPlaying)
		{
			bgmAudioSource.Pause();
		}
	}
	
	public void StopBGM()
	{
		if(bgmAudioSource.isPlaying)
		{
			bgmAudioSource.Stop();
		}
	}

	public void PlayLoopingBGM(AudioClipID audioClipID)
	{
		AudioClip clipToPlay = FindAudioClip(audioClipID);

		for(int i=0; i<bgmAudioSourceList.Count; i++)
		{
			if(bgmAudioSourceList[i].clip == clipToPlay)
			{
				if(bgmAudioSourceList[i].isPlaying)
				{
					return;
				}

				bgmAudioSourceList[i].volume = sfxVolume;
				bgmAudioSourceList[i].Play();
				return;
			}
		}

		AudioSource newInstance = gameObject.AddComponent<AudioSource>();
		newInstance.clip = clipToPlay;
		newInstance.volume = sfxVolume;
		newInstance.loop = true;
		newInstance.Play();
		bgmAudioSourceList.Add(newInstance);
	}

	public void PauseLoopingBGM(AudioClipID audioClipID)
	{
		AudioClip clipToPause = FindAudioClip(audioClipID);

		for(int i=0; i<bgmAudioSourceList.Count; i++)
		{
			if(bgmAudioSourceList[i].clip == clipToPause)
			{
				bgmAudioSourceList[i].Pause();
				return;
			}
		}
	}


	public void StopLoopingBGM(AudioClipID audioClipID)
	{
		AudioClip clipToStop = FindAudioClip(audioClipID);

		for(int i=0; i<bgmAudioSourceList.Count; i++)
		{
			if(bgmAudioSourceList[i].clip == clipToStop)
			{
				bgmAudioSourceList[i].Stop();
				return;
			}
		}
	}

	
	//! SOUND EFFECTS (SFX)
	public void PlaySFX(AudioClipID audioClipID)
	{
		sfxAudioSource.PlayOneShot(FindAudioClip(audioClipID), sfxVolume);
	}
	
	public void PlayLoopingSFX(AudioClipID audioClipID)
	{
		AudioClip clipToPlay = FindAudioClip(audioClipID);
		
		for(int i=0; i<sfxAudioSourceList.Count; i++)
		{
			if(sfxAudioSourceList[i].clip == clipToPlay)
			{
				if(sfxAudioSourceList[i].isPlaying)
				{
					return;
				}

				sfxAudioSourceList[i].volume = sfxVolume;
				sfxAudioSourceList[i].Play();
				return;
			}
		}
		
		AudioSource newInstance = gameObject.AddComponent<AudioSource>();
		newInstance.clip = clipToPlay;
		newInstance.volume = sfxVolume;
		newInstance.loop = true;
		newInstance.Play();
		sfxAudioSourceList.Add(newInstance);
	}
	
	public void PauseLoopingSFX(AudioClipID audioClipID)
	{
		AudioClip clipToPause = FindAudioClip(audioClipID);
		
		for(int i=0; i<sfxAudioSourceList.Count; i++)
		{
			if(sfxAudioSourceList[i].clip == clipToPause)
			{
				sfxAudioSourceList[i].Pause();
				return;
			}
		}
	}
	
	
	public void StopLoopingSFX(AudioClipID audioClipID)
	{
		AudioClip clipToStop = FindAudioClip(audioClipID);
		
		for(int i=0; i<sfxAudioSourceList.Count; i++)
		{
			if(sfxAudioSourceList[i].clip == clipToStop)
			{
				sfxAudioSourceList[i].Stop();
				return;
			}
		}
	}
	
	public void SetBGMVolume(float value)
	{
		bgmVolume = value;
	}
	
	public void SetSFXVolume(float value)
	{
		sfxVolume = value;
	}
}