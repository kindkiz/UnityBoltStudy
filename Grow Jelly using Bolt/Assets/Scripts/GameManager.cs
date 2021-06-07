using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Sprite[] JellySpriteList;
    public string[] JellyNameList;
    public int[] JellyJelatinList;
    public int[] JellyGoldList;
    public int[] numGoldList;
    public int[] clickGoldList;

    public Vector3[] PointList;

    public RuntimeAnimatorController[] LevelAc;

    public void ChangeAc(Animator anim, int level)
    {
        anim.runtimeAnimatorController = LevelAc[level - 1];
    }
}
