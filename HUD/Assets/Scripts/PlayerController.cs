using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float Speed = 1.20f;
    float cameraX;
    float cameraY;
    float Sprint = 25f;
    public bool sprint = false;
    private GameObject hud;
    [SerializeField] public float totalSta = 100;
    [SerializeField] public float Health = 100;
    private bool BurnOut = true;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        Tired();
        Rotate();
        Stamina();
        MyInput();
        if (BurnOut == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                sprint = true;
        }
            else
            {
                sprint = false;
            }
        }
        
    }

    private void MyInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }

        if (hud.GetComponent<HUDcontroller>().Full == true)
        {
            totalSta = 100;
        }
    }
    private void Move(Vector3 direction)
    {

        if (sprint == true)
        {
            transform.Translate(Sprint * Time.deltaTime * direction);
        }
        else
        {
            transform.Translate(Speed * Time.deltaTime * direction);
        }

    }

    private void Rotate()
    {
        cameraX += Input.GetAxis("Mouse X");
        cameraY += Input.GetAxis("Mouse Y");
        Quaternion Angulo = Quaternion.Euler(-cameraY, cameraX, 0);
        transform.localRotation = Angulo;
    }

    private void Stamina()
    {
        if (sprint == true && totalSta >= 0 )
        {
            totalSta -= Time.deltaTime*20;
        }
        if (sprint == false && totalSta <= 100)
        {
            totalSta += Time.deltaTime*10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Health -= 5;
        }
    }

    private void Tired()
    {
        if (totalSta < 0)
        {
            BurnOut = true;
            sprint = false;
        }
        else if (totalSta >= 50)
        {
            BurnOut = false;
        }
    }
}
