using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 20f * Time.deltaTime);
    }

}
