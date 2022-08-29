namespace Gameplay
{
    public class Enemy : Unit
    {
        public static int Count { get; private set; }

        private void Start()
        {
            Count++;
        }

        public override void Destroy()
        {
            base.Destroy();
            Count--;
        }
    }
}
