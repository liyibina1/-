using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalData;

public class GlobalMgr : MonoBehaviour
{
    // Start is called before the first frame update

   


    /// <summary>
    /// 注册函数
    /// </summary>
    public static void RegisterEnity(Enity enity,object _object)
    {
        switch (enity)
        {
            case Enity.fsm:
                fsmId_ += 1;
                allFiniteStateMachine.Add(fsmId_, (FiniteStateMachine)_object);
                break;

            case Enity.telegram:
                telegramId_ += 1;
                allMessageEvent.Add(telegramId_, (TimeUtil)_object);
                break;

            default:
                print("【warn】生成实体ID未命中");
                break;
        }
    }



    
}
