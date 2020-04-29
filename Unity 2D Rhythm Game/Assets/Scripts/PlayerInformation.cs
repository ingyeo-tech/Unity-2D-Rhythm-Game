using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInformation
{
    //어디서든 접근가능 mono상속안함. 보안 높음. 프로퍼티 안함. 근데 왜?
    public static int maxCombo { get; set; }
    public static float score { get; set; }
    public static string musicTitle { get; set; }
    public static string musicArtist { get; set; }
}
