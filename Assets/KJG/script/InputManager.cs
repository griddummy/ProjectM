using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : ScriptableObject {
    
    public enum Action { FORWARD, BACKWARD, LEFT, RIGHT, JUMP, INVENTORY }
    public enum Event { DOWN, UP, STAY }
    public string test = "test";

    private Dictionary<Action, KeyCode> listActionKey;

    private static InputManager m_instance;
    public static InputManager intstance
    {
        get
        {
            if (m_instance == null)
            {
                Debug.Log("Create InputManager");
                m_instance = CreateInstance<InputManager>();
            }            
            return m_instance;
        }        
    }

    public bool GetKeyState(Action _action, Event _event)// 액션에 해당하는 키의 상태를 알아온다.
    {
        switch (_event)
        {
            case Event.DOWN:
                return Input.GetKeyDown(listActionKey[_action]);
                
            case Event.STAY:
                return Input.GetKey(listActionKey[_action]);

            case Event.UP:
                return Input.GetKeyUp(listActionKey[_action]);

            default:
                return false;
        }
    }
    void OnEnable()
    {
        listActionKey = new Dictionary<Action, KeyCode>();
    }
}
