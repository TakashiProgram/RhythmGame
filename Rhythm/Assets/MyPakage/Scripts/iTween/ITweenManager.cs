using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITweenManager : MonoBehaviour
{

    public void ITweenScale(GameObject obj,float scale)
    {
        iTween.ScaleTo(obj, iTween.Hash("x", scale, "y", scale, "z", scale,"time",1.0f));
    }
}
