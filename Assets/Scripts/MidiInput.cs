using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using System;

public class MidiInput : MonoBehaviour
{

    public int pitch;
    public int volume;

    void Start()
    {
    }

    void Update()
    {
        float pit = MidiMaster.GetKnob(1);
        pit = pit * 128;
        pitch = (int)pit;
        //print("Pitch = " + pitch);
        float vol = MidiMaster.GetKnob(2);
        vol = vol * 128;
        volume = (int)vol;

    }

}


/* 
 * 音域测试：
 * 下方展示一个键盘图片，上方每个键对应一个小灯（可以改变颜色），共35个灯，每个小灯对应一个音高（pitch）的MIDI编号（36-74）。
 * 当volume达到阈值，屏幕上显示当前的pitch数值-——》转换为音名（有一一对应关系，60-C4，61=C#4,62=D4）
 * 且pitch稳定在一个数1秒后，对应的小灯亮起
 * 任意两个小灯亮起后，中间的所有小灯亮起
 * 
 * 屏幕实时显示两个小灯所对应的音域范围，如D2-C4
 * 屏幕实时显示音域中音的个数，小灯亮起的个数。
 *
 *
 * 声音稳定性测试：
 * 
 * 用户点击开始后，捕捉6秒内volume的数值
 * 1）实时显示Volume数值，
 * 2）计算这六秒内所有捕捉到的volume的所有点的方差。根据算法给出评分
 * 3）如果可以，时刻画出这六秒内采样点的柱形图
 * 
 * 音准测试：
 * 
 * 1）屏幕上显示待测试的10个音音名
 * 2）用户点击开始后，后台播放一个音，播放完成后0.5s开始采集1s的pitch数据。如果70%的采样点的数字为这个音对应的midi编号，则该音唱准了，对应的灯亮绿色，否则亮红色
 * 3）重复第二步，测试完成，得到音准分数

    
    */
