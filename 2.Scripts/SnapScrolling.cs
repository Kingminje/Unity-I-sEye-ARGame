using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    // to hold the ScrollPanel
    public RectTransform panel;

    public Button[] bttn;

    // center to compare the distance for each button
    public RectTransform center;

    public int startButton = 1;

    // all buttons distance to the center
    public float[] distance;

    public float[] distReposition;

    // will be true, while we drag the panel
    private bool dragging = false;

    // will hold the distance between the buttons
    private int btnDistance;

    // to hold the number of the button, with smallest
    private int minButtonNum;

    private int btnLength;
    private bool messageSend = false;
    private float lerpSpeed = 5f;
    private bool targetNearestButton = true;

    private void Start()
    {
        btnLength = bttn.Length;
        distance = new float[btnLength];
        distReposition = new float[btnLength];

        // get distance between buttons
        btnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);

        panel.anchoredPosition = new Vector2((startButton - 1) * -250, 0f);
    }

    private void Update()
    {
        for (int i = 0; i < bttn.Length; i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - bttn[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(distReposition[i]);

            //if (distReposition[i] > 1000)
            //{
            //    float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
            //    float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

            //    Vector2 newAnchoredPos = new Vector2(curX + (btnLength * btnDistance), curY);
            //    bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            //}

            //if (distReposition[i] < -1000)
            //{
            //    float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
            //    float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

            //    Vector2 newAnchoredPos = new Vector2(curX - (btnLength * btnDistance), curY);
            //    bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            //}
        }

        if (targetNearestButton)
        {
            // get the min distance
            float minDistance = Mathf.Min(distance);

            for (int a = 0; a < bttn.Length; a++)
            {
                if (minDistance == distance[a])
                {
                    minButtonNum = a;
                    //Debug.Log(bttn[minButtonNum].name);
                }
            }
        }

        if (bttn[0].GetComponent<RectTransform>().position.x > panel.anchorMin.x)
        {
            GoToButton(startButton);
        }
        else if (bttn[btnLength - 1].GetComponent<RectTransform>().position.x < Screen.width)
        {
            GoToButton(btnLength - 4);
        }

        if (!dragging)
        {
            //LerpToBtn(minButtonNum * -btnDistance);
            LerpToBtn(-bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
        }
    }

    private void LerpToBtn(float position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * lerpSpeed);

        if (Mathf.Abs(position - newX) < 3f)
        {
            newX = position;
        }

        if (Mathf.Abs(newX) >= Mathf.Abs(position) - 1f && Mathf.Abs(newX) <= Mathf.Abs(position) + 1 && !messageSend)
        {
            messageSend = true;
            SendMessageFromButton(minButtonNum);
        }
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    private void SendMessageFromButton(int btnIndex)
    {
        if (btnIndex - 1 == 3)
            Debug.Log("Msg Send");
    }

    public void StartDrag()
    {
        messageSend = false;
        lerpSpeed = 5f;
        dragging = true;

        targetNearestButton = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }

    public void GoToButton(int buttonIndex)
    {
        // stop Lerping to the nearest button
        targetNearestButton = false;
        minButtonNum = buttonIndex;
    }
}