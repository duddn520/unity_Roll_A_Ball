using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    AudioSource sound;
    public GameManagerLogic manager;
    bool isJump;
    public float jumppower;
    public int itemcount;
    

    void Awake()
    {
        isJump = false;
        sound = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if( Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0,jumppower,0),ForceMode.Impulse);
        }

        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h,0,v),ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Floor")
            isJump = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {  
            itemcount++;
            other.gameObject.SetActive(false);
            sound.Play();
            manager.GetItem(itemcount);
            
        }
        else if(other.tag == "Finish")
        {
            if(manager.stage!=manager.totalstage)
            {
                if(manager.TotalItemCount==itemcount)
             {
                 SceneManager.LoadScene("Scene"+(manager.stage+1));
             }
             else
             {
                 SceneManager.LoadScene("Scene"+manager.stage);                              
             }
            }
            else
            {
                if(manager.TotalItemCount==itemcount)
             {
                 SceneManager.LoadScene(0);
             }
             else
             {
                 SceneManager.LoadScene("Scene"+manager.stage);                              
             }

            }

        }
    }
}
