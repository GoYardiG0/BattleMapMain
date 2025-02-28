﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleMapMain.Services;
using BattleMapMain.Models;

namespace BattleMapMain.ViewModels
{
    public class CharacterEditViewModel : ViewModelBase
    {

        private BattleMapWebAPIProxy proxy;
        public CharacterEditViewModel(BattleMapWebAPIProxy proxy)
        {
            this.proxy = proxy;

            AddCharacterCommand = new Command(OnAddCharacter);
        }

        public Command AddCharacterCommand { get; }

        public async void OnAddCharacter()
        {
            ValidateAc();
            ValidateActionDesc();
            ValidateCha();
            ValidateCon();
            ValidateDex();
            ValidateHp();
            ValidateInte();
            ValidateLevel();
            ValidateName();
            ValidatePassiveDesc();
            ValidateStr();
            ValidateWis();

            if (!ShowNameError && !showAcError && !showActionDescError && !showChaError && !showConError && !showDexError &&
                !showHpError && !showInteError && !showLevelError && !showNameError && !showPassiveDescError && !showStrError && !showWisError)
            {
                //Create a new AppUser object with the data from the registration form
                var newCharacter = new Character
                {
                    CharacterName = Name,
                    UserId = 1/*((App)Application.Current).LoggedInUser.UserId*/,
                    CharacterPic = "" /*MonsterPic*/,
                    Ac = this.Ac,
                    Hp = this.Hp,
                    Str = this.Str,
                    Dex = this.Dex,
                    Con = this.Con,
                    Int = this.Inte,
                    Wis = this.Wis,
                    Cha = this.Cha,
                    Level = level,
                    PassiveDesc = this.PassiveDesc,
                    ActionDesc = this.ActionDesc,
                    SpecialActionDesc = this.SpecialActionDesc

                };

                //Call the Register method on the proxy to register the new user
                InServerCall = true;
                newCharacter = await proxy.AddCharacter(newCharacter);
                InServerCall = false;

                //If the registration was successful, navigate to the login page
                if (newCharacter != null)
                {

                    InServerCall = false;


                    await Application.Current.MainPage.DisplayAlert("", "Character Added", "ok");


                    //add the the transtion into the wahterver

                }
                else
                {

                    //If the registration failed, display an error message
                    string errorMsg = "Registration failed. Please try again.";
                    await Application.Current.MainPage.DisplayAlert("Registration", errorMsg, "ok");
                }
            }
        }

        #region name
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private bool showNameError;

        public bool ShowNameError
        {
            get => showNameError;
            set
            {
                showNameError = value;
                OnPropertyChanged("ShowNameError");
            }
        }

        private string nameError;

        public string NameError
        {
            get => nameError;
            set
            {
                nameError = value;
                OnPropertyChanged("NameError");
            }
        }

        private void ValidateName()
        {
            ShowNameError = string.IsNullOrEmpty(Name);
        }

        #endregion

        #region ac

        private int ac;
        public int Ac
        {
            get => ac;
            set
            {
                ac = value;
                OnPropertyChanged();
            }
        }
        private bool showAcError;

        public bool ShowAcError
        {
            get => showAcError;
            set
            {
                showAcError = value;
                OnPropertyChanged();
            }
        }

        private string acError;

