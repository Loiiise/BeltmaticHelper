namespace BeltmaticHelper.DataTypes;

[Flags]
public enum Operator : byte
{
    Adder = 1 << 0,
    Multiplier = 1 << 1,
    Subtractor = 1 << 2,
    Divider = 1 << 3,
    Exponentiaro = 1 << 4,
}