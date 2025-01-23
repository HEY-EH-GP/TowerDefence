//using System;

public enum TargetType
{
    First,
    Last,
    Close,
    Strong
}

public enum TurretType
{
    Monkey,
    Cannon,
    Spike
}

public enum UpgradePath
{
    PathA,
    PathB
}

public enum AIStates
{
    None,
    SearchFlag,
    AttackFlag,
    AttackPlayer,
    Dead,
}

//[Flags]
//public enum AIStates
//{
//    None = 0,
//    AttackFlag = 1 << 0,
//    AttackPlayer = 1 << 1,
//    Dead = 1 << 2,
//}