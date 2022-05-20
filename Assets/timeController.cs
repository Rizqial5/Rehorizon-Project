using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : MonoBehaviour
{
    public int hour = 0;
    public float minutes = 0;
    public int dayCount = 0;
    public string dayStatus = "AM";
    void Update()
    {
        if (minutes < 60){
            minutes+=Time.deltaTime+0.05f;
        }else{
            hour+=1;
            minutes = 0;
        }

        if (hour > 23){
            hour = 0;
            dayCount+=1;
        }

        if (hour >= 12){
            dayStatus ="PM";
        }else if(hour < 12){
            dayStatus = "AM";
        }
    }

    public int Get_Minutes(){
        int convToInt = (int)Mathf.Round(minutes);
        return convToInt;
    }

    public int Get_Hour(){
        return hour;
    }

    public string Get_DayStatus(){
        return dayStatus;
    }

    public int Get_DayCount(){
        return dayCount;
    }

    public string Get_FullTime(){
        string fulltime = string.Format("{0:00}:{1:00} {2}", hour, Get_Minutes(), dayStatus);
        return fulltime;
    }
}
