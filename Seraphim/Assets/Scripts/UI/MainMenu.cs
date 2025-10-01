using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string GameSceneName;
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private AudioClip ClickSound;
    [SerializeField] private AudioSource UISounds;

    public void Awake()
    {
        gameObject.SetActive(true);
    }

    public void OnClickStart()
    {
        PlayClickSound();
        GameStateManager.Start(GameSceneName);
    }

    public void OnClickOptions()
    {
        PlayClickSound();
        gameObject.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void OnClickQuit()
    {
        PlayClickSound();
        Application.Quit();
    }

    public void PlayClickSound()
    {
        UISounds.PlayOneShot(ClickSound);
    }
}
