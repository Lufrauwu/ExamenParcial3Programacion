using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStars : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        ScoreManager.instance.AddPoint();
    }
}