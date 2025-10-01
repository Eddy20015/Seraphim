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
        //Seraphim specific, as menu will pop up after player begins the game immediately
        ActivateMenu(false);
    }

    /************************************
     * 
     * GENERAL MENU FUNCTIONALITY
     * 
     ************************************/
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
        //UISounds.PlayOneShot(ClickSound);
    }

    /************************************
    * 
    * SERAPHIM SPECIFIC MENU FUNCTIONALITY
    * 
    ************************************/

    [SerializeField] private TitleLetter[] titleLetters;
    [SerializeField] private float titleSpeed = 5.0f;
    [SerializeField] private float titleOffsetX = -0.6f;
    [SerializeField] private float titleOffsetY = -0.5f;
    [SerializeField] private int titleLength = 6;

    private float titleTop;
    private float titleBottom;
    private float letterSpacing;

    public void Start()
    {
        int screenWidth = Screen.currentResolution.width / 2;
        int screenHeight = Screen.currentResolution.height / 2;
        int currLetter = 0;
        float centerLetter = (titleLength - 1) * 0.5f;
    
        foreach(TitleLetter titleLetter in titleLetters)
        {
            RectTransform letterTransform = titleLetter.GetComponent<RectTransform>();
            letterTransform.localPosition = new Vector3(titleOffsetX * screenWidth, (centerLetter - currLetter) / (centerLetter - titleOffsetY) * screenHeight);
            
            if(currLetter == 0 && titleLetters.Length != 0)
            {
                letterSpacing = letterTransform.localPosition.y - ((centerLetter - (currLetter + 1)) / (centerLetter - titleOffsetY) * screenHeight);
                titleTop = letterTransform.localPosition.y + letterSpacing;
                titleBottom = letterTransform.localPosition.y - letterSpacing * (titleLetters.Length - 1);
                titleLetter.Debug = true;
            }

            titleLetter.Init(titleTop, titleBottom, titleSpeed);
            print(letterTransform.localPosition + "    " + letterSpacing);
            currLetter++;
        }
    }

    private void ActivateMenu(bool active)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(active);
        }
    }
}
