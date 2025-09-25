/*
 * Author: CharSui
 * Created On: 2025.09.16
 * Description: 模块管理器，提供模块的注册和注销功能，以及获取模块的功能
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharFramework.Module
{
	public class ModuleManager
	{
		public static ModuleManager Instance { get; } = new ModuleManager();

		private Dictionary<System.Type, IModule> modules = new Dictionary<System.Type, IModule>(32);

		/// <summary>
		/// 模组注册
		/// </summary>
		/// <param name="module"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
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

		/// <summary>
		/// 注销模组(但不会移除这个模组)
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
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

		public IModule GetModule<T>() where T : IModule
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
}