using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeathBall : MonoBehaviour
{
    [SerializeField] private AudioSource audiodata;

    // Start is called before the first frame update
    void Start()
    {
        audiodata = GetComponent<AudioSource>();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Pacman")
        {
            audiodata.Play();
            gameObject.GetComponent<Renderer>().enabled = false;
            (gameObject.GetComponent(typeof(SphereCollider)) as Collider).enabled = false;
            gameObject.GetComponent<Behaviour>().enabled = false;
            Destroy(gameObject, audiodata.clip.length);
        }
        
    }
}
