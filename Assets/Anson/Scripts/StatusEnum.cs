using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusEnum
{
    DemonicKinship, 
    Married, 
    AngelicBoon, 
    PetDog, 
    Criminal, 
    Gambler, 
    Addict, 
    Spiritual, 
    Sick, 
    Paranormal, 
    EducatedI, 
    EducatedII, 
    Trained, 
    ParentHood, 
    Divorced, 
    Employed, 
    Unemployed, 
    SportsTalent, 
    Driver, 
    PetHamster, 
    Soulmate, 
    Haunted, 
    DieYoung, 
    Streamer, 
    EducatedIII, 
    Evil, 
    Magic,
    Deserter,
    Jailed,
    PetDragon,
    RedDragonPet,
    BlueDragonPet,
    Unicorn,
    Dishonest,
    PetCat,
    Heartless,
    ProGamer,
    Hedgie,
    Networked,
    Weeb,
    ECommerce,
    StudentDebt,
    Mortgage,
    Televangelist

}

public static class StatusEnumName
{
    public static string GetStatusNameString(StatusEnum status)
    {
        switch (status)
        {
            case StatusEnum.DemonicKinship:
                return "Demonic Kinship";
            case StatusEnum.AngelicBoon:
                return "Angelic Boon";
            case StatusEnum.PetDog:
                return "Pet Dog";
            case StatusEnum.EducatedI:
                return "Educated I";
            case StatusEnum.EducatedII:
                return "Educated II";
            case StatusEnum.SportsTalent:
                return "Sports Talent";
            case StatusEnum.PetHamster:
                return "Pet Hamster";
            case StatusEnum.DieYoung:
                return "Die Young";
            case StatusEnum.EducatedIII:
                return "Educated III";
            default:
                return status.ToString();
        }
    }
}
