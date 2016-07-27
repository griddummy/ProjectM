using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Stat  {

    public int requiredExp;        // 현재 레벨에서 다음레벨로 가기 위한 필요 경험치
    public int maxHP;              // 현재 레벨 기본 MaxHP
    public int maxMP;              // 현재 레벨 기본 MaxSP
    public int attackPower;        // 현재 레벨의 기본 공격력
    public int mpRegenerate;       // 기본 분당 회복력
}
