using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Recorder;

public class UIController : MonoBehaviour
{
    public GameObject[] scrollPanels;

    public GameObject parentCanvas;

    public GoogleARCore.Examples.HelloAR.HelloARController helloARController;

    public RecordManager recordManager;

    private bool _touch = false;

    public GameObject[] objectPrefabs;

    public GameObject[] recordButtons;

    private void Awake()
    {
        if (helloARController == null)
        {
            helloARController = FindObjectOfType<GoogleARCore.Examples.HelloAR.HelloARController>();
        }
    }

    public void ShowScrollbar(int num)
    {
        switch (num)
        {
            case 0:
                scrollPanels[0].GetComponentInParent<ScrollRect>().content = scrollPanels[0].GetComponent<RectTransform>();
                scrollPanels[0].SetActive(true);
                scrollPanels[1].SetActive(false);
                scrollPanels[2].SetActive(false);
                break;

            case 1:
                scrollPanels[1].GetComponentInParent<ScrollRect>().content = scrollPanels[1].GetComponent<RectTransform>();
                scrollPanels[0].SetActive(false);
                scrollPanels[1].SetActive(true);
                scrollPanels[2].SetActive(false);
                break;

            case 2:
                //scrollPanels[2].GetComponentInParent<ScrollRect>().content = scrollPanels[1].GetComponent<RectTransform>();
                scrollPanels[0].SetActive(false);
                scrollPanels[1].SetActive(false);
                scrollPanels[2].SetActive(true);
                break;
        }
    }

    public void StartVid()
    {
        recordManager.StartRecord();
        recordButtons[0].SetActive(false);
        recordButtons[1].SetActive(true);
    }

    public void SvaeVid()
    {
        recordManager.StopRecord();
        recordButtons[0].SetActive(true);
        recordButtons[1].SetActive(false);
    }

    //public void StartRecordButton()
    //{
    //    GLinkRecord.sharedInstance().startRecord();
    //}

    //public void StopRecordButton()
    //{
    //    GLinkRecord.sharedInstance().stopRecord();
    //}

    //private void Awake()
    //{
    //    if (buttonList.Length != 0)
    //    {
    //        for (int i = 0; i < objectPrefab.Length; i++)
    //        {
    //            var buttoninfo = buttonList[i].AddComponent<ButtonInfo>();
    //            //var buttonInfo = buttonList[i].transform.GetComponent<ButtonInfo>();
    //            buttoninfo.ButtonNum = i;
    //            //var button = buttoninfo.transform.GetComponent<Button>();
    //            ////SelectNum = i;
    //            //button.onClick.AddListener(delegate { SelectButton(i); });
    //            //Debug.LogFormat("{0} {1}", buttoninfo.ButtonNum, i);
    //        }
    //    }
    //}

    private bool Touch
    {
        get { return this._touch; }
        set { this._touch = Touch; }
    }

    //private void Touching()
    //{
    //    if (Touch == false)
    //    {
    //    }
    //}

    public void SelectButton(int num)
    {
        helloARController._selectPrefab = objectPrefabs[num];
        Debug.LogFormat("{0}번째 버튼이 실행되었습니다.", num);
    }

    //public void CurrentArrayremoveButton()
    //{
    //    var infocont = helloARController.InfoCount;

    //    if (infocont >= 0)
    //    {
    //        var tmpInfo = helloARController.objectInfos[infocont - 1];

    //        helloARController.InfoCount = infocont - 1;

    //        Destroy(tmpInfo.gameObject);
    //    }
    //}
}