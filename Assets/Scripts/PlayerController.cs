using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    private float horizontalInput;
    [SerializeField] private float speed;
    [SerializeField] private float xRange;
    [SerializeField] private GameObject projectilePrefab;//�H�ו��v���n�u�i���Ƃŕ����j

    public int score;//���_�̕ϐ�
    public Text ScoreText;//���_�̕����̕ϐ�

    private float LimitTime;//�������Ԃ̕ϐ�
    public Text TimeText;//�������Ԃ̕����̕ϐ�

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
        LimitTime = 30.0f;//�������Ԃ��U�O��
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
        //�X�y�[�X�L�[�������ꂽ��
        if(Input.GetKeyDown(KeyCode.Space)) {
            //�����ŐH�ו��𕡐�����i���̎g�����A�Ƃ��������\�b�h���o���āI�j
            Instantiate(    projectilePrefab, 
                            transform.position,
                            projectilePrefab.transform.rotation);
        }

        
    }

}
