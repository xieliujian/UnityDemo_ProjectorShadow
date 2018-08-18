using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance = null;

    public Camera mCamera;

    public CharacterController mCharCtrl;

    private Animation mAnim;

    #region 内置函数

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () 
    {
        mAnim = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update ()
    {
        float deltax = Input.GetAxis("Horizontal");
        float deltay = Input.GetAxis("Vertical");
        if (Mathf.Abs(deltax) <= 0.01f && Mathf.Abs(deltay) <= 0.01f)
        {
            mAnim.Play("idle1");
            return;
        }

        Vector3 realdir = new Vector3(deltax, 0.0f, deltay);
        realdir = Quaternion.AngleAxis(mCamera.transform.eulerAngles.y, Vector3.up) * realdir;

        float angle = Vector3.Angle(transform.forward, realdir);
        realdir = Vector3.Slerp(transform.forward, realdir, Mathf.Clamp01(180 * Time.deltaTime * 5 / angle));
        transform.LookAt(transform.position + realdir);

        mCharCtrl.SimpleMove(realdir * 5);
        mAnim.Play("walk");
    }

    #endregion
}
