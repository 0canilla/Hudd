using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemController : MonoBehaviour
{
    public int damage = 5;
    private GameObject player;
    [SerializeField] private float Healths;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        Healths = player.GetComponent<PlayerController>().Health;
        if (other.gameObject.tag == "Player")
        {
            Healths -= damage;
        }
    }
}
