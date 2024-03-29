using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : DecoratorNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    /// <summary>
    /// 成功を失敗に、失敗を成功にする
    /// </summary>
    /// <returns></returns>
    protected override State OnUpdate() {

        return state switch
        {
            State.Running => State.Running,
            State.Success => State.Failure,
            State.Failure => State.Success,
            _ => State.Failure,
        };
    }
}