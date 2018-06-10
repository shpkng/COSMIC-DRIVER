/*
 * File: GameControl.cs
 * Project: Script
 * File Created: Friday, 1st June 2018 3:16:03 am
 * Author: shpkng (shpkng@gmail.com)
 * -----
 * Last Modified: Wednesday, 6th June 2018 4:00:25 am
 * Modified By: shpkng (shpkng@gmail.com>)
 * -----
 * loving the lovely sunshine in autumn.♥
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameControl takes the responsibility to count you points
public class GameControl : MonoBehaviour
{

    [SerializeField] UnityEngine.UI.Text point;

    [SerializeField] SteamVR_TrackedObject redHand;
    [SerializeField] SteamVR_TrackedObject blueHand;
    [SerializeField] ushort pulseTime;

    SteamVR_Controller.Device redDevice;
    SteamVR_Controller.Device blueDevice;

    [SerializeField] GameObject red;
    [SerializeField] GameObject blue;

    [SerializeField] float 圆环停留时间;


    [SerializeField] SpriteRenderer MissSprite;

    [SerializeField] GameObject ringWithRings;
    [SerializeField] float alphaStep = 0.01f;

    int pointCache = 0;

    // Use this for initialization
    void Start()
    {
        point.text = "00000000";
        redDevice = SteamVR_Controller.Input((int)redHand.index);
        blueDevice = SteamVR_Controller.Input((int)blueHand.index);

    }

    public void AddPoints(int s)
    {
        pointCache += s;
        point.text = string.Format("{0:00000000}", pointCache);  //padding to 8 digits
    }

    public void ShowRing(int lv, int color)    //0-2 OK - Perfect
    {
        // Ring near controller
        switch (lv)
        {
            case 0:
                {
                    if (color == 0)
                    {
                        red.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                        red.SetActive(true);

                    }
                    else
                    {
                        blue.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                        blue.SetActive(true);
                    }

                }; break;
            case 1:
                {
                    if (color == 0)
                    {
                        red.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        red.SetActive(true);
                    }
                    else
                    {
                        blue.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        blue.SetActive(true);
                    }

                }; break;
            case 2:
                {
                    if (color == 0)
                    {
                        red.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                        red.SetActive(true);
                    }
                    else
                    {
                        blue.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                        blue.SetActive(true);
                    }
                }; break;
        }

        StartCoroutine(Hide(圆环停留时间, color));

        GameObject temp = Instantiate(ringWithRings);
        temp.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 3) * 10);

        if(color==0)
        {
            redDevice.TriggerHapticPulse(pulseTime);
        }
        else
        {
            blueDevice.TriggerHapticPulse(pulseTime);
        }
    }

    public void ShowMiss()
    {
        MissSprite.color = Color.white;
        Debug.Log("FWETEWT");
    }

    void Update()
    {
        MissSprite.color = new Vector4(MissSprite.color.r, MissSprite.color.g, MissSprite.color.b, MissSprite.color.a - alphaStep);
    }

    IEnumerator Hide(float t, int color)
    {
        yield return new WaitForSeconds(t);
        if (color == 0)
        {
            red.SetActive(false);
        }
        else
            blue.SetActive(false);
    }

    #region 
    //同时出现的版本
    // public void ShowRing(int lv)    //0-2 OK - Perfect
    // {
    //     switch (lv)
    //     {
    //         case 0:
    //             {
    //                 red.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
    //                 blue.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
    //                 red.SetActive(true);
    //                 blue.SetActive(true);

    //             }; break;
    //         case 1:
    //             {
    //                 red.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    //                 blue.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    //                 red.SetActive(true);
    //                 blue.SetActive(true);

    //             }; break;
    //         case 2:
    //             {
    //                 red.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    //                 blue.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    //                 red.SetActive(true);
    //                 blue.SetActive(true);

    //             }; break;
    //     }

    //     StartCoroutine(Hide(圆环停留时间));

    // }

    // IEnumerator Hide(float t)
    // {
    //     yield return new WaitForSeconds(t);
    //     red.SetActive(false);
    //     blue.SetActive(false);
    // }
    #endregion
}
