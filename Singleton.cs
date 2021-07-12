using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null) //ถ้าว่างเปล่า
                _instance = FindObjectOfType<T>();//จะหาGameManager
            else if (_instance != FindObjectOfType<T>())//ถ้าไม่ใช่GameManager
                Destroy(FindObjectOfType<T>());//สั่งให้ทำลายทิ้ง

            DontDestroyOnLoad(FindObjectOfType<T>());//สั่งไม่ให้ทำลาย GameManager
            return _instance; //กลับไปอีกครั้ง
        }

        set
        {

        }
    }
}
