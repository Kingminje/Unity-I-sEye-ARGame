using UnityEngine;

public class ButtonInfo : MonoBehaviour
{
    [SerializeField]
    private int _butoonNum = 0;

    public int ButtonNum
    {
        get { return this._butoonNum; }
        set { this._butoonNum = value; }
    }
}