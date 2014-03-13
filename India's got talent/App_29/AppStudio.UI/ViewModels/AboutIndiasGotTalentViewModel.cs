using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class AboutIndiasGotTalentViewModel : ViewModelBase<HtmlSchema>
    {
        override protected string CacheKey
        {
            get { return "AboutIndiasGotTalentDataSource"; }
        }

        override protected IDataSource<HtmlSchema> CreateDataSource()
        {
            return new AboutIndiasGotTalentDataSource(); // HtmlDataSource
        }

        override public bool IsStaticData
        {
            get { return true; }
        }

        override public ViewTypes ViewType
        {
            get { return ViewTypes.Detail; }
        }

        override public bool IsPinToStartVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }

        override public void PinToStart()
        {
            base.PinToStart("MainPage", "About India's Got Talent", "{Content}", "");
        }

        override public bool IsShareItemVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void ShareItem()
        {
            base.ShareItem("About India's Got Talent", "{Content}", "", "");
        }

        override public bool IsSpeakTextVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void SpeakText()
        {
            base.SpeakText("Content");
        }
    }
}
