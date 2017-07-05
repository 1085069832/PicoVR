using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisToFlower : MonoBehaviour
{

    [SerializeField] GameObject picoCamera;//摄像机
    [SerializeField] GameObject flowerCenter;//花
    Vector3 disOffset;//距离向量
    [SerializeField] float speed = 2f;//速度
    [SerializeField] float minDis = 0.3f;//最近距离
    [SerializeField] float maxDis = 2f;//最远距离
    [SerializeField] float rotateSpeed = 200;//旋转速度

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        disOffset = picoCamera.transform.position - flowerCenter.transform.position;
    }
    /// <summary>
    /// 拉近
    /// </summary>
    public void OnClickToNear()
    {
        if (disOffset.magnitude < minDis)
        {
            return;
        }
        picoCamera.transform.position -= speed * Time.deltaTime * disOffset.normalized;
    }
    /// <summary>
    /// 拉远
    /// </summary>
    public void OnClickToKeep()
    {
        if (disOffset.magnitude > maxDis)
        {
            return;
        }
        picoCamera.transform.position += speed * Time.deltaTime * disOffset.normalized;
    }
    /// <summary>
    /// 旋转
    /// </summary>
    public void OnClickToLeftRotate()
    {
        print("旋转");
        picoCamera.transform.RotateAround(flowerCenter.transform.position, picoCamera.transform.up, rotateSpeed * Time.deltaTime);
    }

    public void OnClickToRightRotate()
    {
        print("旋转");
        picoCamera.transform.RotateAround(flowerCenter.transform.position, picoCamera.transform.up, -rotateSpeed * Time.deltaTime);
    }
}
