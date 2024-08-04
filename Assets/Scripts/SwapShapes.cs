using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject shape1;  // ������ ������ (��������, �����)
    public GameObject shape2;  // ������ ������ (��������, ���)
    private bool isUsingArrowKeys = true;

    private void Start()
    {
        SwapPositions();
        SwapPositions();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))  // ���������� Tab ��� ������ �������
        {
            SwapPositions();
        }
    }

    void SwapPositions()
    {
        // ���������� ������� ������� �����
        Vector3 shape1Position = shape1.transform.position;
        Vector3 shape2Position = shape2.transform.position;

        // ���������� ������� ������ �����
        Renderer shape1Renderer = shape1.GetComponent<Renderer>();
        Renderer shape2Renderer = shape2.GetComponent<Renderer>();
        Color shape1Color = shape1Renderer.material.color;
        Color shape2Color = shape2Renderer.material.color;

        // ����� ���������
        shape1.transform.position = shape2Position;
        shape2.transform.position = shape1Position;

        // ���������� ������
        shape1Renderer.material.color = shape2Color;
        shape2Renderer.material.color = shape1Color;

        SwapControls();
    }

    void SwapControls()
    {
        SphereController SphereControll = shape1.GetComponent<SphereController>();
        CubeController CubeControll = shape2.GetComponent<CubeController>();

        isUsingArrowKeys = !isUsingArrowKeys;

        if (isUsingArrowKeys)
        {
            shape1.GetComponent<CubeController>().enabled = true;
            shape1.GetComponent<SphereController>().enabled = false;
            shape2.GetComponent<CubeController>().enabled = false;
            shape2.GetComponent<SphereController>().enabled = true;
        }
        else
        {
            shape1.GetComponent<CubeController>().enabled = false;
            shape1.GetComponent<SphereController>().enabled = true;
            shape2.GetComponent<CubeController>().enabled = true;
            shape2.GetComponent<SphereController>().enabled = false;
        }
    }
}
