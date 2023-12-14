using UnityEngine;

public class ObjectWillHitScript : MonoBehaviour
{
    // public bool willHitCentipede = true;

    [SerializeField] private AudioClip boom;
    [SerializeField] private Color[] colours;

    private AudioSource audioSource;
    private MeshRenderer meshRenderer;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start() {
        meshRenderer.material.color = RandomColour();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(boom);
            }
        }
    }

    private Color RandomColour() {
        int r = Random.Range(0, colours.Length);

        return colours[r];
    }
}
