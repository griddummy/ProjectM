using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public delegate void OnChangedHpEvent(int Hp, int MaxHp);
    public event OnChangedHpEvent OnChangedHP;

    public delegate void OnChangedMpEvent(int Sp, int MaxSp);
    public event OnChangedMpEvent OnChangedMP;

    public delegate void OnDeathEvent(Unit unit);
    public event OnDeathEvent OnDeath;

    public string unitName;             // 유닛 이름

    [SerializeField]
    private int m_Hp;                   // 현재 HP

    [SerializeField]
    private int m_HpMaxBase;            // 기본 맥스 HP

    [SerializeField]
    private int m_HpMaxBuff;            // Buff HP (장비로 인한 추가 HP)


    [SerializeField]
    private int m_Mp;                   // 현재 MP

    [SerializeField]
    private int m_MpMaxBase;            // 기본 Max MP

    [SerializeField]
    private int m_MpMaxBuff;            // 버프로 인한 Max Mp



    [SerializeField]
    private int m_MpRegenerateBase;     // 기본  MP 분당 회복력

    [SerializeField]
    private int m_MpRegenerateBuff;     // 분당 회복력 버프



    [SerializeField]
    private int m_AttackPowerBase;      // 기본 공격력

    [SerializeField]
    private int m_AttackPowerBuff;      // 공격력 버프


    // 프로퍼티(속성)
    public int hp // 현재 Hp를 제어.  get,set
    {
        get
        {
            return m_Hp;
        }
        set
        {
            if (value < 0) // 0보다 작을 수 없고
                value = 0;
            else if (value > hpMax) // Max보다 클 수 없다.
                value = hpMax;
            int preHp = m_Hp;
            m_Hp = value;
            if (preHp != m_Hp)
            {
                if (OnChangedHP != null)
                    OnChangedHP(hp, hpMax);

                if (m_Hp <= 0)
                {
                    if (OnDeath != null)
                        OnDeath(this);
                }
            }
        }
    }
    public int hpMaxBase // 기본 HP Max
    {
        get
        {
            return m_HpMaxBase;
        }
        set
        {
            m_HpMaxBase = value;
        }
    }
    public int hpMax // 최종 Hp Max = 장비로인한 버프 + 기본 유닛 Hp Max
    {
        get
        {
            return m_HpMaxBase + hpMaxBuff;
        }
    }

    public int hpMaxBuff // 아이템으로 인한 Max Hp 증가량 제어 get, set
    {
        get
        {
            return m_HpMaxBuff;
        }
        set
        {
            int preHpMaxBuff = m_HpMaxBuff;
            m_HpMaxBuff = value;
            if (preHpMaxBuff != m_HpMaxBuff)
            {
                if (OnChangedHP != null)
                    OnChangedHP(hp, hpMax);
            }
        }
    }

    public int mp // 현재 Mp를 제어 get,set
    {
        get
        {
            return m_Mp;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > mpMax)
            {
                value = mpMax;
            }
            int premp = m_Mp;
            m_Mp = value;
            if (premp != m_Mp)
            {
                if (OnChangedMP != null)
                    OnChangedMP(m_Mp, mpMax);
            }

        }
    }
    public int mpMaxBase // 기본 Mp를 리턴
    {
        get
        {
            return m_MpMaxBase;
        }
        set
        {
            m_MpMaxBase = value;
        }
    }

    public int mpMax // 현재 Max MP를 얻는다.( 기본 Max MP + Buff Max MP) get
    {
        get
        {
            return mpMaxBase + mpMaxBuff;
        }
    }

    public int mpMaxBuff // 아이템으로 인한 Max Mp 증가량 제어 get, set
    {
        get
        {
            return m_MpMaxBuff;
        }
        set
        {
            int preMpMaxBuff = m_MpMaxBuff;
            m_MpMaxBuff = value;
            if (preMpMaxBuff != m_MpMaxBuff)
            {
                if (OnChangedMP != null)
                    OnChangedMP(m_Mp, mpMax);
            }

        }
    }

    public int mpRegenerate // SP 분당 회복량을 얻는다. get
    {
        get
        {
            return mpRegenerateBase + mpRegenerateBuff;
        }
    }

    public int mpRegenerateBase // 기본 MP 분당 회복력
    {
        get
        {
            return m_MpRegenerateBase;
        }
        set
        {
            m_MpRegenerateBase = value;
        }
    }

    public int mpRegenerateBuff // 아이템으로 인한 SP 분당 회복량 제어 get, set
    {
        get
        {
            return m_MpRegenerateBuff;
        }
        set
        {
            m_MpRegenerateBuff = value;
        }
    }

    public int attackPower      // 전체 공격력을 얻는다 (기본 + 버프) get
    {
        get
        {
            return attackPowerBase + attackPowerBuff;
        }
    }

    public int attackPowerBase  // 기본 공격력을 얻는다. get
    {
        get
        {
            return m_AttackPowerBase;
        }
        set
        {
            m_AttackPowerBase = value;
        }
    }

    public int attackPowerBuff  // 공격력 버프량(아이템으로 인한)을 제어 get, set
    {
        get
        {
            return m_AttackPowerBuff;
        }

        set
        {
            m_AttackPowerBuff = value;
        }
    }

    public virtual void Damage(int damage)
    {

    }
}

