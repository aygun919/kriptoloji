using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;

namespace kriptoloji
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Kripto Uygulamasý", "senin_epostan@gmail.com"));
                message.To.Add(new MailboxAddress("Alici", txtAliciEposta.Text));
                message.Subject = "Sifreli Mesaj";

                // SADECE þifreli metni gövdeye ekliyoruz
                message.Body = new TextPart("plain") { Text = txtCikti.Text };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    // Buraya Google'dan aldýðýn 16 haneli uygulama þifresini yazmalýsýn
                    client.Authenticate("kircicekirem1@gmail.com", "jmok mhzc jojd plgn");
                    client.Send(message);
                    client.Disconnect(true);
                }
                MessageBox.Show("E-posta baþarýyla gönderildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluþtu: " + ex.Message);
            }
        }

        private void btnEpostaAl_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.Authenticate("kircicekirem1@gmail.com", "jmok mhzc jojd plgn");

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    // En son gelen mesajý alýyoruz
                    var message = inbox.GetMessage(inbox.Count - 1);

                    // Gelen þifreli metni giriþ kutusuna aktaralým ki çözebilelim
                    txtGiris.Text = message.TextBody;

                    client.Disconnect(true);
                    MessageBox.Show("Yeni mesaj baþarýyla indirildi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluþtu: " + ex.Message);
            }
        }

        private void btnSifrele_Click(object sender, EventArgs e)
        {
            if (cmbYontem.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir þifreleme yöntemi seçin.");
                return;
            }

            string metin = txtGiris.Text;
            string sonuc = "";

            switch (cmbYontem.SelectedIndex)
            {
                case 0:
                    {
                        int kaydirma = (int)numAnahtar1.Value;
                        sonuc = SifrelemeMotoru.KaydirmaliSifrele(metin, kaydirma);
                        break;
                    }

                case 1:
                    {
                        int satir = (int)numAnahtar1.Value;
                        sonuc = SifrelemeMotoru.ZigzagSifrele(metin, satir);
                        break;
                    }

                case 2:
                    {
                        if (!int.TryParse(txtAnahtar2.Text, out int blok))
                        {
                            MessageBox.Show("Blok boyutu sayý olmalý!");
                            return;
                        }
                        sonuc = SifrelemeMotoru.PermutasyonSifrele(metin, blok);
                        break;
                    }

                case 3:
                    {
                        int a = (int)numAnahtar1.Value;

                        if (!int.TryParse(txtAnahtar2.Text, out int b))
                        {
                            MessageBox.Show("Anahtar 2 sayý olmalý!");
                            return;
                        }

                        sonuc = SifrelemeMotoru.DogrusalSifrele(metin, a, b);
                        break;
                    }

                case 4:
                    {
                        int satir = (int)numAnahtar1.Value;
                        sonuc = SifrelemeMotoru.RotaSifrele(metin, satir);
                        break;
                    }
                case 5:
                    {
                        string anahtarKelime = txtAnahtar2.Text;

                        if (string.IsNullOrWhiteSpace(anahtarKelime))
                        {
                            MessageBox.Show("Anahtar kelime giriniz!");
                            return;
                        }

                        sonuc = SifrelemeMotoru.YerDegistirmeSifrele(metin, anahtarKelime);
                        break;
                    }
                case 6:
                    {
                        string input = txtAnahtar2.Text;
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            MessageBox.Show("Anahtar sayýlarýný virgülle giriniz (örn: 3,1,4)");
                            return;
                        }

                        int[] anahtar = input.Split(',')
                                             .Select(x => int.Parse(x))
                                             .ToArray();

                        sonuc = SifrelemeMotoru.SayiAnahtarliSifrele(metin, anahtar);
                        break;
                    }
                case 7: // Hill Algoritmasý
                    {
                        string input = txtAnahtar2.Text;
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            MessageBox.Show("2x2 Matris için 4 sayýyý virgülle girin (örn: 3,3,2,5)");
                            return;
                        }

                        try
                        {
                            int[] anahtar = input.Split(',').Select(x => int.Parse(x.Trim())).ToArray();
                            if (anahtar.Length != 4)
                            {
                                MessageBox.Show("Lütfen tam olarak 4 sayý girin!");
                                return;
                            }
                            sonuc = SifrelemeMotoru.HillSifrele(metin, anahtar);
                        }
                        catch
                        {
                            MessageBox.Show("Hatalý anahtar formatý!");
                            return;
                        }
                        break;
                    }
                case 8: // 4 Kare Algoritmasý
                    {
                        string input = txtAnahtar2.Text;
                        if (!input.Contains(","))
                        {
                            MessageBox.Show("Lütfen iki anahtar kelimeyi virgülle ayýrarak girin! (Örn: ELMA, ARMUT)");
                            return;
                        }

                        string[] anahtarlar = input.Split(',');
                        sonuc = SifrelemeMotoru.DortKareSifrele(metin, anahtarlar[0].Trim(), anahtarlar[1].Trim());
                        break;
                    }
                case 9: // Vigenère Algoritmasý
                    {
                        string anahtarKelime = txtAnahtar2.Text;
                        if (string.IsNullOrWhiteSpace(anahtarKelime))
                        {
                            MessageBox.Show("Lütfen bir anahtar kelime girin!");
                            return;
                        }
                        sonuc = SifrelemeMotoru.VigenereSifrele(metin, anahtarKelime);
                        break;
                    }
            }

            txtCikti.Text = sonuc;

        }

        private void btnCoz_Click(object sender, EventArgs e)
        {
            if (cmbYontem.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir þifreleme yöntemi seçin.");
                return;
            }

            string metin = txtGiris.Text;
            string sonuc = "";

            switch (cmbYontem.SelectedIndex)
            {
                case 0:
                    {
                        int kaydirma = (int)numAnahtar1.Value;
                        sonuc = SifrelemeMotoru.KaydirmaliCoz(metin, kaydirma);
                        break;
                    }

                case 1:
                    {
                        int satir = (int)numAnahtar1.Value;
                        sonuc = SifrelemeMotoru.ZigzagCoz(metin, satir);
                        break;
                    }

                case 2:
                    {
                        if (!int.TryParse(txtAnahtar2.Text, out int blok))
                        {
                            MessageBox.Show("Blok boyutu sayý olmalý!");
                            return;
                        }
                        sonuc = SifrelemeMotoru.PermutasyonCoz(metin, blok);
                        break;
                    }

                case 3:
                    {
                        int a = (int)numAnahtar1.Value;

                        if (!int.TryParse(txtAnahtar2.Text, out int b))
                        {
                            MessageBox.Show("Anahtar 2 sayý olmalý!");
                            return;
                        }

                        sonuc = SifrelemeMotoru.DogrusalCoz(metin, a, b);
                        break;
                    }

                case 4:
                    {
                        int satir = (int)numAnahtar1.Value;
                        sonuc = SifrelemeMotoru.RotaCoz(metin, satir);
                        break;
                    }
                case 5:
                    {
                        string anahtarKelime = txtAnahtar2.Text;

                        if (string.IsNullOrWhiteSpace(anahtarKelime))
                        {
                            MessageBox.Show("Anahtar kelime giriniz!");
                            return;
                        }

                        sonuc = SifrelemeMotoru.YerDegistirmeCoz(metin, anahtarKelime);
                        break;
                    }
                case 6:
                    {
                        string input = txtAnahtar2.Text;

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            MessageBox.Show("Anahtar sayýlarýný virgülle giriniz (örn: 3,1,4)");
                            return;
                        }

                        try
                        {
                            int[] anahtar = input.Split(',')
                                                 .Select(x => int.Parse(x))
                                                 .ToArray();

                            sonuc = SifrelemeMotoru.SayiAnahtarliCoz(metin, anahtar);
                        }
                        catch
                        {
                            MessageBox.Show("Anahtar formatý hatalý! Örn: 3,1,4");
                            return;
                        }

                        break;
                    }
                case 7: // Hill Algoritmasý Çözme
                    {
                        string input = txtAnahtar2.Text;
                        try
                        {
                            int[] anahtar = input.Split(',').Select(x => int.Parse(x.Trim())).ToArray();
                            sonuc = SifrelemeMotoru.HillCoz(metin, anahtar);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                            return;
                        }
                        break;
                    }
                case 8: // 4 Kare Çözme
                    {
                        string input = txtAnahtar2.Text;
                        if (!input.Contains(",")) return;

                        string[] anahtarlar = input.Split(',');
                        sonuc = SifrelemeMotoru.DortKareCoz(metin, anahtarlar[0].Trim(), anahtarlar[1].Trim());
                        break;
                    }
                case 9: // Vigenère Çözme
                    {
                        string anahtarKelime = txtAnahtar2.Text;
                        if (string.IsNullOrWhiteSpace(anahtarKelime))
                        {
                            MessageBox.Show("Lütfen anahtar kelimeyi girin!");
                            return;
                        }
                        sonuc = SifrelemeMotoru.VigenereCoz(metin, anahtarKelime);
                        break;
                    }
            }

            txtCikti.Text = sonuc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
