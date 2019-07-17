public class Item
{
    #region 属性 
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 物品类型
    /// </summary>
    /// 

    public float Weight { get; set; }

    public ItemType Type { get; set; }

   /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }


    /// <summary>
    /// 图标
    /// </summary>
    public string Sprite { get; set; }

    #endregion 属性

    #region 枚举类型

    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemType
    {
        //Consumable, //消耗品
        Equipment,  //装备
        //Weapon,     //武器
        Material,   //材料
    }



    #endregion 枚举类型

    #region 构造方法

    public Item(int id, string name,float Weight, ItemType itemType, string des, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Weight = Weight;
        this.Type = itemType;
        this.Description = des;
        this.Sprite = sprite;
    }

    public Item(Item item)
    {
        this.ID = item.ID;
        this.Name = item.Name;
        this.Weight = item.Weight;
        this.Type = item.Type;
        this.Description = item.Description;
        this.Sprite = item.Sprite;
    }

    public Item()
    {
        this.ID = -1;
    }
}
    #endregion 构造方法

