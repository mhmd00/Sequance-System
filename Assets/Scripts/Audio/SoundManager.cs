using UnityEngine;



public class SoundManager : Singletone<SoundManager>
{
    public Sound[] sounds;

    private void Start()
    {
        InitializeAudioSources();
    }

    private void InitializeAudioSources()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.loop = sound.loop;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    public void PlaySound(SoundEffect soundEffect)
    {
        Sound sound = FindSoundByEnum(soundEffect);
        if (sound == null)
        {
            return;
        }

        sound.source.Play();
    }

    public AudioClip GetSoundEffectClipByEnum(SoundEffect soundEffect)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name == soundEffect.ToString())
            {
                return sound.clip;
            }
        }
        return null;
    }
    public void PlayMusic(MusicTrack musicTrack)
    {
        Sound sound = FindSoundByEnum(musicTrack);
        if (sound == null)
        {
            return;
        }

        sound.source.Play();
    }

    public void StopSound(SoundEffect soundEffect)
    {
        Sound sound = FindSoundByEnum(soundEffect);
        if (sound == null)
        {
            return;
        }

        sound.source.Stop();
    }

    public void StopMusic(MusicTrack musicTrack)
    {
        Sound sound = FindSoundByEnum(musicTrack);
        if (sound == null)
        {
            return;
        }

        sound.source.Stop();
    }

    private Sound FindSoundByEnum(System.Enum soundEnum)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name == soundEnum.ToString())
            {
                return sound;
            }
        }

        return null;
    }
}

