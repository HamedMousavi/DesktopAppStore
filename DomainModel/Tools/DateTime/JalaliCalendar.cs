using System;



namespace DomainModel.Tools.DateTime
{
    public class JalaliCalendar
    {
        protected int dayOfWeek, dayOfMonth, month, year;


        protected System.DateTime currentGregorian;
        public System.DateTime Current 
        {
            get { return this.currentGregorian; }
            set
            {
                if (this.currentGregorian != value && value != null)
                {
                    this.currentGregorian = value;
                    UpdatePersianCurrent();
                }
            }
        }


        protected readonly string[] DaysOfWeek =
        { 
            "یکشنبه", 
            "دو شنبه", 
            "سه شنبه", 
            "چهار شنبه", 
            "پنج شنبه", 
            "جمعه",
            "شنبه", 
        };

        protected readonly string[] MonthsOfYear =
        { 
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان",
            "آذر",
            "دی",
            "بهمن",
            "اسفند",
        };


        private void UpdatePersianCurrent()
        {
            System.Globalization.PersianCalendar pc = new 
                System.Globalization.PersianCalendar();

            this.year = pc.GetYear(this.currentGregorian);
            this.month = pc.GetMonth(this.currentGregorian);
            this.dayOfMonth = pc.GetDayOfMonth(this.currentGregorian);
            this.dayOfWeek = System.Convert.ToInt32(this.currentGregorian.DayOfWeek);
        }

       
        public int PersianDay
        {
            get
            {
                return this.dayOfMonth;
            }
        }

       
        public string PersianDayOfWeek
        {
            get
            {
                return this.DaysOfWeek[this.dayOfWeek];
            }
        }


        public string PersianMonth
        {
            get
            {
                return this.MonthsOfYear[this.month - 1];
            }
        }


        public string PersianYear
        {
            get
            {
                return this.year.ToString();
            }
        }
    }
}
