using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    bool buildmenuopen = false;
    [SerializeField]Button buildbutton;
    public void Buildbutton()
    {
        RectTransform rectTransform = buildbutton.GetComponent<RectTransform>();

        if (buildmenuopen == true)
        {
            rectTransform.anchoredPosition = new Vector3(-35, -35, 0);
            buildmenuopen = false;
        }
        else if (buildmenuopen == false)
        {
            rectTransform.anchoredPosition = new Vector3(-105, -35, 0);
            buildmenuopen = true;
        }
    }
    public void arrowtower()
    {
        if (buildman._instance.buildmode != 1)
        {
            buildman._instance.buildmode = 1;
        }
    }
    public void litning()
    {
       if (buildman._instance.buildmode != 2)
       {
            buildman._instance.buildmode = 2;
       }
    }
    public void Fireball()
    {
        if (buildman._instance.buildmode != 3)
        {
            buildman._instance.buildmode = 3;
        }
    }

}
