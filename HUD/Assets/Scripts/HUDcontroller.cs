using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDcontroller : MonoBehaviour
{
    [SerializeField] public Text Hp;
    [SerializeField] public Text Sta;
    [SerializeField] private float STAMINA;
    [SerializeField] private float Healths;
    private GameObject player;
    [SerializeField] public bool Full = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Stamina();
        Health();
    }

    private void Stamina()
    {
        STAMINA = player.GetComponent<PlayerController>().totalSta;
        Sta.text = "Sta" + STAMINA;
    }

    private void Health()
    {
        Healths = player.GetComponent<PlayerController>().Health;
        Hp.text = "HP" + Healths;

    }

    public void Fast()
    {
        Debug.Log("Resistencia Infinita");
        Full = true;
    }
}
