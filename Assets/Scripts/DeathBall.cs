using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class DeathBall : MonoBehaviour
{
    [SerializeField] private AudioSource audiodata = null;
    [SerializeField] private GameObject scoreText = null;
    [SerializeField] private int point= 0;

    // Start is called before the first frame update
    void Start()
    {
        audiodata = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Pacman")
        {
            ScoreManager.scores += point;
            audiodata.Play();
            ShowFloatingText();
            gameObject.GetComponent<Renderer>().enabled = false;
            (gameObject.GetComponent(typeof(SphereCollider)) as Collider).enabled = false;
            gameObject.GetComponent<Behaviour>().enabled = false;
            Destroy(gameObject, audiodata.clip.length + 1f); // Keep + 1f to leave a trail when the floating text shows
        }
        
    }

    void ShowFloatingText()
    {
        var go = Instantiate(scoreText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = point.ToString();
    }
}
