﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// UI层级
/// </summary>
public enum E_UI_Layer
{
    Bot,
    Mid,
    Top,
    System,
    Null,
    Twice,
}

/// <summary>
/// UI管理器
/// 1.管理所有显示的面板
/// 2.提供给外部 显示和隐藏等接口
/// </summary>
public class UIManager : BaseSingleton<UIManager>
{
    public Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

    private Transform bot;
    private Transform mid;
    private Transform top;
    private Transform system;
    private Transform twice;
    public UIManager()
    {
        //创建Canvas 让其过场景的时候 不被移除
        GameObject obj = ResMgr.GetInstance().Load<GameObject>(PathCfg.UI_CANVAS_OBJECT_MADE_BY_UIMANAGER);
        Transform canvas = obj.transform;
        GameObject.DontDestroyOnLoad(obj);

        //找到各层
        bot = canvas.Find("Bot");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");
        twice = canvas.Find("Twice");

        //创建EventSystem 让其过场景的时候不被移除
        obj = ResMgr.GetInstance().Load<GameObject>(PathCfg.UI_SYSTEM_OBJECT_MADE_BY_UIMANAGER);

        GameObject.DontDestroyOnLoad(obj);
    }

    /// <summary>
    ///  显示面板
    /// </summary>
    /// <typeparam name="T">面板脚本类型</typeparam>
    /// <param name="panelName">面板名</param>
    /// <param name="layer">显示在哪一层</param>
    /// <param name="callBack">当面板创建成功后，你想做的事</param>
    public void ShowPanel<T>(string panelName,E_UI_Layer layer = E_UI_Layer.Mid, UnityAction<T> callBack = null) where T:BasePanel
    {
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].ShowMe();
            //处理面板创建完成后的逻辑
            if (callBack != null)
                callBack(panelDic[panelName] as T);
            return;
        }


        ResMgr.GetInstance().LoadAsync<GameObject>(PathCfg.PATH_UI + panelName, (obj) => {
            //把他作为Canvas的子对象
            //并且要设置它的相对位置
            //找到父对象 你到底显示在那一层
            Transform father = bot;
            switch(layer)
            {
                case E_UI_Layer.Mid:
                    father = mid;
                    break;
                case E_UI_Layer.Top:
                    father = top;
                    break;
                case E_UI_Layer.System:
                    father = system;
                    break;
                case E_UI_Layer.Null:
                    father = system.parent;
                    break;
                case E_UI_Layer.Twice:
                    father = twice;
                    break;

                default:
                    father = system.parent;
                    break;
                    
            }
            //设置父对象 设置相对位置和大小
            obj.transform.SetParent(father);

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            (obj.transform as RectTransform).offsetMax = Vector2.zero;
            (obj.transform as RectTransform).offsetMin = Vector2.zero;

            //得到预设体身上的面板脚本
            T panel = obj.GetComponent<T>();

            //处理面创建完成后的逻辑
            if (callBack != null)
                callBack(panel);

            panel.ShowMe();

            // 把面板存起来
            panelDic.Add(panelName, panel);
        });
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="panelName"></param>
    public void HidePanel(string panelName)
    {
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].HideMe();
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
    }
    /// <summary>
    /// 隐藏所有面板
    /// </summary>
    /// <param name="panelName"></param>
    public void HideAllPanel()
    {
        foreach(KeyValuePair<string,BasePanel> item in panelDic)
        {
            GameObject.Destroy(panelDic[item.Key].gameObject);
        }
        panelDic.Clear();
    }


}
