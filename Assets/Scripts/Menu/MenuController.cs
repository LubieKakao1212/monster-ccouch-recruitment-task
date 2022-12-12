using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private GameObject settingsDefaultSelect;

    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject mainMenuDefaultSelect;

    [SerializeField]
    private EventSystem eventSystem;

    public void StartGame()
    {
        SceneManager.LoadScene(Scenes.GameScene);
    }

    public void DisplaySettings()
    {
        settings.SetActive(true);
        mainMenu.SetActive(false);

        eventSystem.SetSelectedGameObject(settingsDefaultSelect);
    }

    public void HideSettings()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);

        eventSystem.SetSelectedGameObject(mainMenuDefaultSelect);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
