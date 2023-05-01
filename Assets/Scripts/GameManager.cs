using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager instance
    {
        get
        {
            if (_instance == null) return null;
            return _instance;
        }
    }


    float _mouseSensitivity = 5;

    public float mouseSensitivity
    {
        get { return _mouseSensitivity; }
        set { _mouseSensitivity = value; }
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
    }
}
