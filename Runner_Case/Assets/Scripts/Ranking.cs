﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Ranking : MonoBehaviour
{

    public float []DistanceArrays;

    [Header ("Players Player01 = Player Player")]
    public Transform Player01;
    public Transform Player02;
    public Transform Player03;
    public Transform Player04;
    public Transform Player05;
    public Transform Player06;
    public Transform Player07;
    public Transform Player08;
    public Transform Player09;
    public Transform Player10;
    public Transform Player11;

    #region Variables
    float First;
    float Fourth;
    float Second;
    float Third;
    float Fifth;
    float Sixth;
    float Seventh;
    float Eighth;
    float Ninth;
    float Tenth;
    float Eleventh;
    #endregion

    [Header("UI")]
    public TextMeshProUGUI Player01Text;
    public GameObject NextCheckPoint;

    void Start()
    {
        NextCheckPoint.SetActive(false);
    }

    
    void Update()
    {
        #region Arrays
        DistanceArrays[0] = Vector3.Distance(transform.position, Player01.position);
        DistanceArrays[1] = Vector3.Distance(transform.position, Player02.position);
        DistanceArrays[2] = Vector3.Distance(transform.position, Player03.position);
        DistanceArrays[3] = Vector3.Distance(transform.position, Player04.position);
        DistanceArrays[4] = Vector3.Distance(transform.position, Player05.position);
        DistanceArrays[5] = Vector3.Distance(transform.position, Player06.position);
        DistanceArrays[6] = Vector3.Distance(transform.position, Player07.position);
        DistanceArrays[7] = Vector3.Distance(transform.position, Player08.position);
        DistanceArrays[8] = Vector3.Distance(transform.position, Player09.position);
        DistanceArrays[9] = Vector3.Distance(transform.position, Player10.position);
        DistanceArrays[10] = Vector3.Distance(transform.position, Player11.position);

        Array.Sort(DistanceArrays);

        First = DistanceArrays[0];
        Second = DistanceArrays[1];
        Third = DistanceArrays[2];
        Fourth = DistanceArrays[3];
        Fifth = DistanceArrays[4];
        Sixth = DistanceArrays[5];
        Seventh = DistanceArrays[6];
        Eighth = DistanceArrays[7];
        Ninth = DistanceArrays[8];
        Tenth = DistanceArrays[9];
        Eleventh = DistanceArrays[10];
        #endregion

        float Player01Dist = Vector3.Distance(transform.position, Player01.position);       

        #region Player01UI
        if (Player01Dist == First) {
            Player01Text.text = "1/11";
        }
        if (Player01Dist == Second)
        {
            Player01Text.text = "2/11";
        }
        if (Player01Dist == Third)
        {
            Player01Text.text = "3/11";
        }
        if (Player01Dist == Fourth)
        {
            Player01Text.text = "4/11";
        }
        if (Player01Dist == Fifth)
        {
            Player01Text.text = "5/11";
        }
        if (Player01Dist == Sixth)
        {
            Player01Text.text = "6/11";
        }
        if (Player01Dist == Seventh)
        {
            Player01Text.text = "7/11";
        }
        if (Player01Dist == Eighth)
        {
            Player01Text.text = "8/11";
        }
        if (Player01Dist == Ninth)
        {
            Player01Text.text = "9/11";
        }
        if (Player01Dist == Tenth)
        {
            Player01Text.text = "10/11";
        }
        if (Player01Dist == Eleventh)
        {
            Player01Text.text = "11/11";
        }

        #endregion

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            NextCheckPoint.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}