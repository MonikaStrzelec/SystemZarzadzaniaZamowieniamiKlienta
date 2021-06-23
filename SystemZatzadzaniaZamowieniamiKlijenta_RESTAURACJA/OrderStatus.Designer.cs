
namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    partial class OrderStatus
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(271, 229);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(50, 20);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "label1";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(380, 274);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(94, 29);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "button1";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // OrderStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.timeLabel);
            this.Name = "OrderStatus";
            this.Text = "OrderStatus";
            this.Load += new System.EventHandler(this.OrderStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button startButton;
    }
}