using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly!");
                break;
            case "Finish":
                Debug.Log("Congrats, yo, you finished!");
                break;
            case "Fuel":
                Debug.Log("You picked up fuel.");
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
