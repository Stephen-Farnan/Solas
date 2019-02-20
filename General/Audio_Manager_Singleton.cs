using System.Collections;
using UnityEngine;

public class Audio_Manager_Singleton : GenericSingleton<Audio_Manager_Singleton>
{
    public AudioSource windAudioSource;
    public AudioSource musicAudioSource;
    [HideInInspector]
    public bool isFading = false;
    private float oldWindVolume = 0;
    private float oldMusicVolume = 0;
    private float oldBlend;
    public float fadeSpeed = 0.05f;
    public AudioClip[] musicTracks;
    public enum AudioSourceType { wind, music }

    public void SetSpatialBlend(float spatial3D)
    {
        StartCoroutine(SetSpatialBlendIEnumerator(spatial3D));
    }

    public void SetAudioVolume(float volume, AudioSourceType audioSourceType)
    {
        StartCoroutine(SetVolumeIEnumerator(volume, audioSourceType));
    }

    public IEnumerator ChangeMusicTrack(AudioClip audioclip, float volume)
    {
        StartCoroutine(SetVolumeIEnumerator(0, AudioSourceType.music));
        while (musicAudioSource.volume > 0)
        {
            yield return new WaitForSeconds(0.1f);
        }
        musicAudioSource.clip = audioclip;
        if (audioclip == musicTracks[6])
        {
            musicAudioSource.loop = false;
        }
        else
        {
            musicAudioSource.loop = true;
        }
        musicAudioSource.Play();
        StartCoroutine(SetVolumeIEnumerator(volume, AudioSourceType.music));
    }

    IEnumerator SetVolumeIEnumerator(float newVolume, AudioSourceType audioSourceType)
    {
        AudioSource audioSource;
        switch (audioSourceType)
        {
            case AudioSourceType.wind:
                audioSource = windAudioSource;
                break;
            case AudioSourceType.music:
                audioSource = musicAudioSource;
                break;
            default:
                audioSource = windAudioSource;
                break;
        }
        float oldVolume;
        if (audioSourceType == AudioSourceType.wind)
        {
            oldVolume = oldWindVolume;
        }
        else
        {
            oldVolume = oldMusicVolume;
        }
        oldVolume = audioSource.volume;
        float volumeChange = Mathf.Abs(newVolume - oldVolume) * fadeSpeed;

        if (oldVolume < newVolume)
        {
            while (audioSource.volume < newVolume)
            {
                if (audioSource.volume + volumeChange > newVolume)
                {
                    audioSource.volume = newVolume;
                }
                else
                {
                    audioSource.volume += volumeChange;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
        else
        {
            while (audioSource.volume > newVolume)
            {
                if (audioSource.volume - volumeChange < newVolume)
                {
                    audioSource.volume = newVolume;
                }
                else
                {
                    audioSource.volume -= volumeChange;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }

    IEnumerator SetSpatialBlendIEnumerator(float newBlend)
    {
        oldBlend = windAudioSource.spatialBlend;
        if (oldBlend < newBlend)
        {
            while (windAudioSource.spatialBlend < newBlend)
            {
                windAudioSource.spatialBlend += Mathf.Abs(newBlend - oldBlend) * fadeSpeed;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            while (windAudioSource.spatialBlend > newBlend)
            {
                windAudioSource.spatialBlend -= Mathf.Abs(newBlend - oldBlend) * fadeSpeed;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
