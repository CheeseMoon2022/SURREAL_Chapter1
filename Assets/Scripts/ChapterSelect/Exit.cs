using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnMouseDown()
    {
        Back_Quit._Ins.exit();
    }
}
