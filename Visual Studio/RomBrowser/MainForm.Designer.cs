
namespace RomBrowser
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DirectoryListView = new System.Windows.Forms.ListView();
			this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FileDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PatternTb = new System.Windows.Forms.TextBox();
			this.ChangeDirBtn = new System.Windows.Forms.Button();
			this.DirRefreshBtn = new System.Windows.Forms.Button();
			this.RomCountCb = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// DirectoryListView
			// 
			this.DirectoryListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.DirectoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FileSize,
            this.FileDate});
			this.DirectoryListView.HideSelection = false;
			this.DirectoryListView.Location = new System.Drawing.Point(12, 39);
			this.DirectoryListView.Name = "DirectoryListView";
			this.DirectoryListView.Size = new System.Drawing.Size(378, 432);
			this.DirectoryListView.TabIndex = 0;
			this.DirectoryListView.UseCompatibleStateImageBehavior = false;
			// 
			// FileName
			// 
			this.FileName.Width = 200;
			// 
			// FileDate
			// 
			this.FileDate.Width = 85;
			// 
			// PatternTb
			// 
			this.PatternTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PatternTb.Location = new System.Drawing.Point(234, 11);
			this.PatternTb.Name = "PatternTb";
			this.PatternTb.Size = new System.Drawing.Size(156, 21);
			this.PatternTb.TabIndex = 1;
			this.PatternTb.Leave += new System.EventHandler(this.PatternTb_Leave);
			// 
			// ChangeDirBtn
			// 
			this.ChangeDirBtn.Location = new System.Drawing.Point(39, 10);
			this.ChangeDirBtn.Name = "ChangeDirBtn";
			this.ChangeDirBtn.Size = new System.Drawing.Size(189, 23);
			this.ChangeDirBtn.TabIndex = 3;
			this.ChangeDirBtn.Text = "Directory";
			this.ChangeDirBtn.UseVisualStyleBackColor = true;
			this.ChangeDirBtn.Click += new System.EventHandler(this.ChangeDirBtn_Click);
			// 
			// DirRefreshBtn
			// 
			this.DirRefreshBtn.Location = new System.Drawing.Point(11, 10);
			this.DirRefreshBtn.Name = "DirRefreshBtn";
			this.DirRefreshBtn.Size = new System.Drawing.Size(22, 23);
			this.DirRefreshBtn.TabIndex = 5;
			this.DirRefreshBtn.Text = "R";
			this.DirRefreshBtn.UseVisualStyleBackColor = true;
			this.DirRefreshBtn.Click += new System.EventHandler(this.DirRefreshBtn_Click);
			// 
			// RomCountCb
			// 
			this.RomCountCb.FormattingEnabled = true;
			this.RomCountCb.Location = new System.Drawing.Point(396, 11);
			this.RomCountCb.Name = "RomCountCb";
			this.RomCountCb.Size = new System.Drawing.Size(46, 21);
			this.RomCountCb.TabIndex = 6;
			this.RomCountCb.SelectedIndexChanged += new System.EventHandler(this.RomCountCb_SelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(818, 483);
			this.Controls.Add(this.RomCountCb);
			this.Controls.Add(this.DirRefreshBtn);
			this.Controls.Add(this.ChangeDirBtn);
			this.Controls.Add(this.PatternTb);
			this.Controls.Add(this.DirectoryListView);
			this.Name = "MainForm";
			this.Text = "ROM-Browser";
			this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView DirectoryListView;
		private System.Windows.Forms.TextBox PatternTb;
		private System.Windows.Forms.Button ChangeDirBtn;
		private System.Windows.Forms.ColumnHeader FileName;
		private System.Windows.Forms.ColumnHeader FileSize;
		private System.Windows.Forms.ColumnHeader FileDate;
		private System.Windows.Forms.Button DirRefreshBtn;
		private System.Windows.Forms.ComboBox RomCountCb;
	}
}

