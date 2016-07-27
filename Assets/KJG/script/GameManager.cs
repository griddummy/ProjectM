using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager m_instance;    

    public static GameManager instance{
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
                if(m_instance == null)
                {
                    GameObject obj = new GameObject("Logic");
                    obj.AddComponent<GameManager>();
                }
            }
            return m_instance;
        }
    }

    void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // 초기화

    }


}