        public string AcError
        {
            get => acError;
            set
            {
                acError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateAc()
        {
            if (ac <= 0) showAcError = true; else showAcError = false;
        }

        #endregion

        #region hp

        private int hp;
        public int Hp
        {
            get => hp;
            set
            {
                hp = value;
                OnPropertyChanged();
            }
        }
        private bool showHpError;

        public bool ShowHpError
        {
            get => showHpError;
            set
            {
                showHpError = value;
                OnPropertyChanged();
            }
        }

        private string hpError;

        public string HpError
        {
            get => hpError;
            set
            {
                hpError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateHp()
        {
            if (hp <= 0) showHpError = true; else showHpError = false;
        }

        #endregion

        #region str

        private int str;
        public int Str
        {
            get => str;
            set
            {
                str = value;
                OnPropertyChanged();
            }
        }
        private bool showStrError;

        public bool ShowStrError
        {
            get => showStrError;
            set
            {
                showStrError = value;
                OnPropertyChanged();
            }
        }

        private string strError;

        public string StrError
        {
            get => strError;
            set
            {
                strError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateStr()
        {
            if (str <= 0) showStrError = true; else showStrError = false;
        }

        #endregion

        #region dex

        private int dex;
        public int Dex
        {
            get => dex;
            set
            {
                dex = value;
                OnPropertyChanged();
            }
        }
        private bool showDexError;

        public bool ShowDexError
        {
            get => showDexError;
            set
            {
                showDexError = value;
                OnPropertyChanged();
            }
        }

        private string dexError;

        public string DexError
        {
            get => dexError;
            set
            {
                dexError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateDex()
        {
            if (dex <= 0) showDexError = true; else showDexError = false;
        }

        #endregion

        #region con

        private int con;
        public int Con
        {
            get => con;
            set
            {
                con = value;
                OnPropertyChanged();
            }
        }
        private bool showConError;

        public bool ShowConError
        {
            get => showConError;
            set
            {
                showConError = value;
                OnPropertyChanged();
            }
        }

        private string conError;

        public string ConError
        {
            get => conError;
            set
            {
                conError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateCon()
        {
            if (con <= 0) showConError = true; else showConError = false;
        }

        #endregion

        #region int

        private int inte;
        public int Inte
        {
            get => inte;
            set
            {
                inte = value;
                OnPropertyChanged();
            }
        }
        private bool showInteError;

        public bool ShowInterror
        {
            get => showInteError;
            set
            {
                showInteError = value;
                OnPropertyChanged();
            }
        }

        private string inteError;

        public string InteError
        {
            get => inteError;
            set
            {
                inteError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateInte()
        {
            if (inte <= 0) showInteError = true; else showInteError = false;
        }

        #endregion

        #region wis

        private int wis;
        public int Wis
        {
            get => wis;
            set
            {
                wis = value;
                OnPropertyChanged();
            }
        }
        private bool showWisError;

        public bool ShowWisError
        {
            get => showWisError;
            set
            {
                showWisError = value;
                OnPropertyChanged();
            }
        }

        private string wisError;

        public string WisError
        {
            get => wisError;
            set
            {
                wisError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateWis()
        {
            if (wis <= 0) showWisError = true; else showWisError = false;
        }

        #endregion

        #region cha

        private int cha;
        public int Cha
        {
            get => cha;
            set
            {
                cha = value;
                OnPropertyChanged();
            }
        }
        private bool showChaError;

        public bool ShowChaError
        {
            get => showChaError;
            set
            {
                showChaError = value;
                OnPropertyChanged();
            }
        }

        private string chaError;

        public string ChaError
        {
            get => chaError;
            set
            {
                chaError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateCha()
        {
            if (cha <= 0) showChaError = true; else showChaError = false;
        }

        #endregion

        #region level

        private int level;
        public int Level
        {
            get => level;
            set
            {
                level = value;
                OnPropertyChanged();
            }
        }
        private bool showLevelError;

        public bool ShowLevelError
        {
            get => showLevelError;
            set
            {
                showLevelError = value;
                OnPropertyChanged();
            }
        }

        private string levelError;

        public string LevelError
        {
            get => levelError;
            set
            {
                levelError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateLevel()
        {
            if (level < 0) showLevelError = true; else showLevelError = false;
        }

        #endregion

        #region passiveDesc

        private string passiveDesc;
        public string PassiveDesc
        {
            get => passiveDesc;
            set
            {
                passiveDesc = value;
                OnPropertyChanged();
            }
        }
        private bool showPassiveDescError;

        public bool ShowPassiveDescError
        {
            get => showPassiveDescError;
            set
            {
                showPassiveDescError = value;
                OnPropertyChanged();
            }
        }

        private string passiveDescError;

        public string PassiveDescError
        {
            get => passiveDescError;
            set
            {
                passiveDescError = value;
                OnPropertyChanged();
            }
        }

        private void ValidatePassiveDesc()
        {
            if (passiveDesc == null) showPassiveDescError = true; else showPassiveDescError = false;
        }

        #endregion

        #region actionDesc

        private string actionDesc;
        public string ActionDesc
        {
            get => actionDesc;
            set
            {
                actionDesc = value;
                OnPropertyChanged();
            }
        }
        private bool showActionDescError;

        public bool ShowActionDescError
        {
            get => showActionDescError;
            set
            {
                showActionDescError = value;
                OnPropertyChanged();
            }
        }

        private string actionDescError;

        public string ActionDescError
        {
            get => actionDescError;
            set
            {
                actionDescError = value;
                OnPropertyChanged();
            }
        }

        private void ValidateActionDesc()
        {
            if (actionDesc == null) showActionDescError = true; else showActionDescError = false;
        }

        #endregion

        #region specialActionDesc

        private string specialActionDesc;
        public string SpecialActionDesc
        {
            get => specialActionDesc;
            set
            {
                specialActionDesc = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
