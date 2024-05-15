namespace praktisktprov
{
    public class Player
    {
        private int _health;
        public int Health { get { return _health; } }
        

        public Player()
        {
            //Sätter liv till 100
            HP = 100;
        }

        public void BlirTräffad(int attack_value)
        {
            HP = HP - attack_value;

            if(HP <= 0)
            {
                Die();
            }  
        }
        private void Die()
        {
            Console.WriteLine("Spelaren har dött!");

            IsDead = true;
        }


       

        
    }
}