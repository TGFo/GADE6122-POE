namespace Swamp_Game
{
    public partial class Form1 : Form
    {
        static GameEngine game = new GameEngine();
        readonly string heroInfo = game.GetMap().GetHero().ToString();
        int playerMove = 5;
        int shopItem;
        List<Button> shopButtons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            txtField.Text = game.ToString();
            txtDisplay.Text = game.GetMap().GetHero().ToString();
            listEnemies.Items.AddRange(game.GetMap().GetEnemies());
            btnAttack.Enabled = false;
            shopButtons.Add(btnItem1);
            shopButtons.Add(btnItem2);
            shopButtons.Add(btnItem3);
            RefreshShop();
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            playerMove = 1;
            MovePlayer();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            playerMove = 2;
            MovePlayer();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            playerMove = 3;
            MovePlayer();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            playerMove = 4;
            MovePlayer();
        }
        private void btnAttack_Click(object sender, EventArgs e)
        {
            //game.Kill((Enemy)listEnemies.SelectedItem);
            //turn();
            Attack();
        }
        private void listEnemies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listEnemies.SelectedItem != null)
            {
                lblEnemyInfo.Text = "Selected Enemy's HP: " + (((Enemy)listEnemies.SelectedItem).GetHP()).ToString();
                btnAttack.Enabled = true;
            }
        }
        public void turn()
        {
            //if(game.MovePlayer((Character.Movement)playerMove) == false)
            //{
            //    txtDisplay.Text += "\n Miss, enemy too far";
            //}
            playerMove = 5;
            game.GetMap().UpdateVision();
            //for(int creature = 0; creature < game.GetMap().GetEnemies().Length; creature++)
            //{
            //    lblEnemyInfo.Text += "HP: " + game.GetMap().GetEnemies()[creature].ToString() + (game.GetMap().GetEnemies()[creature].GetDamage()).ToString() + "\n";
            //}
            game.GetMap().GenerateMap();
            txtDisplay.Text = game.GetMap().GetHero().ToString();
            txtField.Text = game.ToString();
            if (game.GetMap().GetHero().vision[0] != null)
            {
                txtDisplay.Text += game.GetMap().GetHero().vision[0].ToString();
            }
            listEnemies.Items.Clear();
            foreach(Enemy enemy in game.GetMap().GetEnemies())
            {
                if(enemy != null)
                {
                    listEnemies.Items.Add(enemy);
                }
            }
            if (listEnemies.SelectedItem != null)
            {
                lblEnemyInfo.Text = "Selected Enemy's HP: " + (((Enemy)listEnemies.SelectedItem).GetHP()).ToString();
            }
            btnAttack.Enabled = false;
            RefreshShop();
        }
        public void MovePlayer()
        {
            if (game.MovePlayer((Character.Movement)playerMove) == true)
            {
                game.moveCreature();
                game.EnemyAttacks();
                GameOver();
                turn();
            }
        }
        public void Attack()
        {
            if(game.GetMap().GetHero().CheckRange((Enemy)listEnemies.SelectedItem))
            {
                game.GetMap().GetHero().Attack((Enemy)listEnemies.SelectedItem);
                game.EnemyAttacks();
                Kill();
                GameOver();
                turn();
            }
        }
        public void Kill()
        {
            if(((Character)listEnemies.SelectedItem).IsDead())
            {
                game.Kill((Character)listEnemies.SelectedItem);
            }
        }
        public void GameOver()
        {
            if (game.GetMap().GetHero().IsDead())
            {
                btnAttack.Enabled = false;
                btnDown.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                BtnUp.Enabled = false;
            }
        }

        public void btnSaveGame_Click(object sender, EventArgs e)
        {
            game.SaveGame();
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            game.LoadGame();
            turn();
        }

        private void btnItem1_Click(object sender, EventArgs e)
        {
            shopItem = 0;
            game.GetShop().Buy(shopItem);
        }

        private void btnItem2_Click(object sender, EventArgs e)
        {
            shopItem = 1;
            game.GetShop().Buy(shopItem);
        }

        private void btnItem3_Click(object sender, EventArgs e)
        {
            shopItem = 2;
            game.GetShop().Buy(shopItem);
        }
        public void RefreshShop()
        {
            for (int i = 0; i < 3; i++)
            {
                shopButtons[i].Text = game.GetShop().getWeapons()[i].ToString();
                if (game.GetShop().CanBuy(i))
                {
                    shopButtons[i].Enabled = true;
                }
                else
                {
                    shopButtons[i].Enabled = false;
                }
            }
        }
    }
}