/*
 * Author: CharSui
 * Created On: 2025.09.16
 * Description: 模块管理器，提供模块的注册和注销功能，以及获取模块的功能
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager
{
	public static moduleManager Instance { get; } = new moduleManager();
	
	private dictionary<System.Type, IModule> modules = new Dictionary<System.Type, IModule>(32);
	
	public void RegisterModule<T>(T module) where T : IModule
	{
		var type = typeof(T);
		if (modules.ContainsKey(type))
		{
			Debug.LogError($"Module of type {type} is already registered.");
			return;
		}
		modules[type] = module;
	}
	
	public void UnregisterModule<T>() where T : IModule
	{
		var type = typeof(T);
		if (!modules.ContainsKey(type))
		{
			Debug.LogError($"Module of type {type} is not registered.");
			return;
		}
		modules.Remove(type);
	}
	
	public Imodule GetModule<T>() where T : IModule
	{
		var type = typeof(T);
		if (modules.TryGetValue(type, out var module))
		{
			return (T)module;
		}
		Debug.LogError($"Module of type {type} is not registered.");
		return default;
	}
}
