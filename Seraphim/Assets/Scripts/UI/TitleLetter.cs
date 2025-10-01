using UnityEngine;

public class TitleLetter : MonoBehaviour
{
    private float titleTop;
    private float titleBottom;
    private float titleSpeed;

    public bool Debug = false;

    private RectTransform titleRectTransform;

    public void Init(float top, float bottom, float speed)
    { 
        titleTop = top;
        titleBottom = bottom;
        titleSpeed = speed;

        titleRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Debug)
        {
            print(titleRectTransform.localPosition + " " + titleTop + " " + titleBottom);
        }
        titleRectTransform.localPosition += new Vector3(0, Time.deltaTime * titleSpeed);

        if(titleRectTransform.localPosition.y >= titleTop)
        {
            SendToBottom();
        }
    }

    private void SendToBottom()
    {
        titleRectTransform.localPosition = new Vector3(titleRectTransform.localPosition.x, titleBottom);
    }
}
