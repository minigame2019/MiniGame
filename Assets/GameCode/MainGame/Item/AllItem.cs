using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System;
public class AllItem : MonoSingleton<AllItem>
{
    Dictionary<int, Material> MaterialList = new Dictionary<int, Material>();
    Dictionary<int, Equipment> EquipmentList = new Dictionary<int, Equipment>();
    public AllItem()
    {
        LoadXml();
        
    }
    
    private void LoadXml()
    { // TODO: filename
        this.MaterialList.Clear();
        this.EquipmentList.Clear();
        string filename = "";
        try
        {
            XmlDocument x = new XmlDocument();
            x.Load(filename);
            XmlNode xmlNode = x.SelectSingleNode("Item");
            XmlNodeList materialList = xmlNode.SelectSingleNode("Material").ChildNodes;
            XmlNodeList equipmentList = xmlNode.SelectSingleNode("Equipment").ChildNodes;
            foreach (XmlNode node in materialList)
            {
                MaterialList.Add(int.Parse(node.SelectSingleNode("ID").InnerText), new Material(
                    int.Parse(node.SelectSingleNode("ID").InnerText),
                    node.SelectSingleNode("Name").InnerText,
                    float.Parse(node.SelectSingleNode("Weight").InnerText),
                    Item.ItemType.Material,
                    node.SelectSingleNode("Description").InnerText,
                    node.SelectSingleNode("Sprite").InnerText
                    ));
            }

            foreach (XmlNode node in equipmentList)
            {
                EquipmentList.Add(int.Parse(node.SelectSingleNode("ID").InnerText), new Equipment(
                    int.Parse(node.SelectSingleNode("ID").InnerText),
                    node.SelectSingleNode("Name").InnerText,
                    float.Parse(node.SelectSingleNode("Weight").InnerText),
                    Item.ItemType.Material,
                    node.SelectSingleNode("Description").InnerText,
                    node.SelectSingleNode("Sprite").InnerText,
                    int.Parse(node.SelectSingleNode("Damage").InnerText),
                    float.Parse(node.SelectSingleNode("Range").InnerText),
                    float.Parse(node.SelectSingleNode("AttackSpeed").InnerText),
                    int.Parse(node.SelectSingleNode("MaxDurability").InnerText)
                    )); 
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            Debug.Log("All Item Load Failed, Please Reload");
        }
    }
}
