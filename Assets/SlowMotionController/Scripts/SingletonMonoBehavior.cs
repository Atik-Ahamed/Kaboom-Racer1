using UnityEngine;
using System.Collections;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;
	
	public static T Instance {
		get {
			if (instance == null) {
				instance = (T)FindObjectOfType (typeof(T));
				
				if (instance == null) {
					instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
				}
			}
			
			return instance;
		}
	}
	
	protected bool CheckInstance ()
	{
		if (this == Instance) {
			return true;
		}
		Destroy (this);
		return false;
	}
}