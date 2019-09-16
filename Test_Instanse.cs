using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Instanse : MonoBehaviour
{
    public GameObject Test_prefab;

    public Info _currentInfo = null;

    public UIController uIController;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject prefab;
            prefab = Test_prefab;

            // Instantiate Andy model at the hit pose.
            var andyObject = Instantiate(prefab, transform.position, transform.rotation);

            // Compensate for the hitPose rotation facing away from the raycast (i.e. camera).
            andyObject.transform.Rotate(0, 0f, 0, Space.Self);

            // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
            // world evolves.
            var anchor = transform;

            // Make Andy model a child of the anchor.
            andyObject.transform.parent = anchor.transform;

            if (_currentInfo == null)
            {
                var newInfo = andyObject.AddComponent<Info>();
                newInfo.regenInfo = newInfo;
                newInfo.nextInfo = null;
                _currentInfo = newInfo;
            }
            else
            {
                var newInfo = andyObject.AddComponent<Info>();

                ChangeTwoInfo(ref _currentInfo, ref newInfo);

                _currentInfo = newInfo;
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (_currentInfo != null)
            {
                CurrentArrayremoveButton();
            }
        }
    }

    private void ChangeTwoInfo(ref Info currentInfo, ref Info newInfo)
    {
        currentInfo.nextInfo = newInfo;

        newInfo.regenInfo = _currentInfo;

        newInfo.nextInfo = null;
    }

    public void CurrentArrayremoveButton()
    {
        for (int i = 0; i < 100; i++)
        {
            if (_currentInfo.nextInfo == null)
            {
                var destoraerObject = _currentInfo.gameObject;

                _currentInfo = _currentInfo.regenInfo;
                _currentInfo.nextInfo = null;

                Destroy(destoraerObject);

                return;
            }
            else
            {
                _currentInfo = _currentInfo.regenInfo;
            }
        }
    }

    //public void CurrentArrayremoveButton()
    //{
    //    var infocont = this.infoCount;

    //    if (infocont >= 0)
    //    {
    //        var tmpInfo = objectInfos[infocont];

    //        for (int i = 0; i < infocont; i++)
    //        {
    //            if (objectInfos[infocont - i] != null && objectInfos[infocont - i].transform != null)
    //            {
    //                this.infoCount = infocont - i;

    //                Destroy(objectInfos[infoCount].gameObject);
    //                return;
    //            }
    //        }
    //    }
    //}
}