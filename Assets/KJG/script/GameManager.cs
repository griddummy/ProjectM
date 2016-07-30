using UnityEngine;
using System.Collections;

public class GameManager : ScriptableObject {

    public enum GAME_STATE { MENU, HOME, GAME }

    private GAME_STATE m_GameState;

    private static GameManager m_instance;

    public static GameManager instance{
        get
        {
            if(m_instance == null)
            {
                m_instance = CreateInstance<GameManager>();
            }
            return m_instance;
        }
    }

    void OnEnable() // 초기화
    {
        m_GameState = GAME_STATE.MENU;
    }
}
