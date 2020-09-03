using System.Windows.Forms;

namespace ToeKnife.BspEditor.Tools.Entity
{
    partial class EntitySidebarPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntitySidebarPanel));
            this.EntityTypeLabel = new System.Windows.Forms.Label();
            this.EntityTypeList = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // EntityTypeLabel
            // 
            this.EntityTypeLabel.Location = new System.Drawing.Point(3, 0);
            this.EntityTypeLabel.Name = "EntityTypeLabel";
            this.EntityTypeLabel.Size = new System.Drawing.Size(108, 17);
            this.EntityTypeLabel.TabIndex = 9;
            this.EntityTypeLabel.Text = "Entity Type:";
            this.EntityTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EntityTypeList
            // 
            this.EntityTypeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntityTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EntityTypeList.FormattingEnabled = true;
            this.EntityTypeList.Location = new System.Drawing.Point(3, 20);
            this.EntityTypeList.Name = "EntityTypeList";
            this.EntityTypeList.Size = new System.Drawing.Size(194, 21);
            this.EntityTypeList.TabIndex = 5;
            this.EntityTypeList.SelectedIndexChanged += new System.EventHandler(this.EntityTypeList_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(3, 47);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(194, 150);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // EntitySidebarPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.EntityTypeLabel);
            this.Controls.Add(this.EntityTypeList);
            this.MinimumSize = new System.Drawing.Size(200, 50);
            this.Name = "EntitySidebarPanel";
            this.Size = new System.Drawing.Size(200, 203);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label EntityTypeLabel;
        private System.Windows.Forms.ComboBox EntityTypeList;
        private RichTextBox richTextBox1;
    }
}
