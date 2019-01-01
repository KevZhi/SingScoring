Please roll down and **skip Chinese for English version**  of README.md
# SingScoring

使用 Unity 3D 实现的一个简单的歌唱评分系统，核心的音高识别功能基于 PureData 的 sigmund~ 模块。通过将 sigmund~ 识别出的 MIDI 将信息输出至 Unity 3D 进行处理。有声音稳定性测试、音域测试、音准测试三个模块。

因为本品只是个学生作业，受我们的水平限制，**这个程序并不是打开就能用，是由两个独立的程序模块构成**。作者主要目的在于学习与实践Unity、MIDI的相关知识，请您理解。

您可以在 [release](https://github.com/KevZhi/SingScoring/releases) 页面直接下载编译好的可执行程序。

## 如何使用本程序
    运行这个程序前，您需要配置好系统上的IAC Bus，修改PureData的设置，使sigmud~的识别结果输出到指定的MIDI通道，
    Unity开发的主程序便可接受sigmud识别出的音高和音量信息。
    PureData的安装包（程序）、pitchDetect.pd、loopMIDI的安装包在源代码文件夹和release的压缩包中均已经提供。

### macOS

1. 去「启动台」，在上方搜索框中搜索并打开「音频MIDI设置」（图标为一个MIDI键盘）。

2. 按下 Command+2 键（或去菜单栏点击窗口——显示MIDI工作室）。

3. 双击IAC驱动程序图标，在新打开的窗口中勾选「设备在线」。

4. 点击「+」图标，添加一个端口。（可随意命名）

5. 双击解压「PureData_mac.zip」，把文件夹内的「pitchDetect.pd」拖动到绿色「PureData」应用的图标上，即可打开。
    （release中的版本不用解压）

6. 点击菜单栏中的「Pd」——「Preference」（第一个）——「MIDI」，将输出端口设定为你在IAC驱动程序中刚刚新建的那个，然后点击OK。

7. 在PureData的主窗口勾选「DSP」左边的勾，随便哼唱一个音调，如果pitchDetect.pd程序窗口中的两个数值在变化，说明正常，就可以运行那个Unity的主程序了。

### Windows 

1. 安装「LoopMIDI」程序并运行。

    （其功能等同于 macOS 中自带的 IAC Bus，只不过Windows并未内建此功能，故只能通过第三方程序实现）

2. 点击左下角的「+」，添加一个端口。（可在右边文本框中随意命名）

3. 安装PureData，打开pitchDetect.pd。

4. 点击菜单栏中的「Pd」——「Preference」（第一个）——「MIDI」，将输出端口设定为你在LoopMIDI中刚刚新建的端口，然后点击OK。

5. 在PureData的主窗口勾选「DSP」左边的勾，随便哼唱一个音调，如果pitchDetect.pd程序窗口中的两个数值在变化，说明正常，就可以运行主程序了。

      
         试用完毕后，建议将设置的IAC Bus恢复原状、删除设置的端口（Windows则是卸载LoopMidi），
         以免影响您今后使用其他音频/MIDI类应用程序。
     真麻烦是不是，没办法...水平不够
        主要原理是PureData将识别结果传输至MIDI通道，由Unity接收。而这个通道需要在系统内部进行虚拟。

## 使用的插件

**MidiJack** 使Unity支持读取MIDI接口信息的插件，
*由 Keijiro Takahashi 开发，MIT 协议*

https://github.com/keijiro/MidiJack

**PureData** 简单易用的开源多媒体可视化编程小工具

http://puredata.info

*从官大为老师的[「好和弦」](https://www.nicechord.com)栏目的一期节目中了解到了这款软件及用法，感谢官大为老师。*

## 已知的缺陷

~~MIDI通道传输的信息只能是0-127的整数，所以音准识别的结果数值输出到MIDI通道后只能是整数，所以只能精确到音，而不是音分。~~

（已在1.1版本中修复，让 Puredata 的 pitchDetect.pd 分离小数，使用了第三个通道来单独传输小数给Unity，Unity再进行拼接，音准测试的精确度从【差一个音以内都算准】变成了【差20音分以内才算准】）


***
# SingScoring

A simple singing scoring system based on Unity 3D, core pitch recognization function working on PureData - sigmund~. Sigmund~ pass the recognized data to Unity 3D via MIDI channel. This app contains 3 modules: Pitch accurate, Pitch Range, Voice Stablitiy.

Go to [release](https://github.com/KevZhi/SingScoring/releases) to get the pre-complied executable.

This project is student homework, don't expect too much about it.The main purpose of developing this app was just learn and practice Unity3D.  It consist of two independet modules, and it's not plug and play, so you need to do some configure before running as the instructions below.

## How to use this application?
    Before run this app, you need to configure IAC bus and Puredata settings as instructions provided below.
    Which will make Unity receive the MIDI infomation from Puredata.

### macOS

1. Go to Launchpad, search and open MIDI settings(MIDI Keyboard icon).

2. Press Command+2 (Or Click on menubar -- window -- show MIDI studio）

3. Double click on IAC , tick "Device Online"

4. Click "+" button on  left, add a port (you can name it whatever you want)

5. Unzip the PureData_mac.zip , and drag pitchDetect.pd to the PureData Application to open the script.

6. Click Menubar - Pd - Prefrences (first one) - MIDI, select output Device as the one you added in IAC Bus settings, then click OK.

7. Tick "DSP" on main window of Puredata, try to hum something, You'll see the pitchDetect.pd window, two parameters are changing, then you're able to run the main executable created by Unity

### Windows

1. Run "LoopMIDI.exe" to install LoopMIDI.(A third party application equals to IAC bus in macOS, as Windows doesn't have a IAC Bus-like stuff built-in)

2. Click "+" button on bottom left, add a port (you can name it whatever you want)

3. Install PureData, and open pitchDetect.pd

4. Click Menubar - Pd - Prefrences (1st one) - MIDI, select output Device as the one you added in IAC, then click OK.

5. Tick "DSP" on main window of Puredata, try to hum something, You'll see the pitchDetect.pd window two parameters are changing, then you're able to run the main executable created by Unity

    We suggest you to remove the IAC bus setting or delete the LoopMIDI after using our App, 
    for not making any trouble when you use any MIDI-releated app in the future.


## Denpendency

   **Midijack**  *A midi plugin for Unity3D by Keijiro Takahashi,Use under MIT Licence* 
   
https://github.com/keijiro/MidiJack

**PureData** An open source visual programming language for multimedia.

http://puredata.info

*Thanks Wiwi Kuan for his [「NiceChord」](https://www.nicechord.com) Channel, from where I know this software.*

## Known issues

~~MIDI channel only transfer 8 bit int. So all value on MIDI was 0-127 without decimals, the pitch accurate can only tell between note, and cannot make it accurate to cent.~~


(Fixed in ver 1.1, pitchDetect.pd now seperatly output decimals to MIDI channel 3 which was unused before, so Unity can receive both ints and decimals together. The accuracy of intonation test now enhanced to [+-20 cent is accurate], which was [+- a note is accurate] before )
