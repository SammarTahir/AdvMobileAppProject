using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class Shows : BaseViewModel
    {
        #region == Public Properties ==
        public string Title { get; set; }
        public string Rank { get; set; }
        public string ID { get; set; }
        #endregion

        #region == constructors ==
        public Shows()
        {
        }

        public Shows(string t, string r, string i)
        {
            Title = t;
            Rank = r;
            ID = i;
        }

        #endregion
    }
}
