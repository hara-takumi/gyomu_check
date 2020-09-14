using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYOMU_CHECK
{
    public class User
    {
        string mId;
        string mName;
        string mKengen;
        public User()
        {
        }
        public User(string id, string name)
        {
            mId = id;
            mName = name;
        }
        public User(string id, string name, string kengen)
        {
            mId = id;
            mName = name;
            mKengen = kengen;
        }
        public string Name
        {
            set
            {
                mName = value;
            }
            get
            {
                return mName;
            }
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
        public string Kengen
        {
            set
            {
                mKengen = value;
            }
            get
            {
                return mKengen;
            }
        }

    }

}
