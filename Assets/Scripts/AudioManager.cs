using System.Collections;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public void PlaySoundEffect(AudioClip clip, AudioSource source)
    {
        if (source != null)
        {
            source.PlayOneShot(clip);
        }
        else
        {
            source = gameObject.AddComponent<AudioSource>();
            source.spatialBlend = 1.0f;
            source.PlayOneShot(clip);

            StartCoroutine(RemoveAudioSourceComponent(source, clip.length));
        }
    }

    private IEnumerator RemoveAudioSourceComponent(AudioSource source, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(source);
    }
}
