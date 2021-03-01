
namespace WindowsForms_add_water_tower
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.load_table = new System.Windows.Forms.Button();
            this.compile = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_object = new System.Windows.Forms.Button();
            this.open_button = new System.Windows.Forms.Button();
            this.listOpen = new System.Windows.Forms.ComboBox();
            this.new_text = new System.Windows.Forms.TextBox();
            this.new_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 20);
            this.textBox1.TabIndex = 1;
            // 
            // load_table
            // 
            this.load_table.Location = new System.Drawing.Point(245, 374);
            this.load_table.Name = "load_table";
            this.load_table.Size = new System.Drawing.Size(138, 20);
            this.load_table.TabIndex = 0;
            this.load_table.Text = "load table in the .csv file";
            this.load_table.UseVisualStyleBackColor = true;
            this.load_table.Click += new System.EventHandler(this.button1_Click);
            // 
            // compile
            // 
            this.compile.Location = new System.Drawing.Point(567, 374);
            this.compile.Name = "compile";
            this.compile.Size = new System.Drawing.Size(64, 22);
            this.compile.TabIndex = 9;
            this.compile.Text = "compile";
            this.compile.UseVisualStyleBackColor = true;
            this.compile.Click += new System.EventHandler(this.compile_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.Latitude,
            this.Longitude,
            this.Scale});
            this.dataGridView1.Location = new System.Drawing.Point(88, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(448, 249);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Nom
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Nom.DefaultCellStyle = dataGridViewCellStyle1;
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            // 
            // Latitude
            // 
            this.Latitude.HeaderText = "Lat";
            this.Latitude.Name = "Latitude";
            // 
            // Longitude
            // 
            this.Longitude.HeaderText = "Lon";
            this.Longitude.Name = "Longitude";
            // 
            // Scale
            // 
            this.Scale.HeaderText = "scale";
            this.Scale.Name = "Scale";
            // 
            // add_object
            // 
            this.add_object.Location = new System.Drawing.Point(309, 77);
            this.add_object.Name = "add_object";
            this.add_object.Size = new System.Drawing.Size(131, 22);
            this.add_object.TabIndex = 10;
            this.add_object.Text = "add object (google map)";
            this.add_object.UseVisualStyleBackColor = true;
            this.add_object.Click += new System.EventHandler(this.add_object_Click);
            // 
            // open_button
            // 
            this.open_button.Location = new System.Drawing.Point(165, 20);
            this.open_button.Name = "open_button";
            this.open_button.Size = new System.Drawing.Size(43, 21);
            this.open_button.TabIndex = 12;
            this.open_button.Text = "open";
            this.open_button.UseVisualStyleBackColor = true;
            this.open_button.Click += new System.EventHandler(this.open_button_Click);
            // 
            // listOpen
            // 
            this.listOpen.FormattingEnabled = true;
            this.listOpen.Location = new System.Drawing.Point(29, 20);
            this.listOpen.Name = "listOpen";
            this.listOpen.Size = new System.Drawing.Size(121, 21);
            this.listOpen.TabIndex = 13;
            // 
            // new_text
            // 
            this.new_text.Location = new System.Drawing.Point(29, 48);
            this.new_text.Name = "new_text";
            this.new_text.Size = new System.Drawing.Size(121, 20);
            this.new_text.TabIndex = 14;
            // 
            // new_button
            // 
            this.new_button.Location = new System.Drawing.Point(165, 44);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(43, 23);
            this.new_button.TabIndex = 15;
            this.new_button.Text = "new";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 404);
            this.Controls.Add(this.new_button);
            this.Controls.Add(this.new_text);
            this.Controls.Add(this.listOpen);
            this.Controls.Add(this.open_button);
            this.Controls.Add(this.add_object);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.compile);
            this.Controls.Add(this.load_table);
            this.Controls.Add(this.textBox1);
            this.MaximumSize = new System.Drawing.Size(657, 443);
            this.MinimumSize = new System.Drawing.Size(657, 443);
            this.Name = "Form1";
            this.Text = "add water tower";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button load_table;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button compile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scale;
        private System.Windows.Forms.Button add_object;
        private System.Windows.Forms.Button open_button;
        private System.Windows.Forms.ComboBox listOpen;
        private System.Windows.Forms.TextBox new_text;
        private System.Windows.Forms.Button new_button;
    }
}

