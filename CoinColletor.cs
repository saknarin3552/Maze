using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinColletor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.coin += 1; //เพิ่ม Coin ทีละ 1
            //SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.Coin); //สั่งเล่นเสียงเมื่อชนเหรียญ
            Destroy(gameObject, 0.25f); //สั่งทำลายเหรียญ เมื่อชน
        }
    }
}
