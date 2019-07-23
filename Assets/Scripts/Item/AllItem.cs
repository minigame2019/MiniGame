using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System;
public class AllItem : MonoSingleton<AllItem>
{
    public Dictionary<int, InventoryItemBase> ItemDict = new Dictionary<int, InventoryItemBase>();

    public AllItem()
    {
        LoadXml();
    }

    public void LoadXml()
    {
        string filename = ""    ;
        this.ItemDict.Clear();
        try
        {
            XmlDocument x = new XmlDocument();
            x.Load(filename);
            XmlNode xmlNode = x.SelectSingleNode("Item");
            XmlNodeList defaultList = xmlNode.SelectSingleNode("Default").ChildNodes;
            XmlNodeList weaponList = xmlNode.SelectSingleNode("Weapon").ChildNodes;
            foreach (XmlNode node in defaultList)
            {

                Debug.Log(node.SelectSingleNode("ID").InnerText);
                string spriteName = node.SelectSingleNode("Sprite").InnerText;
                Sprite sprite = null;
                ItemDict.Add(int.Parse(node.SelectSingleNode("ID").InnerText), new Default(
                    int.Parse(node.SelectSingleNode("ID").InnerText),
                    node.SelectSingleNode("Name").InnerText,
                    sprite,
                    node.SelectSingleNode("Description").InnerText,
                    EItemType.Default,
                    float.Parse(node.SelectSingleNode("Weight").InnerText)));
            }
        }
        catch(Exception e)
        {
            Debug.Log("Falied To Load Craft XML");
            Debug.Log(e);
        }
    }

}
