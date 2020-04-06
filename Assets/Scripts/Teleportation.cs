using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Teleportation : MonoBehaviour
{
	public GameObject Portal;
	public GameObject Player;
	public Image DoorTransition;
	public SpriteRenderer UpAdvice;

    private void Start()
    {
        DoorTransition.color = new Color(0, 0, 0, 0f);

	}

	private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            UpAdvice.color = new Color(255, 255, 225, 255f);
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            UpAdvice.color = new Color(0, 0, 0, 0f);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				StopAllCoroutines();
				StartCoroutine(Teleport());
			}
		}
	}

	IEnumerator Teleport()
	{

		PlayerState.PlayerControllerState(Player, false);
		DoorTransition.color = new Color(0, 0, 0, 255f);
		yield return new WaitForSeconds(0.5f);
		PlayerState.PlayerTransformPosition(Player, Portal.transform.position);
		yield return new WaitForSeconds(0.5f);
		DoorTransition.color = new Color(0, 0, 0, 0f);
		PlayerState.PlayerControllerState(Player, true);
	}
}
