using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
public class EnterCarTrigger : MonoBehaviour
{
	public CarUserControl carusercontrol;
	public CarController carcontroller;
	public CarAudio caraudio;
	public GameObject Player;
	public GameObject carcamera;
	public Transform exitpoint;

	public string enterkey = "f";
	public string exitkey = "r";
	private float oldpitch;
	private bool canenter;
	private bool incar;
	// Use this for initialization
	void Start()
	{
		oldpitch = caraudio.pitchMultiplier;
		caraudio.pitchMultiplier = 0.0f;

	}

	// Update is called once per frame
	void FixedUpdate()
	{


		if (Player == null)
		{
			Player = FindObjectOfType<PlayerController>().gameObject;
		}

		if (canenter == true)
		{
			if (Input.GetKeyDown(enterkey))
			{
				Player.transform.parent = exitpoint;
				Player.transform.localPosition = new Vector3(-1.5f, 0f, 0f);
				Player.SetActive(false);
				carcamera.SetActive(true);
				carusercontrol.enabled = true;
				carcontroller.enabled = true;
				caraudio.pitchMultiplier = oldpitch;
				canenter = false;
				incar = true;
				print("entered");
			}

		}

		if (incar == true)
		{
			if (Input.GetKeyDown(exitkey))
			{
				Player.SetActive(true);
				Player.transform.parent = null;
				carcamera.SetActive(false);
				carusercontrol.enabled = false;
				carcontroller.enabled = false;
				caraudio.pitchMultiplier = 0;
				canenter = false;
				incar = false;
				print("exited");



			}

		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			canenter = true;


		}



	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			canenter = false;


		}



	}
}
