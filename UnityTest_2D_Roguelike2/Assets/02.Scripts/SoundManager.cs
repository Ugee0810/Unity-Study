using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;

    public float lowPitchRange  = .95f;
    public float highPitchRange = 1.05f;

    public static SoundManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;

        efxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIdx = Random.Range(0, clips.Length);

        float randomPitch = Random.Range(lowPitchRange, highPitchRange); // 음역대

        efxSource.pitch = randomPitch;

        efxSource.clip = clips[randomIdx];

        efxSource.Play();
    }
}
