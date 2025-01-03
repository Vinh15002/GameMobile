
namespace Assets.Scripts.Event
{
    public class ChangeClotheEvent
    {
        public  delegate void ChangePants(DataSkinPant data);
        public static ChangePants changePants;

        public delegate void ChangeClothes(int id);
        public static ChangeClothes changeClothes;


      

    }
}
