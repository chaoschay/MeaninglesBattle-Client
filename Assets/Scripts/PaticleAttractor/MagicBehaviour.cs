﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meaningless;

public class MagicBehaviour : MonoBehaviour
{

    public MagicType magicType;
    public PlayerController player;
    public bool isHit = false;

    private void Start()
    {
        player = CameraBase.Instance.player.GetComponent<PlayerController>();
    }
    void OnEnable()
    {
        player = CameraBase.Instance.player.GetComponent<PlayerController>();
    }

/* 
    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            switch (magicType)
            {
                case MagicType.Ripple:
                    Damage(3f,360);
                   
                    break;
                case MagicType.HeartAttack:
                    Damage(3f, 360);
                    break;
                case MagicType.IceArrow:
                    float IProbability = ItemInfoManager.Instance.GetItemInfo(603).magicProperties.Probability;
                    Damage(3f, 360);
                    if (Random.value < IProbability)
                    {
                        Freeze(2, 3f, 360);
                    }
                    break;
                case MagicType.ChoshimArrow:
                    float CProbability = ItemInfoManager.Instance.GetItemInfo(604).magicProperties.Probability;
                    Damage(3f, 360);
                    if (Random.value < CProbability)
                    {
                        SlowDown(4,3f, 360);
                    }
                    break;
                case MagicType.StygianDesolator:
                    Blind(5, 5, 360);
                    break;
                case MagicType.Thunderbolt:
                    Damage(5, 360);
                    break;
            }
            isHit = false;
        }

    }
*/


    void OnTriggerEnter(Collider collider)
    {
       
        if (isHit)
        {
            foreach (KeyValuePair<string, NetworkPlayer> enemy in NetworkPlayerManager.Instance.ScenePlayers)
             {
                 if(enemy.Value.playerName==NetworkManager.PlayerName)
                 {
                     continue;
                 }
                switch (magicType)
                 {
                    case MagicType.Ripple:
                     NetworkManager.SendPlayerHitSomeone(enemy.Value.name, PlayerStatusManager.Instance.GetCharacterStatus().Attack_Magic * (1 - enemy.Value.characterStatus.Defend_Magic / 100));
                    break;
                    case MagicType.HeartAttack:
                        NetworkManager.SendPlayerHitSomeone(enemy.Value.name, PlayerStatusManager.Instance.GetCharacterStatus().Attack_Magic * (1 - enemy.Value.characterStatus.Defend_Magic / 100));
                        break;
                    case MagicType.IceArrow:
                        float IProbability = ItemInfoManager.Instance.GetItemInfo(603).magicProperties.Probability;
                         NetworkManager.SendPlayerHitSomeone(enemy.Value.name, PlayerStatusManager.Instance.GetCharacterStatus().Attack_Magic * (1 - enemy.Value.characterStatus.Defend_Magic / 100));
                        if (Random.value < IProbability)
                        {
                          NetworkManager.SendPlayerGetBuff(enemy.Value.playerName,BuffType.Freeze,2);
                        }
                    break;
                    case MagicType.ChoshimArrow:
                    float CProbability = ItemInfoManager.Instance.GetItemInfo(604).magicProperties.Probability;
                    NetworkManager.SendPlayerHitSomeone(enemy.Value.name, PlayerStatusManager.Instance.GetCharacterStatus().Attack_Magic * (1 - enemy.Value.characterStatus.Defend_Magic / 100));
                    if (Random.value < CProbability)
                    {
                       NetworkManager.SendPlayerGetBuff(enemy.Value.playerName,BuffType.SlowDown,5);
                    }
                    break;
                    case MagicType.StygianDesolator:
                     NetworkManager.SendPlayerGetBuff(enemy.Value.playerName,BuffType.Blind,5);
                    break;
                    case MagicType.Thunderbolt:
                     NetworkManager.SendPlayerHitSomeone(enemy.Value.name, PlayerStatusManager.Instance.GetCharacterStatus().Attack_Magic * (1 - enemy.Value.characterStatus.Defend_Magic / 100));
                    break;
                 }
                 
            }
            isHit = false;
        }

    }

}
