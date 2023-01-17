using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalZone : MonoBehaviour
{
    [SerializeField] private AudioClip onGoalSound;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            AudioManager.Instance.PlaySound(onGoalSound);
            GameManager.Instance.LoadNextScene();
        }
    }

}
