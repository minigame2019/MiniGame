public class Equipment : Item
{
    public int Damage;
    public float Range;
    public float AttackSpeed;
    public int MaxDurability;
    public int CurrentDurability;

    public Equipment(int id, string name, float weight, ItemType itemType, string des, string sprite, int damage, float range, float attackspeed, int maxdurability)
        : base(id, name, weight, itemType, des, sprite)
    {
        this.Damage = damage;
        this.Range = range;
        this.AttackSpeed = attackspeed;
        this.MaxDurability = maxdurability;
        this.CurrentDurability = this.MaxDurability;
    }
    public Equipment(int id, string name, int weight, ItemType itemType, string des, string sprite, int damage, float range, float attackspeed, int maxdurability, int currentdurability)
        : base(id, name, weight, itemType, des, sprite)
    {
        this.Damage = damage;
        this.Range = range;
        this.AttackSpeed = attackspeed;
        this.MaxDurability = maxdurability;
        this.CurrentDurability = currentdurability;
    }

    public Equipment(Equipment item)
    {
        this.ID = item.ID;
        this.Name = item.Name;
        this.Type = item.Type;
        this.Description = item.Description;
        this.Sprite = item.Sprite;

        this.Range = item.Range;
        this.AttackSpeed = item.AttackSpeed;
        this.Damage = item.Damage;
        this.MaxDurability = item.MaxDurability;
        this.CurrentDurability = item.MaxDurability;
    }

    public override string ToString()
    {
        return "Equipmant"+Name;
    }
}