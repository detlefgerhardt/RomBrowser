
namespace RomBrowser
{
	partial class RomInfo
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.RomImagePb = new System.Windows.Forms.PictureBox();
			this.RomInfoGb = new System.Windows.Forms.GroupBox();
			this.CompareLbl = new System.Windows.Forms.Label();
			this.CompareCb = new System.Windows.Forms.CheckBox();
			this.SignatureLbl = new System.Windows.Forms.Label();
			this.SignatureTb = new System.Windows.Forms.TextBox();
			this.StartAddrCb = new System.Windows.Forms.CheckBox();
			this.StartAddrLbl = new System.Windows.Forms.Label();
			this.StartAddrTb = new System.Windows.Forms.TextBox();
			this.Crc32Lbl = new System.Windows.Forms.Label();
			this.Crc32Tb = new System.Windows.Forms.TextBox();
			this.Sha1Tb = new System.Windows.Forms.TextBox();
			this.Sha1Lbl = new System.Windows.Forms.Label();
			this.ChksumTb = new System.Windows.Forms.TextBox();
			this.ChksumLbl = new System.Windows.Forms.Label();
			this.SizeLbl = new System.Windows.Forms.Label();
			this.SizeTb = new System.Windows.Forms.TextBox();
			this.FileNameTb = new System.Windows.Forms.TextBox();
			this.FileNameLbl = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.RomImagePb)).BeginInit();
			this.RomInfoGb.SuspendLayout();
			this.SuspendLayout();
			// 
			// RomImagePb
			// 
			this.RomImagePb.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.RomImagePb.Location = new System.Drawing.Point(6, 19);
			this.RomImagePb.Name = "RomImagePb";
			this.RomImagePb.Size = new System.Drawing.Size(97, 193);
			this.RomImagePb.TabIndex = 3;
			this.RomImagePb.TabStop = false;
			// 
			// RomInfoGb
			// 
			this.RomInfoGb.Controls.Add(this.CompareLbl);
			this.RomInfoGb.Controls.Add(this.CompareCb);
			this.RomInfoGb.Controls.Add(this.SignatureLbl);
			this.RomInfoGb.Controls.Add(this.SignatureTb);
			this.RomInfoGb.Controls.Add(this.StartAddrCb);
			this.RomInfoGb.Controls.Add(this.StartAddrLbl);
			this.RomInfoGb.Controls.Add(this.StartAddrTb);
			this.RomInfoGb.Controls.Add(this.Crc32Lbl);
			this.RomInfoGb.Controls.Add(this.Crc32Tb);
			this.RomInfoGb.Controls.Add(this.Sha1Tb);
			this.RomInfoGb.Controls.Add(this.Sha1Lbl);
			this.RomInfoGb.Controls.Add(this.ChksumTb);
			this.RomInfoGb.Controls.Add(this.ChksumLbl);
			this.RomInfoGb.Controls.Add(this.SizeLbl);
			this.RomInfoGb.Controls.Add(this.SizeTb);
			this.RomInfoGb.Controls.Add(this.FileNameTb);
			this.RomInfoGb.Controls.Add(this.FileNameLbl);
			this.RomInfoGb.Controls.Add(this.RomImagePb);
			this.RomInfoGb.Location = new System.Drawing.Point(0, 3);
			this.RomInfoGb.Name = "RomInfoGb";
			this.RomInfoGb.Size = new System.Drawing.Size(413, 216);
			this.RomInfoGb.TabIndex = 4;
			this.RomInfoGb.TabStop = false;
			this.RomInfoGb.Text = "ROM #1";
			// 
			// CompareLbl
			// 
			this.CompareLbl.AutoSize = true;
			this.CompareLbl.Location = new System.Drawing.Point(337, 197);
			this.CompareLbl.Name = "CompareLbl";
			this.CompareLbl.Size = new System.Drawing.Size(49, 13);
			this.CompareLbl.TabIndex = 22;
			this.CompareLbl.Text = "Compare";
			// 
			// CompareCb
			// 
			this.CompareCb.AutoSize = true;
			this.CompareCb.Location = new System.Drawing.Point(390, 198);
			this.CompareCb.Name = "CompareCb";
			this.CompareCb.Size = new System.Drawing.Size(15, 14);
			this.CompareCb.TabIndex = 21;
			this.CompareCb.UseVisualStyleBackColor = true;
			this.CompareCb.Click += new System.EventHandler(this.CompareCb_Click);
			// 
			// SignatureLbl
			// 
			this.SignatureLbl.AutoSize = true;
			this.SignatureLbl.Location = new System.Drawing.Point(110, 126);
			this.SignatureLbl.Name = "SignatureLbl";
			this.SignatureLbl.Size = new System.Drawing.Size(55, 13);
			this.SignatureLbl.TabIndex = 20;
			this.SignatureLbl.Text = "Signature:";
			// 
			// SignatureTb
			// 
			this.SignatureTb.Location = new System.Drawing.Point(166, 123);
			this.SignatureTb.Name = "SignatureTb";
			this.SignatureTb.ReadOnly = true;
			this.SignatureTb.Size = new System.Drawing.Size(239, 20);
			this.SignatureTb.TabIndex = 19;
			// 
			// StartAddrCb
			// 
			this.StartAddrCb.AutoSize = true;
			this.StartAddrCb.Location = new System.Drawing.Point(391, 49);
			this.StartAddrCb.Name = "StartAddrCb";
			this.StartAddrCb.Size = new System.Drawing.Size(15, 14);
			this.StartAddrCb.TabIndex = 18;
			this.StartAddrCb.UseVisualStyleBackColor = true;
			this.StartAddrCb.Click += new System.EventHandler(this.StartAddrCb_Click);
			// 
			// StartAddrLbl
			// 
			this.StartAddrLbl.AutoSize = true;
			this.StartAddrLbl.Location = new System.Drawing.Point(279, 48);
			this.StartAddrLbl.Name = "StartAddrLbl";
			this.StartAddrLbl.Size = new System.Drawing.Size(53, 13);
			this.StartAddrLbl.TabIndex = 17;
			this.StartAddrLbl.Text = "Startaddr:";
			// 
			// StartAddrTb
			// 
			this.StartAddrTb.Location = new System.Drawing.Point(338, 45);
			this.StartAddrTb.Name = "StartAddrTb";
			this.StartAddrTb.ReadOnly = true;
			this.StartAddrTb.Size = new System.Drawing.Size(48, 20);
			this.StartAddrTb.TabIndex = 16;
			// 
			// Crc32Lbl
			// 
			this.Crc32Lbl.AutoSize = true;
			this.Crc32Lbl.Location = new System.Drawing.Point(285, 74);
			this.Crc32Lbl.Name = "Crc32Lbl";
			this.Crc32Lbl.Size = new System.Drawing.Size(47, 13);
			this.Crc32Lbl.TabIndex = 15;
			this.Crc32Lbl.Text = "CRC 32:";
			// 
			// Crc32Tb
			// 
			this.Crc32Tb.Location = new System.Drawing.Point(338, 71);
			this.Crc32Tb.Name = "Crc32Tb";
			this.Crc32Tb.ReadOnly = true;
			this.Crc32Tb.Size = new System.Drawing.Size(67, 20);
			this.Crc32Tb.TabIndex = 14;
			// 
			// Sha1Tb
			// 
			this.Sha1Tb.Location = new System.Drawing.Point(166, 97);
			this.Sha1Tb.Name = "Sha1Tb";
			this.Sha1Tb.ReadOnly = true;
			this.Sha1Tb.Size = new System.Drawing.Size(240, 20);
			this.Sha1Tb.TabIndex = 13;
			this.Sha1Tb.Text = "bbef422eb67d595feca448a3277d5d039f1b24fa";
			// 
			// Sha1Lbl
			// 
			this.Sha1Lbl.AutoSize = true;
			this.Sha1Lbl.Location = new System.Drawing.Point(110, 101);
			this.Sha1Lbl.Name = "Sha1Lbl";
			this.Sha1Lbl.Size = new System.Drawing.Size(38, 13);
			this.Sha1Lbl.TabIndex = 12;
			this.Sha1Lbl.Text = "SHA1:";
			// 
			// ChksumTb
			// 
			this.ChksumTb.Location = new System.Drawing.Point(165, 71);
			this.ChksumTb.Name = "ChksumTb";
			this.ChksumTb.ReadOnly = true;
			this.ChksumTb.Size = new System.Drawing.Size(67, 20);
			this.ChksumTb.TabIndex = 9;
			// 
			// ChksumLbl
			// 
			this.ChksumLbl.AutoSize = true;
			this.ChksumLbl.Location = new System.Drawing.Point(109, 75);
			this.ChksumLbl.Name = "ChksumLbl";
			this.ChksumLbl.Size = new System.Drawing.Size(50, 13);
			this.ChksumLbl.TabIndex = 8;
			this.ChksumLbl.Text = "ChkSum:";
			// 
			// SizeLbl
			// 
			this.SizeLbl.AutoSize = true;
			this.SizeLbl.Location = new System.Drawing.Point(109, 49);
			this.SizeLbl.Name = "SizeLbl";
			this.SizeLbl.Size = new System.Drawing.Size(30, 13);
			this.SizeLbl.TabIndex = 7;
			this.SizeLbl.Text = "Size:";
			// 
			// SizeTb
			// 
			this.SizeTb.Location = new System.Drawing.Point(165, 45);
			this.SizeTb.Name = "SizeTb";
			this.SizeTb.ReadOnly = true;
			this.SizeTb.Size = new System.Drawing.Size(67, 20);
			this.SizeTb.TabIndex = 6;
			// 
			// FileNameTb
			// 
			this.FileNameTb.Location = new System.Drawing.Point(165, 19);
			this.FileNameTb.Name = "FileNameTb";
			this.FileNameTb.ReadOnly = true;
			this.FileNameTb.Size = new System.Drawing.Size(240, 20);
			this.FileNameTb.TabIndex = 5;
			// 
			// FileNameLbl
			// 
			this.FileNameLbl.AutoSize = true;
			this.FileNameLbl.Location = new System.Drawing.Point(109, 21);
			this.FileNameLbl.Name = "FileNameLbl";
			this.FileNameLbl.Size = new System.Drawing.Size(38, 13);
			this.FileNameLbl.TabIndex = 4;
			this.FileNameLbl.Text = "Name:";
			// 
			// RomInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.RomInfoGb);
			this.Name = "RomInfo";
			this.Size = new System.Drawing.Size(413, 219);
			this.Resize += new System.EventHandler(this.RomInfo_Resize);
			((System.ComponentModel.ISupportInitialize)(this.RomImagePb)).EndInit();
			this.RomInfoGb.ResumeLayout(false);
			this.RomInfoGb.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox RomImagePb;
		private System.Windows.Forms.GroupBox RomInfoGb;
		private System.Windows.Forms.Label FileNameLbl;
		private System.Windows.Forms.TextBox FileNameTb;
		private System.Windows.Forms.Label SizeLbl;
		private System.Windows.Forms.TextBox SizeTb;
		private System.Windows.Forms.Label ChksumLbl;
		private System.Windows.Forms.TextBox ChksumTb;
		private System.Windows.Forms.TextBox Sha1Tb;
		private System.Windows.Forms.Label Sha1Lbl;
		private System.Windows.Forms.Label Crc32Lbl;
		private System.Windows.Forms.TextBox Crc32Tb;
		private System.Windows.Forms.Label StartAddrLbl;
		private System.Windows.Forms.TextBox StartAddrTb;
		private System.Windows.Forms.CheckBox StartAddrCb;
		private System.Windows.Forms.Label SignatureLbl;
		private System.Windows.Forms.TextBox SignatureTb;
		private System.Windows.Forms.Label CompareLbl;
		private System.Windows.Forms.CheckBox CompareCb;
	}
}
