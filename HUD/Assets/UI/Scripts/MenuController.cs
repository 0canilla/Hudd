using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private InputField inputUserName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeUsername()
    {
        Debug.Log(inputUserName.text);
    }

    public void EndChangeUser()
    { 
        ProfileManager.instance.SetPlayerName(inputUserName.text);       
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Level 1");
    }
}
