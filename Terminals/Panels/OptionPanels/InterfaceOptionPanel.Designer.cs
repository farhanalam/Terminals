﻿using System.Windows.Forms;

namespace Terminals.Panels.OptionPanels
{
    partial class InterfaceOptionPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.chkEnableGroupsMenu = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RenderBlackRadio = new System.Windows.Forms.RadioButton();
            this.RenderBlueRadio = new System.Windows.Forms.RadioButton();
            this.RenderNormalRadio = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkMinimizeToTrayCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBoxInformation = new System.Windows.Forms.GroupBox();
            this.chkInvertTabPageOrder = new System.Windows.Forms.CheckBox();
            this.chkSortTabPagesByCaption = new System.Windows.Forms.CheckBox();
            this.chkShowUserNameInTitle = new System.Windows.Forms.CheckBox();
            this.chkShowInformationToolTips = new System.Windows.Forms.CheckBox();
            this.chkShowFullInfo = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBoxInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox10);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBoxInformation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 331);
            this.panel1.TabIndex = 2;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.chkEnableGroupsMenu);
            this.groupBox10.Location = new System.Drawing.Point(6, 274);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(304, 44);
            this.groupBox10.TabIndex = 26;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Groups";
            // 
            // chkEnableGroupsMenu
            // 
            this.chkEnableGroupsMenu.AutoSize = true;
            this.chkEnableGroupsMenu.Checked = true;
            this.chkEnableGroupsMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableGroupsMenu.Location = new System.Drawing.Point(6, 20);
            this.chkEnableGroupsMenu.Name = "chkEnableGroupsMenu";
            this.chkEnableGroupsMenu.Size = new System.Drawing.Size(126, 17);
            this.chkEnableGroupsMenu.TabIndex = 23;
            this.chkEnableGroupsMenu.Text = "Enable Groups Menu";
            this.chkEnableGroupsMenu.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RenderBlackRadio);
            this.groupBox1.Controls.Add(this.RenderBlueRadio);
            this.groupBox1.Controls.Add(this.RenderNormalRadio);
            this.groupBox1.Location = new System.Drawing.Point(316, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 94);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Theme";
            // 
            // RenderBlackRadio
            // 
            this.RenderBlackRadio.AutoSize = true;
            this.RenderBlackRadio.Location = new System.Drawing.Point(6, 66);
            this.RenderBlackRadio.Name = "RenderBlackRadio";
            this.RenderBlackRadio.Size = new System.Drawing.Size(83, 17);
            this.RenderBlackRadio.TabIndex = 2;
            this.RenderBlackRadio.TabStop = true;
            this.RenderBlackRadio.Text = "Office Black";
            this.RenderBlackRadio.UseVisualStyleBackColor = true;
            // 
            // RenderBlueRadio
            // 
            this.RenderBlueRadio.AutoSize = true;
            this.RenderBlueRadio.Location = new System.Drawing.Point(6, 43);
            this.RenderBlueRadio.Name = "RenderBlueRadio";
            this.RenderBlueRadio.Size = new System.Drawing.Size(77, 17);
            this.RenderBlueRadio.TabIndex = 1;
            this.RenderBlueRadio.TabStop = true;
            this.RenderBlueRadio.Text = "Office Blue";
            this.RenderBlueRadio.UseVisualStyleBackColor = true;
            // 
            // RenderNormalRadio
            // 
            this.RenderNormalRadio.AutoSize = true;
            this.RenderNormalRadio.Location = new System.Drawing.Point(6, 20);
            this.RenderNormalRadio.Name = "RenderNormalRadio";
            this.RenderNormalRadio.Size = new System.Drawing.Size(58, 17);
            this.RenderNormalRadio.TabIndex = 0;
            this.RenderNormalRadio.TabStop = true;
            this.RenderNormalRadio.Text = "Normal";
            this.RenderNormalRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkMinimizeToTrayCheckbox);
            this.groupBox7.Location = new System.Drawing.Point(6, 224);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(304, 44);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "System Tray";
            // 
            // chkMinimizeToTrayCheckbox
            // 
            this.chkMinimizeToTrayCheckbox.AutoSize = true;
            this.chkMinimizeToTrayCheckbox.Checked = true;
            this.chkMinimizeToTrayCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMinimizeToTrayCheckbox.Location = new System.Drawing.Point(6, 20);
            this.chkMinimizeToTrayCheckbox.Name = "chkMinimizeToTrayCheckbox";
            this.chkMinimizeToTrayCheckbox.Size = new System.Drawing.Size(106, 17);
            this.chkMinimizeToTrayCheckbox.TabIndex = 17;
            this.chkMinimizeToTrayCheckbox.Text = "Minimize To Tray";
            this.chkMinimizeToTrayCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBoxInformation
            // 
            this.groupBoxInformation.Controls.Add(this.chkInvertTabPageOrder);
            this.groupBoxInformation.Controls.Add(this.chkSortTabPagesByCaption);
            this.groupBoxInformation.Controls.Add(this.chkShowUserNameInTitle);
            this.groupBoxInformation.Controls.Add(this.chkShowInformationToolTips);
            this.groupBoxInformation.Controls.Add(this.chkShowFullInfo);
            this.groupBoxInformation.Location = new System.Drawing.Point(6, 3);
            this.groupBoxInformation.Name = "groupBoxInformation";
            this.groupBoxInformation.Size = new System.Drawing.Size(500, 215);
            this.groupBoxInformation.TabIndex = 0;
            this.groupBoxInformation.TabStop = false;
            this.groupBoxInformation.Text = "Information";
            // 
            // chkInvertTabPageOrder
            // 
            this.chkInvertTabPageOrder.AutoSize = true;
            this.chkInvertTabPageOrder.Checked = true;
            this.chkInvertTabPageOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvertTabPageOrder.Location = new System.Drawing.Point(6, 91);
            this.chkInvertTabPageOrder.Name = "chkInvertTabPageOrder";
            this.chkInvertTabPageOrder.Size = new System.Drawing.Size(302, 17);
            this.chkInvertTabPageOrder.TabIndex = 4;
            this.chkInvertTabPageOrder.Text = "Invert the tab page sort order of connections to be opened";
            this.chkInvertTabPageOrder.UseVisualStyleBackColor = true;
            // 
            // chkSortTabPagesByCaption
            // 
            this.chkSortTabPagesByCaption.Checked = true;
            this.chkSortTabPagesByCaption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSortTabPagesByCaption.Location = new System.Drawing.Point(6, 43);
            this.chkSortTabPagesByCaption.Name = "chkSortTabPagesByCaption";
            this.chkSortTabPagesByCaption.Size = new System.Drawing.Size(413, 42);
            this.chkSortTabPagesByCaption.TabIndex = 3;
            this.chkSortTabPagesByCaption.Text = "Sort the list of invisible/hidden tab pages by name; if not checked they will be " +
    "sorted by sequence";
            this.chkSortTabPagesByCaption.UseVisualStyleBackColor = true;
            // 
            // chkShowUserNameInTitle
            // 
            this.chkShowUserNameInTitle.AutoSize = true;
            this.chkShowUserNameInTitle.Checked = true;
            this.chkShowUserNameInTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowUserNameInTitle.Location = new System.Drawing.Point(6, 20);
            this.chkShowUserNameInTitle.Name = "chkShowUserNameInTitle";
            this.chkShowUserNameInTitle.Size = new System.Drawing.Size(156, 17);
            this.chkShowUserNameInTitle.TabIndex = 0;
            this.chkShowUserNameInTitle.Text = "Show  user name in tab title";
            this.chkShowUserNameInTitle.UseVisualStyleBackColor = true;
            // 
            // chkShowInformationToolTips
            // 
            this.chkShowInformationToolTips.AutoSize = true;
            this.chkShowInformationToolTips.Checked = true;
            this.chkShowInformationToolTips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowInformationToolTips.Location = new System.Drawing.Point(6, 122);
            this.chkShowInformationToolTips.Name = "chkShowInformationToolTips";
            this.chkShowInformationToolTips.Size = new System.Drawing.Size(213, 17);
            this.chkShowInformationToolTips.TabIndex = 1;
            this.chkShowInformationToolTips.Text = "Show connection information in tool tips";
            this.chkShowInformationToolTips.UseVisualStyleBackColor = true;
            // 
            // chkShowFullInfo
            // 
            this.chkShowFullInfo.AutoSize = true;
            this.chkShowFullInfo.Location = new System.Drawing.Point(26, 149);
            this.chkShowFullInfo.Name = "chkShowFullInfo";
            this.chkShowFullInfo.Size = new System.Drawing.Size(123, 17);
            this.chkShowFullInfo.TabIndex = 2;
            this.chkShowFullInfo.Text = "Show full information";
            this.chkShowFullInfo.UseVisualStyleBackColor = true;
            // 
            // InterfaceOptionPanel
            // 
            this.Controls.Add(this.panel1);
            this.Name = "InterfaceOptionPanel";
            this.Size = new System.Drawing.Size(519, 331);
            this.panel1.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBoxInformation.ResumeLayout(false);
            this.groupBoxInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox10;
        private CheckBox chkEnableGroupsMenu;
        private GroupBox groupBox1;
        private RadioButton RenderBlackRadio;
        private RadioButton RenderBlueRadio;
        private RadioButton RenderNormalRadio;
        private GroupBox groupBox7;
        private CheckBox chkMinimizeToTrayCheckbox;
        private GroupBox groupBoxInformation;
        private CheckBox chkShowUserNameInTitle;
        private CheckBox chkShowInformationToolTips;
        private CheckBox chkShowFullInfo;
        private CheckBox chkSortTabPagesByCaption;
        private CheckBox chkInvertTabPageOrder;
    }
}