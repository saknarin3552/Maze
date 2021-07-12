using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int coin; //สร้างArrey coin

    private void Awake()
    {
        coin = 0; //รีค่าCoinใหม่กลับมาเท่ากับ 0 เมื่อเริ่มด่าน 1 ใหม่
    }
}
