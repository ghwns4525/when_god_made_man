// BuildingButton
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
	public Button earnButton;

	public GameObject warnpopup;

	public GameObject buildingPanel;

	public Sprite sprites;

	public Sprite panelsprite;

	public string bname;

	public string statname;

	public Text statInfo;

	public Text repairText;

	public Text upUI;

	public Text downUI;

	public Text Info;

	private Building BD;

	private string bns;

	private int bn;

	public GameObject effect;

	public GameObject Img;

	private void Start()
	{
		this.BD = Building.instance;
		this.bns = base.gameObject.name.Substring(0, 1);
		this.bn = int.Parse(this.bns);
	}
		
	public void PanelOpen()
	{
		OptionManager.Basic (0);
		this.PanelClose ();
		this.buildingPanel.SetActive (true);
		earnButton.onClick.AddListener (this.OnClick);
		this.statInfo = GameObject.Find ("StatInfo").GetComponent<Text> ();
		this.upUI = GameObject.Find ("Name").GetComponent<Text> ();
		this.downUI = GameObject.Find ("Cost").GetComponent<Text> ();
		this.Info = GameObject.Find ("Info").GetComponent<Text> ();
		this.repairText = GameObject.Find ("ButtonText").GetComponent<Text> ();
		this.UpdateUI ();
	}

	public void PanelClose()
	{
		earnButton.onClick.RemoveAllListeners();
		this.buildingPanel.SetActive(false);
	}

	public void OnClick()
	{
		this.UpdateUI();
		if (DataController.instance.gold > (this.BD.buildlv[this.bn] + 1) * 100)
		{
			if (this.BD.buildlv [this.bn] == 0) {
				OptionManager.Basic (0);
				this.newbuild ();
				DataController.instance.gold -= (this.BD.buildlv [this.bn] + 1) * 100;
				this.BD.buildlv [this.bn]++;
				this.BD.textCheck ();
				this.UpdateUI ();
				AchievmentManager.instance.buildcount++;
				this.Ballon ();
			}
			else{
				OptionManager.Basic(0);
				DataController.instance.gold -= (this.BD.buildlv[this.bn] + 1) * 100;
				this.BD.buildlv[this.bn]++;
				this.BD.textCheck();
				this.UpdateUI();
				AchievmentManager.instance.buildcount++;
				this.Ballon();
			}
		}
		else
		{
			Object.Instantiate(this.warnpopup).transform.SetParent(GameObject.Find("Building").transform, false);
		}
		this.UpdateUI();
	}

	public void newbuild()
	{
		base.gameObject.GetComponentsInChildren<Image>()[1].sprite = this.sprites;
	}

	public void UpdateUI()
	{
		GameObject.Find("PanelImage").GetComponent<Image>().sprite = this.panelsprite;
		this.Info.text = "LV " + this.BD.buildlv[this.bn] + "   1초 당 " + this.BD.buildlv[this.bn] * 3 + "개";
		this.upUI.text = this.bname;
		this.statInfo.text = "\"" + this.statname + "\"을 생성합니다.";
		this.downUI.text = ((this.BD.buildlv[this.bn] + 1) * 100).ToString() + "$";
		if (this.BD.buildlv[this.bn] == 0)
		{
			this.repairText.text = "수 리";
		}
		else
		{
			this.repairText.text = "업그레이드";
		}
	}

	public void Ballon()
	{
		Vector3 position = this.Img.transform.position;
		float num = position.y;
		Vector3 position2 = this.Img.transform.position;
		float x = position2.x;
		float y = num;
		Vector3 position3 = this.Img.transform.position;
		Vector3 position4 = new Vector3(x, y, position3.z);
		if (bn != 5) {
			GameObject gameObject = Object.Instantiate (this.effect, position4, Quaternion.identity);
			gameObject.transform.parent = this.Img.transform;
		}
	}
    public string show(int a)
    {
        float num = 0f;
        if (a <= 999)
        {
            num = (float)a;
            return num.ToString();
        }
        else if (a >= 1000 && a <= 999999)
        {
            num = (float)a / 1000f - 0.05f;
            return num.ToString("F1") + "K";
        }
        else if (a >= 1000000)
        {
            num = (float)a / 1000000f - 0.05f;
            return num.ToString("F1") + "M";
        }
        else
            return a.ToString();
    }
}
