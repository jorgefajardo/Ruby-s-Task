using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInstruction : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
