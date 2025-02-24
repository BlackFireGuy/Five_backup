﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo { }

//里氏转换
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}
public class EventInfo : IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        action += action;
    }
}


/// <summary>
/// 事件中心 单例模式对象
/// 这个模块时游戏开发过程中非常重要的模块，他可以减小程序的耦合性（文件关联度小，独立性大），减小复杂性。
///事件中心模块主要就是说收集全场的事件，在得到某个事件后（比如怪物X死亡），令关心这个事件的对象（比如玩家）进行相应的处理（比如加金币）。
/// 1.Dictionary
/// 2.委托
/// 3.观察者设计模式
/// 4. 泛型
/// </summary>
public class EventCenter : BaseSingleton<EventCenter>
{
    //key — 事件的名字（比如：怪物死亡，玩家死亡，通关 等等）
    //value — 对应的是监听这个事件 对应的委托函数们
    //UnityAction<object>  泛型委托
    private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

    /// <summary>
    /// 添加事件监听
    /// </summary>
    /// <param name="name">事件的名字</param>
    /// <param name="action">准备用来处理事件的委托函数</param>
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        //有没有对应的事件监听
        //有的情况
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        //没有的情况
        else
        {
            eventDic.Add(name, new EventInfo<T>(action));
        }
    }
    /// <summary>
    /// 监听不需要参数传递的事件
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void AddEventListener(string name, UnityAction action)
    {
        //有没有对应的事件监听
        //有的情况
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions += action;
        }
        //没有的情况
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }

    /// <summary>
    /// 移除对应的事件监听
    /// </summary>
    /// <param name="name">事件的名字</param>
    /// <param name="action">对应之前添加的委托函数</param>
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo<T>).actions -= action;
    }

    /// <summary>
    /// 移除不需要参数的事件
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo).actions -= action;
    }
    /// <summary>
    /// 事件触发
    /// </summary>
    /// <param name="name">哪一个名字的事件触发了</param>
    public void EventTrigger<T>(string name, T info)
    {
        //有没有对应的事件监听
        //有的情况
        if (eventDic.ContainsKey(name))
        {
            //eventDic[name]();
            if ((eventDic[name] as EventInfo<T>).actions != null)
                (eventDic[name] as EventInfo<T>).actions.Invoke(info);
            // eventDic[name].Invoke(info);
        }
    }
    /// <summary>
    /// 事件触发（不需要参数的）
    /// </summary>
    /// <param name="name"></param>
    public void EventTrigger(string name)
    {
        //有没有对应的事件监听
        //有的情况
        if (eventDic.ContainsKey(name))
        {
            //eventDic[name]();
            if ((eventDic[name] as EventInfo).actions != null)
                (eventDic[name] as EventInfo).actions.Invoke();
            // eventDic[name].Invoke(info);
        }
    }
    /// <summary>
    /// 清空事件中心
    /// 主要用于场景切换
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }
}
