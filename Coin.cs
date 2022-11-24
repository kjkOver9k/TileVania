using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coinpoint;
    [SerializeField] AudioClip audio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
        FindObjectOfType<GameSession>().whenCoinIsPicked(coinpoint);
                Destroy(gameObject);
    }

}
