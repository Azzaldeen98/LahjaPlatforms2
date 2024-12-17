using LAHJA.Data.TItem;
using LAHJA.UI.Components.Base;
using Microsoft.AspNetCore.Components;
using MudBlazor;
namespace LAHJA.Data.UI.Components.Base
{




    public  enum TypeIconCard
    {
        Icon,
        Image
    }
    public interface IStyleCardIcon: IStyleBaseComponentCard
    {
        public string? ClassImg { set; get; }
    }
    public interface ICardIcon :IStyleCardIcon
    {
      
        
        public TypeIconCard TypeIconCard { set; get; }

    }

    public class CardComponentIcon : ComponentBaseCard<string>, ICardIcon
    {
        public TypeIconCard TypeIconCard { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? ClassImg { get; set; } = "";
        public override TypeComponentCard Type => TypeComponentCard.Icon;

        public override void Build(string db)
        {
            DataBuild = db;
        }
    }



    public  class CardIconServics : CardIcon
    {
        public new string? ClassContanier { set; get; } = "list-inline-item me-0";
    }

   
    public interface ICardText
    {


        public Typo TypeTextCard { set; get; }

    }
    public class CardText : ComponentBaseCard<string>, ICardText
    {
        public Typo TypeTextCard { get; set; } = Typo.body1;

        public override TypeComponentCard Type =>TypeComponentCard.Text;

        public override void Build(string db)
        {
            DataBuild = db;
        }
    }
    public  interface ICardTextBar
    {

    }

    

    public class DataCardTextBar
    {
        public string CardText { set; get; } = "\"We provide models that help to aid in the creation of different attack sequences. You can deal with AGS models choosing the model you want ?.\";\r\n   ";
        public string Header { set; get; } = "LAHJA AI";
        public string SAC { set; get; } = "AI";
    }
    public class CardTextBar: ComponentBaseCard<DataCardTextBar>
    {

        public CardText? CardText { set; get; } 


        public override TypeComponentCard Type => throw new NotImplementedException();

        public override void Build(DataCardTextBar db)
        {
            DataBuild = db;
            CardText = new CardText();
            CardText.Build(db.CardText);

        }
    }

    public class DataBuildCardTextAndIconBar
    {

        public string? Src { set; get; } = "css/ICON-removebg-preview.png";
        public DataCardTextBar? DataCardTextBar { set; get; } =new DataCardTextBar();



        public bool IsActive { set; get; } = true;
        
    }
    public class CardTextAndIconBar: ComponentBaseCard<DataBuildCardTextAndIconBar>
    {

        public CardTextBar? CardTextBar { set; get; } 

        public CardComponentIcon? IconCard { set; get; }

        public override TypeComponentCard Type => throw new NotImplementedException();

        public static CardTextAndIconBar GetGenarelCard(DataBuildCardTextAndIconBar db)
        {
            CardTextAndIconBar cardTextAndIconBar = new CardTextAndIconBar();
            cardTextAndIconBar.IconCard = new CardComponentIcon
            {
               
                ClassItem = "",
                ClassContainer = "main-section-image",
                ClassImg = "main-section-image ",



            };
            cardTextAndIconBar.CardTextBar = new CardTextBar()
            {



                CardText = new CardText()
                {

                    ClassItem = "main-section-image"
                }



            };
            cardTextAndIconBar.Build(db);
            return cardTextAndIconBar;
        }

        public override void Build(DataBuildCardTextAndIconBar db)
        {
            DataBuild = db;
            CardTextBar.Build(db.DataCardTextBar);
            IconCard.Build(db.Src);



        }
    }
    

    



}
