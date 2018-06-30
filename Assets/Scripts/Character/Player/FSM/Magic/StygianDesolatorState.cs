﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meaningless;

public class StygianDesolatorState : FSMState
{
    //internal NetPoolManager NetPoolManager = new NetPoolManager();

    public StygianDesolatorState()
    {
        stateID = FSMStateType.StygianDesolator;
    }

    public override void Act(BaseFSM FSM)
    {
        if (PlayerStatusManager.Instance.skillAttributesList[0].skillInfo != PlayerStatusManager.Instance.NullInfo)
            if (PlayerStatusManager.Instance.skillAttributesList[0].skillInfo.magicProperties.magicType == MagicType.StygianDesolator)
            {
                if (PlayerStatusManager.Instance.skillAttributesList[0].isOn)
                {
                    PlayerStatusManager.Instance.UseMagic(0);
                    FSM.PlayAnimation("Spin Attack");
                   // GameObject go = NetPoolManager.Instantiate("Stygian Desolator", GameTool.FindTheChild(FSM.gameObject, "RigPelvisGizmo").position, FSM.transform.rotation);
                    AudioManager.PlaySound2D("Stygian Desolator").Play();
                   // go.GetComponent<MagicBehaviour>().isHit = true;
                    NetworkManager.SendPlayerMagic("Stygian Desolator", GameTool.FindTheChild(FSM.gameObject, "RigLArmPalmGizmo").position, FSM.transform.rotation);
                }

            }
        if (PlayerStatusManager.Instance.skillAttributesList[1].skillInfo != PlayerStatusManager.Instance.NullInfo)
            if (PlayerStatusManager.Instance.skillAttributesList[1].skillInfo.magicProperties.magicType == MagicType.StygianDesolator)
            {

                if (PlayerStatusManager.Instance.skillAttributesList[1].isOn)
                {
                    PlayerStatusManager.Instance.UseMagic(1);
                    FSM.PlayAnimation("Spin Attack");
                   // GameObject go = NetPoolManager.Instantiate("Stygian Desolator", GameTool.FindTheChild(FSM.gameObject, "RigPelvisGizmo").position, FSM.transform.rotation);
                    AudioManager.PlaySound2D("Stygian Desolator").Play();
                  //  go.GetComponent<MagicBehaviour>().isHit = true;
                    NetworkManager.SendPlayerMagic("Stygian Desolator", GameTool.FindTheChild(FSM.gameObject, "RigLArmPalmGizmo").position, FSM.transform.rotation);
                }

            }


    }

    public override void Reason(BaseFSM FSM)
    {
        CharacterMessageDispatcher.Instance.DispatchMesssage
            (FSMTransitionType.IsIdle,
            FSM,
            FSM.animationManager.baseStateInfo.IsName("Idle")
            );
    }

}