
public class Material : Item
{
    public Material(int id, string name, float Weight, ItemType itemType, string des, string sprite):base(id,name,Weight,itemType,des,sprite)
    {
    }


    public override string ToString()
    {
        return "Material" + Name;
    }


    public static bool operator ==(Material i1, Material i2)
    {
        if (object.Equals(i1, null) || object.Equals(i2, null))
        {
            return object.Equals(i1, i2);
        }
        return i1.ID == i2.ID;
    }
    public static bool operator !=(Material i1, Material i2)
    {
        return !(i1 == i2);
    }

}