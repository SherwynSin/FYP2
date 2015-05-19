using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckGrid : MonoBehaviour {
	public int charCount = 1;
	// Use this for initialization
	void Start () {

	}
	void OnMouseDown ()
	{
		GameObject go = GameObject.FindGameObjectWithTag ("PlayerTile");
		MonsterGrid MonsterScript = this.GetComponent<MonsterGrid>();
		if(!MonsterScript.GridCheck(go.name))
		{
			GameObject[] Monster = GameObject.FindGameObjectsWithTag (this.tag);
			foreach (GameObject go2 in Monster )
			{
				MonsterGrid MonsterScript2 = go2.GetComponent<MonsterGrid>();
				if(MonsterScript2.GridCheck(go.name))
				{
					if(go2.tag == this.tag)
					{
						if(MonsterScript2.GridActive)
						{
							MonsterScript2.GridDelete ();
							MonsterScript2.GridActive = false;
						}
						CheckGrid cg = go2.GetComponent<CheckGrid>();
						charCount += cg.charCount;
						Destroy(go2);
						break;
						//Vector3 go2newPos = this.transform.position;
						//go2.transform.position = go2newPos;
					}
				}
			}
		}
	}
	protected List<GameObject> insideMe = new List<GameObject>();

	private void OnTriggerEnter(Collider e)
	{
		//if(e is GameObject)
		//{
		//	if(!this.insideMe.Contains(e.gameObject))
		//	{
		//		this.insideMe.Add(e.gameObject);
		//	}
		//}
		Debug.Log("Collided");
	}
	// Update is called once per frame
	void Update () {
		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 0.5f);
		for (int i = 0; i < hitColliders.Length; i++) {
			if(hitColliders[i].name != "Terrain" && hitColliders[i].name != "Trigger" &&
			   hitColliders[i].name != this.name)
			Debug.Log(hitColliders[i].name);
		}
	}
}
