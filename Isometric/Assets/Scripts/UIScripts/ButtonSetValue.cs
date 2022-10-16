using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSetValue : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    public string valueToSet;
    public float setValue;
    public string scriptName;
    public GameObject[] objectsToApplyOn;
    public bool xComp;
    public bool yComp;
    public bool toggleActive;
    public bool toggleBool;
    public bool isInt;
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        foreach (GameObject obj in objectsToApplyOn)
        {
            var sc = (obj.GetComponent(scriptName) as MonoBehaviour);
            if (toggleActive)
            {
                if(obj.activeSelf)
                    obj.SetActive(false);
                else
                    obj.SetActive(true);
            }
            else if (toggleBool)
            {
                if ((bool)sc.GetType().GetField(valueToSet).GetValue(sc))
                    sc.GetType().GetField(valueToSet).SetValue(sc, false);
                else
                    sc.GetType().GetField(valueToSet).SetValue(sc, true);
            }
            else if (xComp)
                sc.GetType().GetField(valueToSet).SetValue(sc, new Vector2(setValue, ((Vector2)sc.GetType().GetField(valueToSet).GetValue(sc)).y));
            else if (yComp)
                sc.GetType().GetField(valueToSet).SetValue(sc, new Vector2(((Vector2)sc.GetType().GetField(valueToSet).GetValue(sc)).x, setValue));
            else if(isInt)
                sc.GetType().GetField(valueToSet).SetValue(sc, (int)setValue);
            else
                sc.GetType().GetField(valueToSet).SetValue(sc, setValue);
        }
    }
}
