using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYOMU_CHECK
{
    class Sagyo
    {
        string mId;
        string mState;
        string mStartUser;
        string mEndUser;
        DateTime mStartDate;
        DateTime mEndDate;
        public Sagyo(string id, string state)
        {
            mId = id;
            mState = state;
        }
        public string Id
        {
            set
            {
                mId = value;
            }
            get
            {
                return mId;
            }
        }
    }
}
