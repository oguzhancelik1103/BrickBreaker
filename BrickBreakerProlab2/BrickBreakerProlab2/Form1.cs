namespace BrickBreakerProlab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Ballx = 4; // Topun x yönündeki hareketi için hýzý
        int Bally = 4; // Topun y yönündeki hareketi için hýzý
        int score = 0; // Oyuncunun skoru
        int speedIncrement = 1; // Her tuðla kýrýldýðýnda hýz artýþý
        int playerSpeed = 5; // Player'ýn baþlangýç hýzý

        // Oyun bittiðinde durumu kontrol eden metod
        private void GameOver()
        {
            if (score > 23)
            {
                timer1.Stop();
                MessageBox.Show("Kazandýn!");
            }
            if (ball.Top + ball.Height > ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Kaybettin...");
            }
        }

        // Topun tuðlalarý vurduðunda skoru ve hýzý güncelleyen metod
        private void GetScore()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "block")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        Bally = -Bally;
                        score++;
                        lblscore.Text = "Score : " + score;
                        // Her tuðla kýrýldýðýnda topun ve player'ýn hýzýný arttýr
                        Ballx += speedIncrement;
                        Bally += speedIncrement;
                        playerSpeed += speedIncrement; // Player'ýn hýzýný arttýr
                    }
                }
            }
        }

        // Topun hareketini saðlayan metod
        private void BallMovement()
        {
            ball.Left += Ballx;
            ball.Top += Bally;

            if (ball.Left + ball.Width > ClientSize.Width || ball.Left < 0)
            {
                Ballx = -Ballx;
            }
            if (ball.Top < 0 || ball.Bounds.IntersectsWith(player.Bounds))
            {
                Bally = -Bally;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Klavye tuþlarýna göre oyuncu hareketini saðlayan metod
            if (e.KeyCode == Keys.Left && player.Left > 0)
            {
                player.Left -= playerSpeed; // Player'ý hýzlandýr
            }
            if (e.KeyCode == Keys.Right && player.Right < 730)
            {
                player.Left += playerSpeed; // Player'ý hýzlandýr
            }
        }

        // Timer'ýn her tetiklendiðinde yapýlacak iþlemler
        private void timer1_Tick(object sender, EventArgs e)
        {
            BallMovement();
            GetScore();
            GameOver();
        }
    }
}
