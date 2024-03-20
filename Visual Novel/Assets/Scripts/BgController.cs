using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgController : MonoBehaviour
{
    public bool isSwitched = false;
    public Image bg1;
    public Image bg2;
    public Animator animator;

    public void SwitchImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            bg1.sprite = sprite;
            animator.SetTrigger("SwitchSecond");
        }
        else
        {
            bg2.sprite = sprite;
            animator.SetTrigger("SwitchFirst");
        }
        isSwitched = !isSwitched;
    }

    public void SetImg(Sprite sprite)
    {
        if (!isSwitched)
        {
            bg2.sprite = sprite;
        }
        else
        {
            bg1.sprite = sprite;
        }
    }
}
