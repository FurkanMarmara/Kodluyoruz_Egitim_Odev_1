using Example1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton 
    public static GameManager instance;
    public GameManager()
    {
        if (instance!=null && instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
            
    }
    #endregion


    private void Start()
    {
        Controller controller = new Controller();
        
    }

    public static GameManager Get()
    {
        return instance;
    }


}
