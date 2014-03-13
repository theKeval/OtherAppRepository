using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AboutIndiasGotTalentDataSource : IDataSource<HtmlSchema>
    {
        private IEnumerable<HtmlSchema> _data = new HtmlSchema[]
        {
            new HtmlSchema
            {
                Id = "{f23e0230-34d0-4999-bfc5-cb7ce81136a8}",
                Content = @"<p><i><b>India's Got Talent</b></i><span>&nbsp;(sometimes abbreviated as&nbsp;</span><i><b>IGT</b></i><span>) is an Indian&nbsp;</span><a rel=""nofollow"" target=""_blank"" href=""http://en.wikipedia.org/wiki/Reality_television"">reality television</a><span>&nbsp;series on&nbsp;</span><a rel=""nofollow"" target=""_blank"" href=""http://en.wikipedia.org/wiki/Colors_(TV_channel)"">Colors</a>&nbsp;<a rel=""nofollow"" target=""_blank"" href=""http://en.wikipedia.org/wiki/Television_network"">television network</a><span>, and part of the global British&nbsp;</span><i><a rel=""nofollow"" target=""_blank"" href=""http://en.wikipedia.org/wiki/Got_Talent"">Got Talent</a></i><span>. It's a cooperative effort between Colors and Britain's&nbsp;</span><a rel=""nofollow"" target=""_blank"" href=""http://en.wikipedia.org/wiki/FremantleMedia"" title=""Link: http://en.wikipedia.org/wiki/FremantleMedia"">FremantleMedia</a><span>&nbsp;The first episode of&nbsp;</span><i>India's Got Talent</i><span>&nbsp;premiered on June 27, 2009.</span><br></p>"
            }
        };

        public async Task<IEnumerable<HtmlSchema>> LoadData()
        {
            return await Task.Run(() =>
            {
                return _data;
            });
        }

        public async Task<IEnumerable<HtmlSchema>> Refresh()
        {
            return await LoadData();
        }
    }
}
