using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundTest : MonoBehaviour
{
     SpriteRenderer sr;
     Material mat;
    
    [SerializeField] float backGroundSpeed;
    float bgSpeedValue = 0;
    bool backGroundMove = true;
    public bool bgMove { get { return backGroundMove; } set { backGroundMove = value; } }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        mat = sr.material;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (backGroundMove)
        {
            bgSpeedValue += Time.deltaTime * backGroundSpeed;
            bgSpeedValue = Mathf.Repeat(bgSpeedValue, 1.0f);
            mat.mainTextureOffset = new Vector2(bgSpeedValue, 0);
        }
    }

    
}
