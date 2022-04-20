using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    public GameObject levelSelectPanel;

    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            levelSelectPanel.SetActive(!levelSelectPanel.activeSelf);
        });
    }

}
