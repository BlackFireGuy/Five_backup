﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator ani;
    BoxCollider2D coll;
    [Header("去往的世界")]
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();

        GameManager.instance.IsDoor(this);
        //coll.enabled = false;
    }

    public void OpenDoor()
    {
        ani.Play("open");
        coll.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("进入门触发器");
        if (collision.CompareTag("CheckArea"))
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("Opening"))
                StartCoroutine(WaitForAnimationPlayOver(ani.GetCurrentAnimatorStateInfo(0).length));
            //进入触发门，则保存信息
            GameSaveManager.instance.SaveGame();
            ScenesMgr.GetInstance().LoadScene(scene, null);
            //ScenesMgr.GetInstance().LoadScene(scene, null);
        }
    }


    IEnumerator WaitForAnimationPlayOver(float time)
    {
        yield return new WaitForSeconds(time);
    }

}
