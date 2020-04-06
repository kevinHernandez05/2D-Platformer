using System;
using UnityEngine;

public static class PlayerState
{

    public static void PlayerControllerState(GameObject player, bool state)
    {
        player.GetComponent<playerController>().enabled = state;
    }

    public static void PlayerTransformPosition(GameObject Player, Vector2 NewPosition)
    {
        Player.transform.position = NewPosition;
    }

    public static void HurtPlayer(GameObject player, int damage)
    {
        player.GetComponent<playerController>().vida -= damage;
    }

    public static void HealPlayer(GameObject player, int heal)
    {
        player.GetComponent<playerController>().vida += heal;
    }

    public static void StuntPlayer(GameObject player, bool state)
    {
        player.GetComponent<playerController>().Stunned = state;
    }










}
