using System.Collections;
using UnityEngine;

public class ChekcScript : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        yield return new WaitForSeconds(22);
        animator.SetInteger("check", 1);
    }
}
