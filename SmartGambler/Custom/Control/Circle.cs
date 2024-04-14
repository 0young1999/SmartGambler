using Young.Setting;

namespace SmartGambler.Custom.Control
{
	public partial class Circle : UserControl
	{
		private CircleStatus status = CircleStatus.None;
		private bool isActive = false;
		private int BoarderSize = 4;

		public enum CircleStatus
		{
			None = 0,
			Really = 1,
			Lie = 2,
		}

		public Circle()
		{
			InitializeComponent();
		}

		public bool GetActive()
		{
			return isActive;
		}

		public void SetActive(bool active)
		{
			isActive = active;
			Refresh();
		}

		public void SetStatus(CircleStatus status)
		{
			this.status = status;
			Refresh();
			formMain.GetInstance().SetPersent();
		}

		public CircleStatus GetStatus()
		{
			return status;
		}

		private void Circle_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			Color color = Color.Gray;

			switch (status)
			{
				case CircleStatus.Really:
					color = Color.Red;
					break;
				case CircleStatus.Lie:
					color = Color.Blue;
					break;
			}

			Pen pen = new Pen(Color.Black, BoarderSize);

			if (isActive)
			{
				g.DrawEllipse(pen, BoarderSize / 2, BoarderSize / 2, Size.Width - BoarderSize, Size.Height - BoarderSize);
			}

			SolidBrush sb = new SolidBrush(color);

			g.FillEllipse(sb, BoarderSize, BoarderSize, Size.Width - (BoarderSize * 2), Size.Height - (BoarderSize * 2));
		}

		private void Circle_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				string[] contents =
				{
					"모름",
					"실탄",
					"공포탄"
				};
				formSelected fs = new formSelected("총알 상태", contents);
				fs.TopMost = true;
				if (fs.ShowDialog() == DialogResult.OK)
				{
					switch (fs.result)
					{
						case 0:
							SetStatus(CircleStatus.None);
							break;
						case 1:
							SetStatus(CircleStatus.Really);
							break;
						case 2:
							SetStatus(CircleStatus.Lie);
							break;
					}
				}
			}
		}
	}
}
