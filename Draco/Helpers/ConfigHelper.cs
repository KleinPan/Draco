using Draco.Configs;
using Draco.Properties.Langs;

using Newtonsoft.Json;

using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;

namespace Draco.Helpers
{
    public class ConfigHelper : INotifyPropertyChanged
    {
        public static ConfigHelper Instance = new Lazy<ConfigHelper>(() => new ConfigHelper()).Value;

        #region Lang
        private XmlLanguage _lang = XmlLanguage.GetLanguage("zh-cn");

        public XmlLanguage Lang
        {
            get => _lang;
            set
            {
                if (!_lang.IetfLanguageTag.Equals(value.IetfLanguageTag))
                {
                    _lang = value;
                    OnPropertyChanged(nameof(Lang));
                }
            }
        }

        public void SetLang(string lang)
        {
            LangProvider.Culture = new CultureInfo(lang);
            Application.Current.Dispatcher.Thread.CurrentUICulture = new CultureInfo(lang);
            Lang = XmlLanguage.GetLanguage(lang);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public AppConfig AppConfig;

        public void Read()
        {
            if (File.Exists(AppConfig.SavePath))
            {
                try
                {
                    var json = File.ReadAllText(AppConfig.SavePath);
                    AppConfig = (string.IsNullOrEmpty(json) ? new AppConfig() : JsonConvert.DeserializeObject<AppConfig>(json)) ?? new AppConfig();
                }
                catch
                {
                    AppConfig = new AppConfig();
                }
            }
            else
            {
                AppConfig = new AppConfig();
            }
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(AppConfig);
            File.WriteAllText(AppConfig.SavePath, json);
        }
    }
}
