using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    private void OnEnable()
    {
        InputManager.Instance.ExitRaw += Exit;
    }

    private void OnDisable()
    {
        InputManager.Instance.ExitRaw -= Exit;
    }

    private void Exit()
    {
        SceneManager.LoadScene(Scenes.MenuScene);
    }
}
