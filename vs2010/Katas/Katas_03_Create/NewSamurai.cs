namespace Katas.Katas_03_Create
{
    public class NewSamurai
    {
        private int hp;

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        protected bool Equals(NewSamurai other)
        {
            return hp == other.hp;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NewSamurai) obj);
        }

        public override int GetHashCode()
        {
            return hp;
        }

        public NewSamurai()
        {
        }



    }
}