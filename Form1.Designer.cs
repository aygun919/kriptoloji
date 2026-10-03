namespace kriptoloji
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
            txtGiris = new RichTextBox();
            txtCikti = new RichTextBox();
            cmbYontem = new ComboBox();
            groupBox1 = new GroupBox();
            btnSifrele = new Button();
            txtAnahtar2 = new TextBox();
            btnCoz = new Button();
            numAnahtar1 = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnGonder = new Button();
            txtAliciEposta = new TextBox();
            label4 = new Label();
            label3 = new Label();
            btnEpostaAl = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAnahtar1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtGiris
            // 
            txtGiris.Location = new Point(86, 93);
            txtGiris.Name = "txtGiris";
            txtGiris.Size = new Size(213, 144);
            txtGiris.TabIndex = 0;
            txtGiris.Text = "";
            // 
            // txtCikti
            // 
            txtCikti.Location = new Point(892, 78);
            txtCikti.Name = "txtCikti";
            txtCikti.Size = new Size(197, 159);
            txtCikti.TabIndex = 1;
            txtCikti.Text = "";
            // 
            // cmbYontem
            // 
            cmbYontem.FormattingEnabled = true;
            cmbYontem.Items.AddRange(new object[] { "Kaydırmalı Şifreleme ", "Zigzag Şifreleme", "Permütasyon Şifreleme", "Doğrusal Şifreleme", "Rota Şifreleme", "Yer Değiştirme Şifreleme", "Sayı Anahtarlı Şifreleme", "Hill Algoritması Şifreleme", "4 kare matris Şifreleme", "Vigenere Şifreleme" });
            cmbYontem.Location = new Point(86, 305);
            cmbYontem.Name = "cmbYontem";
            cmbYontem.Size = new Size(182, 33);
            cmbYontem.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSifrele);
            groupBox1.Controls.Add(txtAnahtar2);
            groupBox1.Controls.Add(btnCoz);
            groupBox1.Controls.Add(numAnahtar1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(421, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(380, 198);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // btnSifrele
            // 
            btnSifrele.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            btnSifrele.Location = new Point(207, 137);
            btnSifrele.Name = "btnSifrele";
            btnSifrele.Size = new Size(112, 39);
            btnSifrele.TabIndex = 5;
            btnSifrele.Text = "ŞİFRELE";
            btnSifrele.UseVisualStyleBackColor = true;
            btnSifrele.Click += btnSifrele_Click;
            // 
            // txtAnahtar2
            // 
            txtAnahtar2.Location = new Point(122, 78);
            txtAnahtar2.Name = "txtAnahtar2";
            txtAnahtar2.Size = new Size(172, 31);
            txtAnahtar2.TabIndex = 3;
            // 
            // btnCoz
            // 
            btnCoz.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            btnCoz.Location = new Point(27, 142);
            btnCoz.Name = "btnCoz";
            btnCoz.Size = new Size(112, 34);
            btnCoz.TabIndex = 4;
            btnCoz.Text = "ÇÖZ";
            btnCoz.UseVisualStyleBackColor = true;
            btnCoz.Click += btnCoz_Click;
            // 
            // numAnahtar1
            // 
            numAnahtar1.Location = new Point(122, 35);
            numAnahtar1.Name = "numAnahtar1";
            numAnahtar1.Size = new Size(180, 31);
            numAnahtar1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label2.Location = new Point(18, 84);
            label2.Name = "label2";
            label2.Size = new Size(98, 25);
            label2.TabIndex = 1;
            label2.Text = "Anahtar 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label1.Location = new Point(18, 37);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 0;
            label1.Text = "Anahtar 1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnGonder);
            groupBox2.Controls.Add(txtAliciEposta);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(809, 286);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(313, 189);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // btnGonder
            // 
            btnGonder.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            btnGonder.Location = new Point(100, 127);
            btnGonder.Name = "btnGonder";
            btnGonder.Size = new Size(112, 34);
            btnGonder.TabIndex = 3;
            btnGonder.Text = "GÖNDER";
            btnGonder.UseVisualStyleBackColor = true;
            btnGonder.Click += btnGonder_Click;
            // 
            // txtAliciEposta
            // 
            txtAliciEposta.Location = new Point(137, 72);
            txtAliciEposta.Name = "txtAliciEposta";
            txtAliciEposta.Size = new Size(150, 31);
            txtAliciEposta.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label4.Location = new Point(19, 72);
            label4.Name = "label4";
            label4.Size = new Size(110, 25);
            label4.TabIndex = 1;
            label4.Text = "Alıcı Adresi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label3.Location = new Point(83, 27);
            label3.Name = "label3";
            label3.Size = new Size(179, 25);
            label3.TabIndex = 0;
            label3.Text = "E POSTA İŞLEMLERİ";
            // 
            // btnEpostaAl
            // 
            btnEpostaAl.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            btnEpostaAl.Location = new Point(919, 498);
            btnEpostaAl.Name = "btnEpostaAl";
            btnEpostaAl.Size = new Size(112, 34);
            btnEpostaAl.TabIndex = 5;
            btnEpostaAl.Text = "E Posta Al";
            btnEpostaAl.UseVisualStyleBackColor = true;
            btnEpostaAl.Click += btnEpostaAl_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ButtonHighlight;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label5.Location = new Point(100, 44);
            label5.Name = "label5";
            label5.Size = new Size(162, 32);
            label5.TabIndex = 6;
            label5.Text = "Metin Giriniz";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label6.Location = new Point(86, 265);
            label6.Name = "label6";
            label6.Size = new Size(230, 25);
            label6.TabIndex = 7;
            label6.Text = "Şifreleme Yöntemi Seçiniz";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ButtonHighlight;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label7.Location = new Point(457, 31);
            label7.Name = "label7";
            label7.Size = new Size(158, 28);
            label7.TabIndex = 8;
            label7.Text = "Anahtar Giriniz";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ButtonHighlight;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label8.Location = new Point(944, 38);
            label8.Name = "label8";
            label8.Size = new Size(56, 28);
            label8.TabIndex = 9;
            label8.Text = "Çıktı";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1182, 567);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnEpostaAl);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(cmbYontem);
            Controls.Add(txtCikti);
            Controls.Add(txtGiris);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "kriptoloji-uçtan uça şifreleme";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAnahtar1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox txtGiris;
        private RichTextBox txtCikti;
        private ComboBox cmbYontem;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Button btnSifrele;
        private TextBox txtAnahtar2;
        private Button btnCoz;
        private NumericUpDown numAnahtar1;
        private GroupBox groupBox2;
        private Button btnGonder;
        private TextBox txtAliciEposta;
        private Label label4;
        private Label label3;
        private Button btnEpostaAl;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}
