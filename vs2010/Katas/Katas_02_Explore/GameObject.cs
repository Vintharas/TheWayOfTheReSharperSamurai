namespace Katas.Katas_02_Explore
{
    public interface IGameObject
    {
        void Initialize();
        void Update();
        void Draw();
    }

    public abstract class GameObject : IGameObject
    {
        public abstract void Initialize();
        public abstract void Update();
        public abstract void Draw();

    }
}