using System.Collections;

using System.Collections.Generic;

public class BackPack
{
    public float MaxWeight;

    public BackPack(float weight)
    {
        this.MaxWeight = weight;
    }

    public Dictionary<Material,int> MaterialDict= new Dictionary<Material,int>();
    public ArrayList EquipmentList = new ArrayList();
    public float CurrentWeight { get {
            float result = 0;
            foreach (KeyValuePair<Material,int> pair in MaterialDict)
            {
                result += (pair.Key.Weight * pair.Value);
            }
            foreach (Equipment equip in EquipmentList)
            {
                result += equip.Weight;
            }
            return result;
        } }

    public void AddItem(Material material)
    {
        AddItem(material, 1);
    }

    public void AddItem(Material material,int num)
    {
        if (MaterialDict.ContainsKey(material))
        {
            MaterialDict[material] += num;
        }
        else
        {
            MaterialDict.Add(material, num);
        }
    }

    public void AddItem(Equipment equipment)
    {
        this.EquipmentList.Add(equipment);
    }

    // TODO: 重量检查，Material只移入一部分


    
     public void RemoveItem(Material material,int num)
    {
        if (!this.MaterialDict.ContainsKey(material))
        {
            // error
        }
        else
        {
            if (this.MaterialDict[material] > num)
            {
                this.MaterialDict[material] -= num;
                return;
            }
            if (this.MaterialDict[material] == num)
            {
                this.MaterialDict.Remove(material);
                return;
            }
            else
            {
                
                // error
            }
        }
    }
    public void RemoveItem(Material material)
    {
        RemoveItem(material, 1);
    }

    public void RemoveItem(Equipment equipment)
    {
        this.EquipmentList.Remove(equipment);
    }
    public override string ToString()
    {
        string output = "Material: \n";
        foreach (KeyValuePair<Material, int> pair in MaterialDict)
        {
            output += pair.Key.ToString();
            output += pair.Value.ToString();

        }

        output += "Equipment:\n"; 
        foreach (Equipment e in this.EquipmentList)
        {
            output += e.ToString();
        }
        return output;
        
    }
}
