using System;




namespace DomainModel.Repository.Memory
{
    public class Statistics
    {
        #region singleton

        protected static Statistics instance;
        protected static object instLock = new object();
        public static Statistics Instance
        {
            get
            {
                lock (instLock)
                {
                    if (instance == null)
                    {
                        instance = new Statistics();
                    }
                }

                return instance;
            }
        }

        #endregion


        public Statistics()
        {
            this.OnlineUserCount = 0;
        }


        public UInt32 OnlineUserCount { get; set; }
    }
}
