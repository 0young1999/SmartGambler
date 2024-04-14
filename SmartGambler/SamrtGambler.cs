using SmartGambler.Custom.Control;
using SmartGambler.Data;
using SpecialCampaignSkillCoolDown;
using Young.Setting;

namespace SmartGambler
{
	public partial class formMain : Form
	{
		private static formMain instance;
		public static formMain GetInstance()
		{
			if (instance == null) instance = new formMain();
			return instance;
		}


		private Circle[] circles = new Circle[8];
		private keyboardHooker hooker = keyboardHooker.GetKeyboardHooker();
		private csButton button = csButton.GetInstance();
		private Bullet bullet = Bullet.GetInstance();

		private formMain()
		{
			InitializeComponent();
		}

		private void SamrtGambler_Load(object sender, EventArgs e)
		{
			// 사이즈 고정
			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;

			// circle 생성
			for (int i = 0; i < circles.Length; i++)
			{
				circles[i] = new Circle();
				tlpBulletStatus.Controls.Add(circles[i], i, 0);
			}

			// key hook Start
			SetHook();

			keyboardHooker.UpdataKeyboardHookEvent += UpdataKeyboardHook;
			bullet.UpdateDataEvent += UpdateBullet;

			// stauts reset
			UpdataKeyboardHook(null, new keyboardHooker.KeyboardHookEventArg()
			{
				_keyCode = button.RoundClear,
				_lParam = 256,
			});
		}

		private void UpdateBullet(object? sender, Bullet.bulletArgs e)
		{
			this.Invoke((MethodInvoker)delegate
			{
				switch (e.type)
				{
					case Bullet.BulletEnum.Count:
						lblBulletCount.Text = e.value.ToString();
						break;
					case Bullet.BulletEnum.Really:
						lblReally.Text = e.value.ToString();
						break;
					case Bullet.BulletEnum.Lie:
						lblLie.Text = e.value.ToString();
						break;
				}

				SetPersent();
			});
		}

		public void SetPersent()
		{
			this.Invoke((MethodInvoker)delegate
			{
				// persent
				int tempReally = bullet.GetReally();
				int tempLie = bullet.GetLie();
				foreach (Circle item in circles)
				{
					if (item.GetActive() == false)
					{
						if (item.GetStatus() == Circle.CircleStatus.Really)
						{
							tempReally--;
						}
						else if (item.GetStatus() == Circle.CircleStatus.Lie)
						{
							tempLie--;
						}
					}
				}
				if (bullet.GetCount() < 8 && ((bullet.GetReally() == 0 && bullet.GetLie() == 0) == false))
				{
					if (circles[bullet.GetCount()].GetStatus() == Circle.CircleStatus.None)
					{
						if (bullet.GetReally() == 0)
						{
							lblReallyPersent.Text = "0%";
							lblLiePersent.Text = "100%";
						}
						else if (bullet.GetLie() == 0)
						{
							lblReallyPersent.Text = "100%";
							lblLiePersent.Text = "0%";
						}
						else
						{
							lblReallyPersent.Text = GetPerSentText(tempReally, tempReally + tempLie);
							lblLiePersent.Text = GetPerSentText(tempLie, tempReally + tempLie);
						}
					}
					else if (circles[bullet.GetCount()].GetStatus() == Circle.CircleStatus.Really)
					{
						lblReallyPersent.Text = "100%";
						lblLiePersent.Text = "0%";
					}
					else if (circles[bullet.GetCount()].GetStatus() == Circle.CircleStatus.Lie)
					{
						lblReallyPersent.Text = "0%";
						lblLiePersent.Text = "100%";
					}
				}
				else
				{
					lblReallyPersent.Text = lblLiePersent.Text = "N/A";
				}
			});
		}

		private string GetPerSentText(decimal head, decimal body)
		{
			return (((decimal)head) / body).ToString("0.0%");
		}

		private void UpdataKeyboardHook(object? sender, keyboardHooker.KeyboardHookEventArg e)
		{
			if (e._lParam == 256)
			{
				if (e._keyCode == button.RoundClear)
				{
					bullet.Reset();
					foreach (Circle item in circles)
					{
						item.SetStatus(Circle.CircleStatus.None);
						item.SetActive(false);
					}
				}
				else if (e._keyCode == button.ReturnBulletCount)
				{
					if (bullet.GetCount() > 0)
					{
						bullet.SetCount(Bullet.UpDownReset.DOWN);

						switch (circles[bullet.GetCount()].GetStatus())
						{
							case Circle.CircleStatus.Really:
								bullet.SetReally(Bullet.UpDownReset.UP);
								break;
							case Circle.CircleStatus.Lie:
								bullet.SetLie(Bullet.UpDownReset.UP);
								break;
						}

						circles[bullet.GetCount()].SetStatus(Circle.CircleStatus.None);
						circles[bullet.GetCount()].SetActive(false);
					}
				}
				else if (e._keyCode == button.OutBulletReally)
				{
					if (bullet.GetCount() < 8)
					{
						circles[bullet.GetCount()].SetStatus(Circle.CircleStatus.Really);
						circles[bullet.GetCount()].SetActive(true);
						bullet.SetCount(Bullet.UpDownReset.UP);
						bullet.SetReally(Bullet.UpDownReset.DOWN);
					}
				}
				else if (e._keyCode == button.OutBulletLie)
				{
					if (bullet.GetCount() < 8)
					{
						circles[bullet.GetCount()].SetStatus(Circle.CircleStatus.Lie);
						circles[bullet.GetCount()].SetActive(true);
						bullet.SetCount(Bullet.UpDownReset.UP);
						bullet.SetLie(Bullet.UpDownReset.DOWN);
					}
				}
				else if (e._keyCode == button.CountReallyUp)
				{
					if (bullet.GetReally() < 8)
					{
						bullet.SetReally(Bullet.UpDownReset.UP);
					}
				}
				else if (e._keyCode == button.CountReallyDown)
				{
					if (bullet.GetReally() > 0)
					{
						bullet.SetReally(Bullet.UpDownReset.DOWN);
					}
				}
				else if (e._keyCode == button.CountLieUp)
				{
					if (bullet.GetLie() < 8)
					{
						bullet.SetLie(Bullet.UpDownReset.UP);
					}
				}
				else if (e._keyCode == button.CountLieDown)
				{
					if (bullet.GetLie() > 0)
					{
						bullet.SetLie(Bullet.UpDownReset.DOWN);
					}
				}
			}
		}

		private void SetHook()
		{
			List<int> list = new List<int>();
			list.Add(button.RoundClear);
			list.Add(button.OutBulletReally);
			list.Add(button.OutBulletLie);
			list.Add(button.ReturnBulletCount);
			hooker.SetBlockKey(list);
			hooker.SetHook();
		}

		private void btnSetting_Click(object sender, EventArgs e)
		{
			hooker.UnHook();

			SettingForm sf = new SettingForm();
			sf.TopMost = true;
			sf.Text = "설정";
			sf._SetObject(csButton.GetInstance(), "키 설정");
			sf.ShowDialog();

			SetHook();
		}

		private void SamrtGambler_FormClosing(object sender, FormClosingEventArgs e)
		{
			hooker.UnHook();
		}
	}
}
