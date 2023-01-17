using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalZone : MonoBehaviour
{
    public UnityEvent onGoal;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {

            onGoal.Invoke();
            GameManager.Instance.LoadNextScene();
        }
    }

}
