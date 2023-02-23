using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;
*/

public class Items : MonoBehaviour
{
    string name;
    int rotateSpeed = 80;
    MeshRenderer meshRenderer;
    AudioSource audio;

    public AudioClip clip;

    bool isActivate;

    void Awake()
    {
        name = gameObject.name;
        meshRenderer = GetComponent<MeshRenderer>();
        audio = GetComponent<AudioSource>();
        clip = audio.clip;
        isActivate = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (name == "Item2")
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹�ϸ� ������Ʈ(Item) ��Ȱ��ȭ   
        if(other.name == "Player" && isActivate) 
        {
            other.GetComponent<PlayerBall>().nItems += 1;
            //Debug.Log(other.GetComponent<PlayerBall>().nItem);

            // ����
            /*
            audio.Play();

            meshRenderer.enabled = false;
            isActivate = false;
            */
            AudioSource.PlayClipAtPoint(clip, transform.position);

            //gameObject.SetActive(false);
        }
    }
}
