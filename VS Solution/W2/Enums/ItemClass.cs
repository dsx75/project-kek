namespace TaidanaKage.Kek.Wow.W2.Enums;

/// <summary>
/// ItemClass.dbc for version 2.4.3.8606
/// <br/>
/// SubclassMapID - what is this?
/// <br/>
/// Flags:
/// 0x1 for Weapon
/// 0x0 for everything else
/// </summary>
public enum ItemClass : byte
{
    Consumable = 0,
    Container = 1,
    Weapon = 2,
    Gem = 3,
    Armor = 4,
    Reagent = 5,
    Projectile = 6,
    TradeGoods = 7,
    [Obsolete]
    Generic = 8,
    Recipe = 9,
    [Obsolete]
    Money = 10,
    Quiver = 11,
    Quest = 12,
    Key = 13,
    [Obsolete]
    Permanent = 14,
    Miscellaneous = 15
}
