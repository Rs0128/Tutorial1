using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollisions : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;
    [SerializeField] int point;

    private void Start()
    {
        player = GameObject.Find("Player");//プレイヤーを見つける
        pc = player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other) {
        
        player = GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();
        pc.SetCountText(point);

        Destroy(gameObject);//アタッチされている自分自身を消す
        Destroy(other.gameObject);//ぶつかった相手（other）を消す
    }
}
