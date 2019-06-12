using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseCollider : MonoBehaviour {

    GameSession gameStatus;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game Over");
        gameStatus = FindObjectOfType<GameSession>();
        gameStatus.destroyScore();
    }
}
