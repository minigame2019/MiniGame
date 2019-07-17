using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池类
/// </summary>
public class PoolManager : MonoSingleton<PoolManager>
{
	private PoolManager ()
	{
    }

	//存储各类型的对象池的集合
	Dictionary<string,Subpool> poolDic = new Dictionary<string, Subpool> ();

	/// <summary>
	/// 添加对象池的方法
	/// </summary>
	/// <param name="name">Name.</param>
	void Register (string name)
	{
		GameObject obj = Resources.Load (name)as GameObject;
		Subpool subpool = new Subpool (obj);
		poolDic.Add (name, subpool);
	}

	/// <summary>
	/// 获取对象池中游戏对象
	/// </summary>
	/// <param name="name">Name.</param>
	public GameObject Spawn (string name)
	{
		if (!poolDic.ContainsKey (name)) {
			Register (name);
		}
		Subpool subpool = poolDic [name];
		return subpool.SubPoolSpawn ();
	}

	/// <summary>
	/// 回收游戏对象
	/// </summary>
	/// <param name="obj">Object.</param>
	public void UnSpawn (GameObject obj)
	{
		foreach (Subpool item in poolDic.Values) {
			if (item.SubPoolContains (obj)) {
				item.SubPoolUnSpawn (obj);
				break;
			}
		}
	}

	/// <summary>
	/// 清除游戏对象
	/// </summary>
	public void ClearPool ()
	{
		poolDic.Clear ();
	}
}
