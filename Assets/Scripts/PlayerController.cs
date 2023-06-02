using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    private float horizontalInput;
    [SerializeField] private float speed;
    [SerializeField] private float xRange;
    [SerializeField] private GameObject projectilePrefab;//食べ物プレハブ（あとで複製）

    public int score;//得点の変数
    public Text ScoreText;//得点の文字の変数

    private float LimitTime;//制限時間の変数
    public Text TimeText;//制限時間の文字の変数

    void ScoreUpdate()
    {
        ScoreText.text = "Score:" + score.ToString();
    }
    public void SetCountText(int point)
    {
        score += point;
    }

    void TimeUpdate()
    {
        TimeText.text = "Time:" + LimitTime.ToString();
        LimitTime -= Time.deltaTime;
    }

    void Start()
    {
        score = 0;
        LimitTime = 30.0f;//制限時間を６０に
    }

    void Update()
    {
        TimeUpdate();
        ScoreUpdate();

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput 
                * Time.deltaTime * speed);
        if(transform.position.x < -xRange) {
            transform.position = new Vector3(   -xRange, 
                                                transform.position.y,
                                                transform.position.z);
        }
        if(xRange < transform.position.x ) {
            transform.position = new Vector3(   xRange,
                                                transform.position.y,
                                                transform.position.z);
        }
        //スペースキーが押されたら
        if(Input.GetKeyDown(KeyCode.Space)) {
            //ここで食べ物を複製する（この使い方、というかメソッド名覚えて！）
            Instantiate(    projectilePrefab, 
                            transform.position,
                            projectilePrefab.transform.rotation);
        }

        
    }

}
