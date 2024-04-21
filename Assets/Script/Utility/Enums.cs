
public enum BattleTurn
{
    None,
    SelectAction,
    Action,
    ActionEnd,
    BattleEnd
}

public enum ActionType
{
    None = 0,
    Skill,
    Attack,
    Defense,
    Item,
    Run
}

public enum CharcterMoveState
{
    ForwardIdle,
    LeftIdle,
    RightIdle,
    BackIdle,
    Move,
    Combat
}