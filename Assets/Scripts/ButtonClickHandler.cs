using System.Collections;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;

    public GameObject Yurak;
    public GameObject YurakPanel;
    public GameObject Yurak1;

    public GameObject Jigar;
    public GameObject JigarPanel;
    public GameObject Jigar1;

    public GameObject Ichak;
    public GameObject IchakPanel;
    public GameObject Ichak1;

    public GameObject MendeleyvYurak;
    public GameObject MendeleyvJigar;
    public GameObject MendeleyvIchak;

    public GameObject Link;
    public GameObject Mendeleyv;

    public Animator animYurak;
    public Animator animJigar;
    public Animator animIchak;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ClickYurak();
        }
        else if(Input.GetKeyDown(KeyCode.S)) 
        {
            ClickIchak();
        }
        else if( Input.GetKeyDown(KeyCode.T)) 
        {
           ClickJigar();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ClickChiqish();   
        }
    }

    private void SetObjectsAndPlayAnimation(GameObject obj, GameObject panel, Animator animator, string animationName)
    {
        obj.SetActive(true);
        panel.SetActive(true);
        animator.Play(animationName);
    }

    private void StopAndDeactivateObjects(Animator animator, GameObject obj, GameObject panel)
    {
        animator.enabled = false;
        obj.SetActive(false);
        panel.SetActive(false);
    }

    private void ResetAnimations()
    {
        anim1.enabled = true;
        anim2.enabled = true;
    }

    public void ClickYurak()
    {
       
        ResetAnimations();
        SetObjectsAndPlayAnimation(Yurak, YurakPanel, anim1, "Anim");
        StopAndDeactivateObjects(anim2, Jigar, JigarPanel);
        Link.SetActive(false);
        StartCoroutine(Yurak2());
    }

    IEnumerator Yurak2()
    {
        animYurak.SetInteger("check", 2);
        yield return new WaitForSeconds(14);
        animYurak.SetInteger("check", 1);
    }


    IEnumerator Jigar2()
    {
        animJigar.SetInteger("check", 2);
        yield return new WaitForSeconds(24);
        animJigar.SetInteger("check", 1);
    } 
    IEnumerator Ichak2()
    {
        animIchak.SetInteger("check", 2);
        yield return new WaitForSeconds(23);
        animIchak.SetInteger("check", 1);
    }

    public void ClickJigar()
    {
        
        ResetAnimations();
        SetObjectsAndPlayAnimation(Jigar, JigarPanel, anim1, "JigarAnim");
        StopAndDeactivateObjects(anim2, Yurak, YurakPanel);
        Link.SetActive(false);
        StartCoroutine(Jigar2());
    }

    public void ClickIchak()
    {
        
        ResetAnimations();
        SetObjectsAndPlayAnimation(Ichak, IchakPanel, anim1, "IchakAnim");
        StopAndDeactivateObjects(anim2, Yurak, YurakPanel);
        Link.SetActive(false);
        StartCoroutine(Ichak2());
    }

    public void ClickChiqish()
    {
        ResetAnimations();
        StopAndDeactivateObjects(anim1, Yurak, YurakPanel);
        StopAndDeactivateObjects(anim1, Jigar, JigarPanel);
        StopAndDeactivateObjects(anim1, Ichak, IchakPanel);
        Mendeleyv.SetActive(false);
        Yurak1.SetActive(false);
        Jigar1.SetActive(false);
        Ichak1.SetActive(false);
        MendeleyvYurak.SetActive(false);
        MendeleyvJigar.SetActive(false);
        MendeleyvIchak.SetActive(false);
        Link.SetActive(true);

        StartCoroutine(Link2());
    }

    IEnumerator Link2()
    {
        anim2.SetInteger("Check", 2);
        yield return new WaitForSeconds(6.5f);
        anim2.SetInteger("Check", 1);
    }
}
