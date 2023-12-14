using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager Instance;

    [SerializeField] private AudioClip mousePressed;
    [SerializeField] private AudioClip mouseHover;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMouseHoverAudio()
    {
        audioSource.PlayOneShot(mouseHover);
    }

    public void PlayMousePressedAudio()
    {
        audioSource.PlayOneShot(mousePressed);
    }
}
