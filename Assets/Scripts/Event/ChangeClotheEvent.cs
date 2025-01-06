
using Assets.Scripts.ScripTableObject.Skin;

namespace Assets.Scripts.Event
{
    public class ChangeClotheEvent
    {
        public delegate void ChangePants(DataSkinPant data, bool value);
        public static ChangePants changePants;

        public delegate void ChangeClothes(int id, bool value);
        public static ChangeClothes changeClothes;


        public delegate void ChangeFullSkinEvent(DataFullSkin data, bool value);
        public static ChangeFullSkinEvent changeFullSkinEvent;


      

    }
}
