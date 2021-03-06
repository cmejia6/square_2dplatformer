﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CombatNetwTst : NetworkBehaviour{
    public const int maxHealth = 100;

    [SyncVar]
    public int health = maxHealth;

    public void TakeDamage(int amount) {
        if (!isServer)
            return;

        health -= amount;
        if (health <= 0) {
            health = 0;
            Debug.Log("Dead!");

            RpcRespawn();
        }
    }

    [ClientRpc]
    void RpcRespawn() {
        if (!isLocalPlayer)
            return;

        transform.position = Vector2.zero;
    }
}
