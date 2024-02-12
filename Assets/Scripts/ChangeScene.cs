using System.Collections;
using UnityEngine;


public class ChangeScene : MonoBehaviour
{
    public Animator CanvasAnim;

    void Start()
    {
        StartCoroutine(AnimationController());
    }


    IEnumerator AnimationController()
    {
        yield return new WaitForSeconds(72f);

        CanvasAnim.Play("CanvasAnim");
    }
}
