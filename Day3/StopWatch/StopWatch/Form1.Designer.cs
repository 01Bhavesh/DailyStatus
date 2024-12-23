namespace StopWatch
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.StopWatch = new System.Windows.Forms.Label();
            this.START = new System.Windows.Forms.Button();
            this.RESTART = new System.Windows.Forms.Button();
            this.STOP = new System.Windows.Forms.Button();
            this.formTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // StopWatch
            // 
            this.StopWatch.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopWatch.Location = new System.Drawing.Point(90, 43);
            this.StopWatch.Name = "StopWatch";
            this.StopWatch.Size = new System.Drawing.Size(534, 190);
            this.StopWatch.TabIndex = 0;
            this.StopWatch.Text = "00:00.0";
            this.StopWatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // START
            // 
            this.START.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.START.Location = new System.Drawing.Point(69, 268);
            this.START.Name = "START";
            this.START.Size = new System.Drawing.Size(154, 51);
            this.START.TabIndex = 1;
            this.START.Text = "START";
            this.START.UseVisualStyleBackColor = true;
            this.START.Click += new System.EventHandler(this.START_Click);
            // 
            // RESTART
            // 
            this.RESTART.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESTART.Location = new System.Drawing.Point(554, 268);
            this.RESTART.Name = "RESTART";
            this.RESTART.Size = new System.Drawing.Size(161, 51);
            this.RESTART.TabIndex = 2;
            this.RESTART.Text = "RESTART";
            this.RESTART.UseVisualStyleBackColor = true;
            this.RESTART.Click += new System.EventHandler(this.RESTART_Click);
            // 
            // STOP
            // 
            this.STOP.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STOP.Location = new System.Drawing.Point(307, 268);
            this.STOP.Name = "STOP";
            this.STOP.Size = new System.Drawing.Size(163, 51);
            this.STOP.TabIndex = 3;
            this.STOP.Text = "STOP";
            this.STOP.UseVisualStyleBackColor = true;
            this.STOP.Click += new System.EventHandler(this.STOP_Click);
            // 
            // formTimer
            // 
            this.formTimer.Interval = 10;
            this.formTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.STOP);
            this.Controls.Add(this.RESTART);
            this.Controls.Add(this.START);
            this.Controls.Add(this.StopWatch);
            this.Name = "Form1";
            this.Text = "StopWatch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StopWatch;
        private System.Windows.Forms.Button START;
        private System.Windows.Forms.Button RESTART;
        private System.Windows.Forms.Button STOP;
        private System.Windows.Forms.Timer formTimer;
    }
}

