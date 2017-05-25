using UnityEngine;
using System.Collections;
using System;

public class TestBlockCharacter : Character {

    public override void ActionE()
    {
        Debug.Log("E was Pressed");
    }
    public override void ActionQ()
    {
        isPassive();
    }

    public override void ActionW()
    {
        Debug.Log("W was Pressed");
    }

    public override void Ultimate()
    {
        Debug.Log("ULIMATE was Pressed");
    }

}
