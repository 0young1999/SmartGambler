namespace SmartGambler
{
	partial class formMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
			btnSetting = new Button();
			tlpBulletStatus = new TableLayoutPanel();
			lblBulletCount = new Label();
			lblReally = new Label();
			lblLie = new Label();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			lblReallyPersent = new Label();
			lblLiePersent = new Label();
			SuspendLayout();
			// 
			// btnSetting
			// 
			resources.ApplyResources(btnSetting, "btnSetting");
			btnSetting.Name = "btnSetting";
			btnSetting.TabStop = false;
			btnSetting.UseVisualStyleBackColor = true;
			btnSetting.Click += btnSetting_Click;
			// 
			// tlpBulletStatus
			// 
			resources.ApplyResources(tlpBulletStatus, "tlpBulletStatus");
			tlpBulletStatus.Name = "tlpBulletStatus";
			// 
			// lblBulletCount
			// 
			resources.ApplyResources(lblBulletCount, "lblBulletCount");
			lblBulletCount.Name = "lblBulletCount";
			// 
			// lblReally
			// 
			resources.ApplyResources(lblReally, "lblReally");
			lblReally.ForeColor = Color.Red;
			lblReally.Name = "lblReally";
			// 
			// lblLie
			// 
			resources.ApplyResources(lblLie, "lblLie");
			lblLie.ForeColor = Color.Blue;
			lblLie.Name = "lblLie";
			// 
			// label1
			// 
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(label2, "label2");
			label2.ForeColor = Color.Red;
			label2.Name = "label2";
			// 
			// label3
			// 
			resources.ApplyResources(label3, "label3");
			label3.ForeColor = Color.Blue;
			label3.Name = "label3";
			// 
			// lblReallyPersent
			// 
			resources.ApplyResources(lblReallyPersent, "lblReallyPersent");
			lblReallyPersent.ForeColor = Color.Red;
			lblReallyPersent.Name = "lblReallyPersent";
			// 
			// lblLiePersent
			// 
			resources.ApplyResources(lblLiePersent, "lblLiePersent");
			lblLiePersent.ForeColor = Color.Blue;
			lblLiePersent.Name = "lblLiePersent";
			// 
			// SamrtGambler
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.None;
			Controls.Add(lblLiePersent);
			Controls.Add(lblReallyPersent);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(lblLie);
			Controls.Add(lblReally);
			Controls.Add(lblBulletCount);
			Controls.Add(tlpBulletStatus);
			Controls.Add(btnSetting);
			DoubleBuffered = true;
			MaximizeBox = false;
			MdiChildrenMinimizedAnchorBottom = false;
			Name = "SamrtGambler";
			SizeGripStyle = SizeGripStyle.Hide;
			TopMost = true;
			FormClosing += SamrtGambler_FormClosing;
			Load += SamrtGambler_Load;
			ResumeLayout(false);
		}

		#endregion

		private Button btnSetting;
		private TableLayoutPanel tlpBulletStatus;
		private Label lblBulletCount;
		private Label lblReally;
		private Label lblLie;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label lblReallyPersent;
		private Label lblLiePersent;
	}
}
