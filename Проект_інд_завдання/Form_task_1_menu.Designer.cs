namespace Проект_інд_завдання
{
    partial class Form_task_1_menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_task_1_menu));
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_to_angle = new System.Windows.Forms.RadioButton();
            this.radioButto_to_solve_c = new System.Windows.Forms.RadioButton();
            this.radioButton_to_solve_S = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(29, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 54);
            this.label1.TabIndex = 8;
            this.label1.Text = "Меню:";
            // 
            // radioButton_to_angle
            // 
            this.radioButton_to_angle.AutoSize = true;
            this.radioButton_to_angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_to_angle.Location = new System.Drawing.Point(24, 277);
            this.radioButton_to_angle.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_to_angle.Name = "radioButton_to_angle";
            this.radioButton_to_angle.Size = new System.Drawing.Size(164, 58);
            this.radioButton_to_angle.TabIndex = 7;
            this.radioButton_to_angle.Text = "Кут а";
            this.radioButton_to_angle.UseVisualStyleBackColor = true;
            this.radioButton_to_angle.CheckedChanged += new System.EventHandler(this.radioButton_to_angle_CheckedChanged);
            // 
            // radioButto_to_solve_c
            // 
            this.radioButto_to_solve_c.AutoSize = true;
            this.radioButto_to_solve_c.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButto_to_solve_c.Location = new System.Drawing.Point(24, 200);
            this.radioButto_to_solve_c.Margin = new System.Windows.Forms.Padding(4);
            this.radioButto_to_solve_c.Name = "radioButto_to_solve_c";
            this.radioButto_to_solve_c.Size = new System.Drawing.Size(275, 58);
            this.radioButto_to_solve_c.TabIndex = 6;
            this.radioButto_to_solve_c.Text = "Сторона с";
            this.radioButto_to_solve_c.UseVisualStyleBackColor = true;
            this.radioButto_to_solve_c.CheckedChanged += new System.EventHandler(this.radioButto_to_solve_c_CheckedChanged);
            // 
            // radioButton_to_solve_S
            // 
            this.radioButton_to_solve_S.AutoSize = true;
            this.radioButton_to_solve_S.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_to_solve_S.Location = new System.Drawing.Point(24, 129);
            this.radioButton_to_solve_S.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_to_solve_S.Name = "radioButton_to_solve_S";
            this.radioButton_to_solve_S.Size = new System.Drawing.Size(470, 58);
            this.radioButton_to_solve_S.TabIndex = 5;
            this.radioButton_to_solve_S.Text = "Площа трикутника";
            this.radioButton_to_solve_S.UseVisualStyleBackColor = true;
            this.radioButton_to_solve_S.CheckedChanged += new System.EventHandler(this.radioButton_to_solve_S_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(601, 39);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(169, 36);
            this.toolStripButton1.Text = "Обрахувати";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(181, 36);
            this.toolStripButton2.Text = "Умова задачі";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(203, 36);
            this.toolStripButton3.Text = "Назад до меню";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // Form_task_1_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(601, 409);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton_to_angle);
            this.Controls.Add(this.radioButto_to_solve_c);
            this.Controls.Add(this.radioButton_to_solve_S);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form_task_1_menu";
            this.Text = "Завдання 1(меню)";
            this.Load += new System.EventHandler(this.Form_task_1_menu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_to_angle;
        private System.Windows.Forms.RadioButton radioButto_to_solve_c;
        private System.Windows.Forms.RadioButton radioButton_to_solve_S;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}