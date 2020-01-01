using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
public class data : MonoBehaviour {
		public Transform TextTargetName;
		public Transform TextDescription;
		public Transform ButtonAction;
		public Transform PanelDescription;

		public AudioSource soundTarget;
		public AudioClip clipTarget;

		// Use this for initialization
		void Start()
		{
			//add Audio Source as new game object component
			soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
		}

		// Update is called once per frame
		void Update()
		{
			StateManager sm = TrackerManager.Instance.GetStateManager();
			IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

			foreach (TrackableBehaviour tb in tbs)
			{
				string name = tb.TrackableName;
				ImageTarget it = tb.Trackable as ImageTarget;
				Vector2 size = it.GetSize();

				Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);

				//Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

				TextTargetName.GetComponent<Text>().text = name;
				ButtonAction.gameObject.SetActive(true);
				TextDescription.gameObject.SetActive(true);
				PanelDescription.gameObject.SetActive(true);


				//If the target name was “zombie” then add listener to ButtonAction with location of the zombie sound (locate in Resources/sounds folder) and set text on TextDescription a description of the zombie

				if(name == "buddha_thi"){
					ButtonAction.GetComponent<Button> ().onClick.AddListener (delegate {
						playSound ("sounds/A Loop In Time by Wally Brill");
					});
						TextDescription.GetComponent<Text>().text = "Despite cultural and regional differences in the interpretations of texts about the life of Gautama Buddha, there are some general guidelines to the attributes of a Buddharupa:.";
				}



				//If the target name was “unitychan” then add listener to ButtonAction with location of the unitychan sound (locate in Resources/sounds folder) and set text on TextDescription a description of the unitychan / robot

			if (name == "Ramses")
			{
				ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("dr"); });
					TextDescription.GetComponent<Text>().text = "was the third pharaoh of the Nineteenth Dynasty of Egypt. He often is regarded as the greatest, most celebrated, and most powerful pharaoh of the Egyptian Empire His successors and later Egyptians called him the \"Great Ancestor\". He is known as Ozymandias in the Greek sources,from a transliteration into Greek of a part of Ramesses' throne name";
			}
				if (name == "Nefertiti")
				{
					ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("dr"); });
					TextDescription.GetComponent<Text>().text = "was an Egyptian queen and the Great Royal Wife (chief consort) of Akhenaten, an Egyptian Pharaoh. Nefertiti and her husband were known for a religious revolution, in which they worshiped one god only, Aten, or the sun disc. With her husband, she reigned at what was arguably the wealthiest period of Ancient Egyptian history.Some scholars believe that Nefertiti ruled briefly as Neferneferuaten after her husband's death and before the accession of Tutankhamun, although this identification is a matter of ongoing debate.If Nefertiti did rule as Pharaoh, her reign was marked by the fall of Amarna and relocation of the capital back to the traditional city of Thebes.\n\nNefertiti had many titles including Hereditary Princess (iryt-p`t); Great of Praises (wrt-hzwt); Lady of Grace (nbt-im3t), Sweet of Love (bnrt-mrwt); Lady of The Two Lands (nbt-t3wy); Main King's Wife, his beloved (hmt-niswt-‘3t meryt.f); Great King's Wife, his beloved (hmt-niswt-wrt meryt.f), Lady of all Women (hnwt-hmwt-nbwt); and Mistress of Upper and Lower Egypt (hnwt-Shm’w-mhw).\n\nShe was made famous by her bust, now in Berlin's Neues Museum, shown to the right. The bust is one of the most copied works of ancient Egypt. It was attributed to the sculptor Thutmose, and it was found in his workshop. The bust is notable for exemplifying the understanding Ancient Egyptians had regarding realistic facial proportions.[citation needed]";
				}
			}
		}

		//function to play sound
		void playSound(string ss){
			clipTarget = (AudioClip)Resources.Load (ss);
			soundTarget.clip = clipTarget;
			soundTarget.loop = false;
			soundTarget.playOnAwake = false;
			soundTarget.Play();
		}

}
}