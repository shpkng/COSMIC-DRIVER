using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleRing : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float alphaStep;
    void FixedUpdate()
    {
        sr.color = new Vector4(1, 1, 1, sr.color.a - alphaStep);

        if (sr.color.a <= 0.01)
        {
            Destroy(gameObject);
        }

    }


}
