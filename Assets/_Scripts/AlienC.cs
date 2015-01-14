using UnityEngine;
using System.Collections;

public class AlienC : MonoBehaviour {

	public Projectile projectilePrefab;
	public float attackDelay = 3f;

	Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();			

		if (attackDelay > 0) {
			StartCoroutine(OnAttack());
		}
	}
	
	void Update () {
		animator.SetInteger("AnimationState", 0);	
	}

	IEnumerator OnAttack() {
		yield return new WaitForSeconds(attackDelay);
		Fire();
		StartCoroutine(OnAttack());
	}

	void Fire() {
		animator.SetInteger("AnimationState", 1);	
	}

	void OnShoot() {
		Instantiate(projectilePrefab, transform.position, Quaternion.identity);	
	}
}
