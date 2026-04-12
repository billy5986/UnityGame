using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluesTrigger : MonoBehaviour
{
    public ChangeUITextTMP changeUITextTMP;
    public AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            audioSource.PlayOneShot(clip);
            changeUITextTMP.FindClues();
            if (audioSource != null)
                Destroy(gameObject, audioSource.clip.length);
            else
                Destroy(gameObject);
        }
    }
}
