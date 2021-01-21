using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 30;
    public float horizontalInput;
    public float turnspeed = 100;
    public float verticalInput;
    //1/10 zixinma


    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private Animator playerAnim;//跳躍用
    public ParticleSystem dirtParticle;//跳躍粒子
    //210114 詹


    public float jumpForce = 10;
    public float gravityModifier = 5;
    public bool isOnGround = true;
    private Rigidbody playerRb;

    private int xRange = 20;

    //1/11 zixinma
    private int zRange = 64;
    private int fzRange = 34;
    public float forwardInput;


    public GameObject flyFood;

    //0114 張琇媗
    //public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        
        Physics.gravity *= gravityModifier;
        //1/10馬子馨

        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        //Debug.Log(playerAudio.name);
        // 1/14詹 1/17黃


    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        

        //limit bound
        if (transform.position.x < -xRange) // too left
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange) // too right
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //1/11 zixinma 

        if (transform.position.z > fzRange) // 前
        {
            print(transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y, fzRange);
        }

        if (transform.position.z < -zRange) // 後
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }


        //需要再加後面?
        // Generate fly food
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            Instantiate(flyFood, transform.position, transform.rotation);
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            //210114 詹

            dirtParticle.Stop();// 01/17黃
        }


        if (Input.GetKey(KeyCode.Period))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * 1);
        }
        if (Input.GetKey(KeyCode.Comma))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * -1);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {

        //0114 張琇媗
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
       // else if (collision.gameObject.CompareTag("chicken"))
        //{
           // gameOver = true;
           // Debug.Log("Game Over!");

        //}



    }


    //private void OnCollisionEnter(Collision collision)
    //{
       // isOnGround = true;

       // dirtParticle.Play();// 01/17黃
    //}
    
}
