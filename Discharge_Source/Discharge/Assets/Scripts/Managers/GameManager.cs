using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager manager;
    static GameplayManager gameplay;
    static PlayerManager player;
    static IngameInterfaceManager ui;

    public static GameManager Manager
    {
        get
        {
            if (manager == null)
                manager = FindObjectOfType<GameManager>();

            return manager;
        }
    }

    public static GameplayManager Gameplay
    {
        get
        {
            if (gameplay == null)
                gameplay = FindObjectOfType<GameplayManager>();

            return gameplay;
        }
    }

    public static PlayerManager Player
    {
        get
        {
            if (player == null)
                player = FindObjectOfType<PlayerManager>();

            return player;
        }
    }

    public static IngameInterfaceManager UI
    {
        get
        {
            if (ui == null)
                ui = FindObjectOfType<IngameInterfaceManager>();

            return ui;
        }
    }
}
