using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BowlingBall;

    public void Create()
    {
        Instantiate(BowlingBall);
    }
}
