namespace BrickBreakerProlab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Ballx = 4; // Topun x y�n�ndeki hareketi i�in h�z�
        int Bally = 4; // Topun y y�n�ndeki hareketi i�in h�z�
        int score = 0; // Oyuncunun skoru
        int speedIncrement = 1; // Her tu�la k�r�ld���nda h�z art���
        int playerSpeed = 5; // Player'�n ba�lang�� h�z�

        // Oyun bitti�inde durumu kontrol eden metod
        private void GameOver()
        {
            if (score > 23)
            {
                timer1.Stop();
                MessageBox.Show("Kazand�n!");
            }
            if (ball.Top + ball.Height > ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Kaybettin...");
            }
        }

        // Topun tu�lalar� vurdu�unda skoru ve h�z� g�ncelleyen metod
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
                        // Her tu�la k�r�ld���nda topun ve player'�n h�z�n� artt�r
                        Ballx += speedIncrement;
                        Bally += speedIncrement;
                        playerSpeed += speedIncrement; // Player'�n h�z�n� artt�r
                    }
                }
            }
        }

        // Topun hareketini sa�layan metod
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
            // Klavye tu�lar�na g�re oyuncu hareketini sa�layan metod
            if (e.KeyCode == Keys.Left && player.Left > 0)
            {
                player.Left -= playerSpeed; // Player'� h�zland�r
            }
            if (e.KeyCode == Keys.Right && player.Right < 730)
            {
                player.Left += playerSpeed; // Player'� h�zland�r
            }
        }

        // Timer'�n her tetiklendi�inde yap�lacak i�lemler
        private void timer1_Tick(object sender, EventArgs e)
        {
            BallMovement();
            GetScore();
            GameOver();
        }
    }
}
