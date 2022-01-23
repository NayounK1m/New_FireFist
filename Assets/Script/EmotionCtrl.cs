using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionCtrl : MonoBehaviour
{
    private GameObject Player;
    private Animator anim;

    public GameObject EmojiPanel;
    public GameObject EmojiBtn;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        anim = Player.GetComponent<Animator>();
    }

    public void Emoji()
    {
        EmojiPanel.SetActive(true);
        EmojiBtn.SetActive(false);
    }

    public void Cry()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("isCry", true);
        EmojiPanel.SetActive(false);
        EmojiBtn.SetActive(true);
        Invoke("Idle", 6.4f);
        
    }

    public void Clap()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("isClap", true);
        EmojiPanel.SetActive(false);
        EmojiBtn.SetActive(true);
        Invoke("Idle", 6.4f);
    }

    public void Laugh()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("isLaugh", true);
        EmojiPanel.SetActive(false);
        EmojiBtn.SetActive(true);
        Invoke("Idle", 3.6f);
    }

    public void Dizzy()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("isDizzy", true);
        EmojiPanel.SetActive(false);
        EmojiBtn.SetActive(true);
        Invoke("Idle", 2.4f);
    }

    private void Idle()
    {
        anim.SetBool("Idle", true);
        anim.SetBool("isCry", false);
        anim.SetBool("isClap", false);
        anim.SetBool("isLaugh", false);
        anim.SetBool("isDizzy", false);
    }
}
