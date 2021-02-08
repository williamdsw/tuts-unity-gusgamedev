using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    // || Inspector References

    [Header("Sound Effects")]
    [SerializeField] private AudioClip bullet;
    [SerializeField] private AudioClip death;

    // || Cached Components

    private AudioSource audioSource;

    public static AudioController Instance { get; private set; }

    // || Properties

    public AudioClip Bullet => bullet;
    public AudioClip Death => death;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    public void Play(AudioClip clip)
    {
        if (clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
