﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class SimpleDate
    {

        private int day;
        private int month;
        private int year;

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public SimpleDate(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }


    }
}
