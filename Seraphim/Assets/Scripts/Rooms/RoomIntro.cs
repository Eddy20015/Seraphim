using System.Collections;
using TMPro;
using UnityEngine;

public class RoomIntro : RoomAbstract
{

    [SerializeField] private GameObject[] mainMenu;
    [SerializeField] private RoomTrigger menuTrigger;
    [SerializeField] private Transform playerStartTransform;
    [SerializeField] private Transform playerDialogueTransform;
    [SerializeField] private GameObject seraph;
    [SerializeField] private GameObject player;
    [SerializeField] private float moveDuration = 5.0f;

    private bool FirstFrame = true;
    private CharacterController cc;

    public enum INTROROOMSTATE
    {
        START,
        MENU,
        DIALOGUE
    }

    private INTROROOMSTATE state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    override protected void Start()
    {
        roomType = RoomManager.ROOMTYPE.INTRO;
        menuTrigger.triggerDelegateVoid += ActivateMenu;

        cc = player.GetComponent<CharacterController>();

        base.Start();
    }

    // Update is called once per frame
    override protected void Update()
    {
        if(FirstFrame)
        {
            FirstFrame = false;
            GameStateManager.Play();
            //StartCoroutine(Intro());
        }

        if (state == INTROROOMSTATE.MENU && !mainMenu[0].activeInHierarchy) 
        {
            EnterDialogue();
        }
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(3f);
        GameStateManager.Play();
    }

    override protected void Begin()
    {
        state = INTROROOMSTATE.START;
    }

    override protected void End()
    {
        //SHOULD HAVE VARIABLE TO CHOOSE WHICH ROOM IS NEXT
        RoomManager.EndRoom("SampleScene");
    }

    private void ActivateMenu()
    {
        //state = INTROROOMSTATE.MENU;
        GameStateManager.MainMenu();
        StartCoroutine(PositionPlayer());
    }

    private IEnumerator PositionPlayer()
    {
        cc.enabled = false;

        Vector3 startPosition = player.transform.position;
        Quaternion startRotation = player.transform.rotation;
        Quaternion endRotation = Quaternion.LookRotation(seraph.transform.position);
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            // Calculate the interpolation factor (0 to 1)
            float t = elapsedTime / moveDuration;

            // Use Vector3.Lerp for smooth interpolation between start and target positions
            player.transform.position = Vector3.Lerp(startPosition, playerDialogueTransform.position, t);

            // Smoothly interpolate between the start and end rotations
            player.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

            // Increment elapsed time by the time since the last frame
            elapsedTime += Time.deltaTime;

            // Yield to the next frame
            yield return null;
        }

        yield return new WaitForSeconds(1);
        state = INTROROOMSTATE.MENU;
        foreach(GameObject item in mainMenu)
        {
            item.SetActive(true);
        }
        cc.enabled = true;
    }

    private void EnterDialogue()
    {
        state = INTROROOMSTATE.DIALOGUE;
        RoomManager.ActivateFungus(startingBlock);
    }
}
