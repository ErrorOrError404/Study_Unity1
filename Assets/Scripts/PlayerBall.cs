using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    float speed = 7.5f;
    float jumpForce = 6.5f;
    bool onAire;
    int rotateRate; 
    public int nItems;

    public GameManagerLogic manager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        //nItems = 0;
        rotateRate = 20 * (int)speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾� �̵�
        Vector3 vec = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime,
            0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        
        Vector3 vecRotate = new Vector3(Input.GetAxisRaw("Vertical") * Time.deltaTime,
            0, Input.GetAxisRaw("Horizontal") * -1 * Time.deltaTime);
        
        transform.Translate(vec * speed, Space.World);

        transform.Rotate(vecRotate * rotateRate, Space.World);

        // �÷��̾� ����
        if (Input.GetButtonDown("Jump") && (onAire == false))
        { //Debug.Log("����");
            onAire = true;
            rigid.AddForce(Vector3.up* jumpForce, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            if (manager.totalItems == nItems)
            {
                // ���� Ŭ����
                SceneManager.LoadScene("Example" + (manager.stage + 1));
                //SceneManager.LoadScene("Example" + (manager.stage + 1).ToString()); // �̷��� �ص� �Ȱ���
            }
            else 
            {
                // �ٽý���
                SceneManager.LoadScene("Example" + (manager.stage).ToString());
                //SceneManager.LoadScene("Example" + (manager.stage)); // �̷��� �ص� �Ȱ���
            }
        }

        if (other.tag == "Item")
        {
            other.gameObject.SetActive(false);
            manager.GetItemN(nItems);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            onAire = false;
        }
    }
}
